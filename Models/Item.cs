using System;
using System.Collections.Generic;

namespace _4Quantrant.Models;

public partial class Item
{
    public int? ItemId { get; set; }

    public string? ItemName { get; set; }

    public string? DueDate { get; set; }

    public int? Priority { get; set; }

    public int? CategoryId { get; set; }
}
