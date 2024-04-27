using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.WebAPI.Entities;

public class CargoCompany
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
}