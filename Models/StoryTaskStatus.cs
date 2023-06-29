using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class StoryTaskStatus
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public int StatusId { get; set; }

    public DateTime UpdatedTimeStatus { get; set; }

    public virtual TaskStatus Status { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
