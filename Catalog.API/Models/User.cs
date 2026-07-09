using System;
using System.Collections.Generic;

namespace Catalog.API.Models;

public partial class User
{
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
