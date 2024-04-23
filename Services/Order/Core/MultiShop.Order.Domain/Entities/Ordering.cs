using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiShop.Order.Domain.Entities;

public class Ordering
{
    [Key] public int Id { get; set; }
    public string UserId { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}