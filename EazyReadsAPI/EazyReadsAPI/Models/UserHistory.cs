using System;
using System.Collections.Generic;

namespace EazyReadsAPI.Models;

public partial class UserHistory
{
    public int UserHid { get; set; }

    public string? CompaniesViewed { get; set; }

    public string? DateViewed { get; set; }
}
