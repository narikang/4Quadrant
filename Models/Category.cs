﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _4Quantrant.Models;

public class Category
{
    [Key]
    [Required]
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; }
}
