using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Emploeyy
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<ListOfObserver> ListOfObservers { get; set; } = new List<ListOfObserver>();

    public virtual ICollection<Project> ProjectCreatorEmployees { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectResponsibleEmployees { get; set; } = new List<Project>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
