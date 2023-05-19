using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wpf_userLoginSqlite.ModelFromDB;

[Table("orderDetails")]
[Index("OrderId", Name = "IX_orderDetails_OrderId")]
public partial class OrderDetail
{
    [Key]
    public long OrderDetailId { get; set; }

    public long OrderId { get; set; }

    public long ProductId { get; set; }

    public long Quantity { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual Order Order { get; set; } = null!;
}
