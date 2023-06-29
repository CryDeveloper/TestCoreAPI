using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class DbProjectOfficeContext : DbContext
{
    public DbProjectOfficeContext()
    {
    }

    public DbProjectOfficeContext(DbContextOptions<DbProjectOfficeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Emploeyy> Emploeyys { get; set; }

    public virtual DbSet<ListOfObserver> ListOfObservers { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<StoryTaskStatus> StoryTaskStatuses { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ngknn.ru;Database=DbProjectOffice;User Id=21P;Password=12357;Integrated Security=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.ToTable("Attachment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Atttachment).HasMaxLength(100);

            entity.HasOne(d => d.Task).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attachment_Task");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SendTime)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Text).HasMaxLength(1000);

            entity.HasOne(d => d.Emploeyy).WithMany(p => p.Comments)
                .HasForeignKey(d => d.EmploeyyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Emploeyy");

            entity.HasOne(d => d.Task).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Task");
        });

        modelBuilder.Entity<Emploeyy>(entity =>
        {
            entity.ToTable("Emploeyy");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<ListOfObserver>(entity =>
        {
            entity.HasKey(e => e.TaskId);

            entity.Property(e => e.TaskId).ValueGeneratedNever();

            entity.HasOne(d => d.Emploeyy).WithMany(p => p.ListOfObservers)
                .HasForeignKey(d => d.EmploeyyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ListOfObservers_Emploeyy");

            entity.HasOne(d => d.Task).WithOne(p => p.ListOfObserver)
                .HasForeignKey<ListOfObserver>(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ListOfObservers_Task");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.DeletedTime).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.FinishScheduledDate).HasColumnType("date");
            entity.Property(e => e.FullTitle).HasMaxLength(100);
            entity.Property(e => e.Icon).HasMaxLength(100);
            entity.Property(e => e.ShortTitle).HasMaxLength(10);
            entity.Property(e => e.StartScheduledDate).HasColumnType("date");

            entity.HasOne(d => d.CreatorEmployee).WithMany(p => p.ProjectCreatorEmployees)
                .HasForeignKey(d => d.CreatorEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project_Emploeyy1");

            entity.HasOne(d => d.ResponsibleEmployee).WithMany(p => p.ProjectResponsibleEmployees)
                .HasForeignKey(d => d.ResponsibleEmployeeId)
                .HasConstraintName("FK_Project_Emploeyy");
        });

        modelBuilder.Entity<StoryTaskStatus>(entity =>
        {
            entity.ToTable("StoryTaskStatus");

            entity.Property(e => e.UpdatedTimeStatus).HasColumnType("date");

            entity.HasOne(d => d.Status).WithMany(p => p.StoryTaskStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoryTaskStatus_TaskStatus");

            entity.HasOne(d => d.Task).WithMany(p => p.StoryTaskStatuses)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoryTaskStatus_Task");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task"/*, tb => tb.HasTrigger("Task_Update")*/);

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Deadline).HasColumnType("date");
            entity.Property(e => e.DeletedTime).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.FinishActualTime).HasColumnType("date");
            entity.Property(e => e.FullTitle).HasMaxLength(100);
            entity.Property(e => e.ShortTitle).HasMaxLength(10);
            entity.Property(e => e.SratActualTime).HasColumnType("date");
            entity.Property(e => e.UpdatedTime).HasColumnType("date");

            entity.HasOne(d => d.ExecutiveEmployee).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ExecutiveEmployeeId)
                .HasConstraintName("FK_Task_Emploeyy");

            entity.HasOne(d => d.PreviosTask).WithMany(p => p.InversePreviosTask)
                .HasForeignKey(d => d.PreviosTaskId)
                .HasConstraintName("FK_Task_Task");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Project");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_TaskStatus");
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity.ToTable("TaskStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ColorHex).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
