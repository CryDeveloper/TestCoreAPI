using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Task
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string FullTitle { get; set; } = null!;

    public string? ShortTitle { get; set; }

    public string Description { get; set; } = null!;

    public int? ExecutiveEmployeeId { get; set; }

    public int StatusId { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public DateTime? DeletedTime { get; set; }

    public DateTime? Deadline { get; set; }

    public DateTime? SratActualTime { get; set; }

    public DateTime? FinishActualTime { get; set; }

    public int? PreviosTaskId { get; set; }

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Emploeyy? ExecutiveEmployee { get; set; }

    public virtual ICollection<Task> InversePreviosTask { get; set; } = new List<Task>();

    public virtual ListOfObserver? ListOfObserver { get; set; }

    public virtual Task? PreviosTask { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual TaskStatus Status { get; set; } = null!;

    public virtual ICollection<StoryTaskStatus> StoryTaskStatuses { get; set; } = new List<StoryTaskStatus>();
}
