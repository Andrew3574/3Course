using System;
using System.Collections.Generic;

namespace SportApp.Models;

public partial class Set
{
    public int SetId { get; set; }

    public string Name { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual ICollection<SetExcercise> SetExcercises { get; set; } = new List<SetExcercise>();

    public virtual User? User { get; set; }
}
