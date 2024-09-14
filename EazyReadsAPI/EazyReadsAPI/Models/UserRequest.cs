using System;
using System.Collections.Generic;

namespace EazyReadsAPI.Models;

public partial class UserRequest
{
    public int UserRid { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyDescription { get; set; }

    public string? UserEmail { get; set; }

    public virtual UserDetail UserR { get; set; } = null!;
}
