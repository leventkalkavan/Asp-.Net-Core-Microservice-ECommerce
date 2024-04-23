using System.ComponentModel.DataAnnotations;

namespace MultiShop.Order.Domain.Entities;

public class Address
{
    [Key] public int Id { get; set; }
    public string UserId { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Detail { get; set; }
}