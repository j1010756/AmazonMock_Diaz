﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonMock.Models;

public class Book
{
    [Key]
    [Required]
    public int BookID { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Author { get; set; } = null!;

    [Required]
    public string Publisher { get; set; } = null!;

    [Required]
    public string ISBN { get; set; } = null!;

    [Required]
    public string Classification { get; set; } = null!;

    [Required]
    public string Category { get; set; } = null!;

    [Required]
    public int PageCount { get; set; }

    [Required]
    public double Price { get; set; }
}

