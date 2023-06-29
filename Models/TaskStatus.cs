using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class TaskStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ColorHex { get; set; } = null!;

    public virtual ICollection<StoryTaskStatus> StoryTaskStatuses { get; set; } = new List<StoryTaskStatus>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
