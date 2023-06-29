using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Project
{
    public int Id { get; set; }

    public string FullTitle { get; set; } = null!;

    public string? ShortTitle { get; set; }

    public string? Icon { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? DeletedTime { get; set; }

    public DateTime? StartScheduledDate { get; set; }

    public DateTime? FinishScheduledDate { get; set; }

    public string Description { get; set; } = null!;

    public int CreatorEmployeeId { get; set; }

    public int? ResponsibleEmployeeId { get; set; }

    public virtual Emploeyy CreatorEmployee { get; set; } = null!;

    public virtual Emploeyy? ResponsibleEmployee { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
