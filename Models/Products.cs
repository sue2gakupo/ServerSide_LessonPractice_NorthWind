﻿using System;
using System.Collections.Generic;

namespace NorthWind.Models;

public partial class Products
{
    public int ProductID { get; set; }

    public string ProductName { get; set; } = null!;

    public int SupplierID { get; set; }

    public int CategoryID { get; set; }

    public string QuantityPerUnit { get; set; } = null!;

    public decimal UnitPrice { get; set; }
    //decimal 10進位

    public short UnitsInStock { get; set; }

    public short UnitsOnOrder { get; set; }

    public short ReorderLevel { get; set; }

    public bool Discontinued { get; set; }
    //bool在DisPlayFor會用checkbox呈現資料
    public virtual Categories Category { get; set; } = null!;

    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

    public virtual Suppliers Supplier { get; set; } = null!;
}
