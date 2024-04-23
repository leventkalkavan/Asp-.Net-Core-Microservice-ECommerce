using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiShop.Order.Domain.Entities;

public class OrderDetail
{
    [Key] public int Id { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal ProductTotalPrice { get; set; }
    public int OrderingId { get; set; }
    public Ordering Ordering { get; set; }
}