using System;
using System.Collections.Generic;

namespace SportApp.Models;

public partial class Excercise
{
    public int ExcerciseId { get; set; }

    public string Name { get; set; } = null!;

    public int? MuscleId { get; set; }

    public string? Description { get; set; }

    public virtual Muscle? Muscle { get; set; }

    public virtual ICollection<SetExcercise> SetExcercises { get; set; } = new List<SetExcercise>();
}
