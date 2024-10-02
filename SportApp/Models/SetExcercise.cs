using System;
using System.Collections.Generic;

namespace SportApp.Models;

public partial class SetExcercise
{
    public int Id { get; set; }

    public int? ExcerciseId { get; set; }

    public int? SetId { get; set; }

    public int RepeatsNumber { get; set; }

    public int IterationNumber { get; set; }

    public TimeOnly RepeatsDelay { get; set; }

    public TimeOnly RestTimeAfter { get; set; }

    public virtual Excercise? Excercise { get; set; }

    public virtual Set? Set { get; set; }
}
