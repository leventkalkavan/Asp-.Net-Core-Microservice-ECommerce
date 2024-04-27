namespace MultiShop.Cargo.WebAPI.Dtos.CargoDetailDtos;

public class CreateCargoDetailDto
{
    public string SenderCustomer { get; set; }
    public string ReciverCustomer { get; set; }
    public int Barcode { get; set; }
    public int CargoCompanyId { get; set; }
}