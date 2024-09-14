using System;
using System.Collections.Generic;

namespace EazyReadsAPI.Models;

public partial class CompanyDetail
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? CompanyLogoUrl { get; set; }

    public string? CompanyTos { get; set; }
}
