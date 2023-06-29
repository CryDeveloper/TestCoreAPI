using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Attachment
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public string Atttachment { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
