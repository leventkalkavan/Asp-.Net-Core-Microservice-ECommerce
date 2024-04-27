namespace MultiShop.Cargo.WebAPI.Dtos.CargoOperationDtos;

public class CreateCargoOperationDto
{
    public int Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationDate { get; set; }
}