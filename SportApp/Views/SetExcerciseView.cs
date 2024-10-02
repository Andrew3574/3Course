using System;
using System.Collections.Generic;

namespace SportApp.Views;

public partial class SetExcerciseView
{
    public int Id { get; set; }

    public string Set { get; set; } = null!;

    public string Excercise { get; set; } = null!;

    public string? Description { get; set; }

    public int RepeatsNumber { get; set; }

    public int IterationNumber { get; set; }

    public TimeOnly RepeatsDelay { get; set; }

    public TimeOnly RestTimeAfter { get; set; }
}
