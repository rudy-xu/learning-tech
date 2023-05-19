using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wpf_userLoginSqlite.ModelFromDB;

public partial class Product
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(6, 2)")]
    public byte[] Price { get; set; } = null!;
}
