using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_userLoginSqlite.Models
{
  public class OrderDetail
  {
    public int OrderDetailId { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
  }
}
