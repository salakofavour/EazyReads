using System;
using System.Collections.Generic;

namespace EazyReadsAPI.Models;

public partial class UserPaymentInfo
{
    public int UserPid { get; set; }

    public string? PaymentType { get; set; }

    public bool? HasPaid { get; set; }

    public virtual UserDetail UserP { get; set; } = null!;
}
