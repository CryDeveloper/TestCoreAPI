using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string SendTime { get; set; } = null!;

    public int TaskId { get; set; }

    public int EmploeyyId { get; set; }

    public string Text { get; set; } = null!;

    public virtual Emploeyy Emploeyy { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
