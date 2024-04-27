using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.WebAPI.Entities;

public class CargoOperation
{
    [Key]
    public int Id { get; set; }
    public int Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationDate { get; set; }
}