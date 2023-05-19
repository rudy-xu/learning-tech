using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wpf_userLoginSqlite.ModelFromDB;

[Index("CustomerId", Name = "IX_Orders_CustomerId")]
public partial class Order
{
    [Key]
    public long OrderId { get; set; }

    public long CustomerId { get; set; }

    public string OrderFulfilled { get; set; } = null!;

    public string OrderPlaced { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Orders")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
