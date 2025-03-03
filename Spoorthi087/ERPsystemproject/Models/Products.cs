﻿using System.ComponentModel.DataAnnotations;

public class Products
{
    [Key]
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal Price { get; set; }
    public int StocksAvailable { get; set; }
}
