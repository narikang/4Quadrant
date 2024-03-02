using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4Quantrant.Models;

public class Item
{
    [Key]
    public int ItemId { get; set; }

    public string? ItemName { get; set; }

    public string? DueDate { get; set; }

    public int? Priority { get; set; }

    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}
