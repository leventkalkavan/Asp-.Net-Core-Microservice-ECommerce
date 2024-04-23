using System.ComponentModel.DataAnnotations;

namespace MultiShop.Order.Domain.Entities;

public class Ordering
{
    [Key] public int Id { get; set; }
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}