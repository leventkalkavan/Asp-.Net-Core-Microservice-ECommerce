namespace MultiShop.Cargo.WebAPI.Dtos.CargoOperationDtos;

public class UpdateCargoOperationDto
{
    public int Id { get; set; }
    public int Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationDate { get; set; }
}