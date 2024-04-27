using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.WebAPI.Dtos.CargoDetailDtos;
using MultiShop.Cargo.WebAPI.Entities;
using MultiShop.Cargo.WebAPI.Services;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly IRepository<CargoDetail> _repository;

        public CargoDetailsController(IRepository<CargoDetail> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> CargoDetailsList()
        {
            var values = await _repository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CargoDetailsListById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto dto)
        {
            var value = new CargoDetail()
            {
                SenderCustomer = dto.SenderCustomer,
                ReciverCustomer = dto.ReciverCustomer,
                Barcode = dto.Barcode,
                CargoCompanyId = dto.CargoCompanyId
            };
            await _repository.CreateAsync(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto dto)
        {
            var value = await _repository.GetByIdAsync(dto.Id);
            value.SenderCustomer = dto.SenderCustomer;
            value.ReciverCustomer = dto.ReciverCustomer;
            value.Barcode = dto.Barcode;
            value.CargoCompanyId = dto.CargoCompanyId;
            await _repository.UpdateAsync(value);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
            return Ok();
        }
    }
}