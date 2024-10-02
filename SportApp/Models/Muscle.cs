using System;
using System.Collections.Generic;

namespace SportApp.Models;

public partial class Muscle
{
    public int MuscleId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Excercise> Excercises { get; set; } = new List<Excercise>();
}
