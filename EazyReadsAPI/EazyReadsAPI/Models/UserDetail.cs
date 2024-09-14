using System;
using System.Collections.Generic;

namespace EazyReadsAPI.Models;

public partial class UserDetail
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public bool? HasPriviledgedAccess { get; set; }

    public virtual UserPaymentInfo? UserPaymentInfo { get; set; }

    public virtual UserRequest? UserRequest { get; set; }
}
