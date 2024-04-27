using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.WebAPI.Entities;

public class CargoDetail
{
    [Key] public int Id { get; set; }
    public string SenderCustomer { get; set; }
    public string ReciverCustomer { get; set; }
    public int Barcode { get; set; }
    public int CargoCompanyId { get; set; }
    public CargoCompany CargoCompany { get; set; }
}