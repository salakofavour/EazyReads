using System;
using System.Collections.Generic;

namespace EazyReadsAPI.Models;

public partial class ViewedCompany
{
    public int UserHid { get; set; }

    public string? DateViewed { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? CompanyLogoUrl { get; set; }
}
