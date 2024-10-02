using System;
using System.Collections.Generic;

namespace SportApp.Models;

public partial class User
{
    //Добавить regex
    public int UserId { get; set; }

    public string? Login { get; set; }

    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<Set> Sets { get; set; } = new List<Set>();
}
