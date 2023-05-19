using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_userLoginSqlite.Models
{
  public class Order
  {
    [Key]
    public int OrderId { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime OrderFulfilled { get; set; }
    public Customer Customer { get; set; } = null!;
    public ICollection<OrderDetail> Orders { get; set; } = null!;
  }
}
