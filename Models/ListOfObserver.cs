using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ListOfObserver
{
    public int TaskId { get; set; }

    public int EmploeyyId { get; set; }

    public virtual Emploeyy Emploeyy { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
