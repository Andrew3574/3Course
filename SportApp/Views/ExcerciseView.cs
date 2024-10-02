using System;
using System.Collections.Generic;

namespace SportApp.Views;

public partial class ExcerciseView
{
    public int ExcerciseId { get; set; }

    public string Excercise { get; set; } = null!;

    public string? Muscle { get; set; }

    public string? Description { get; set; }
}
