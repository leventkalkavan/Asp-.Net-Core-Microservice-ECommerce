using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.WebAPI.Dtos.CargoDetailDtos;
using MultiShop.Cargo.WebAPI.Dtos.CargoOperationDtos;
using MultiShop.Cargo.WebAPI.Entities;
using MultiShop.Cargo.WebAPI.Services;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly IRepository<CargoOperation> _repository;

        public CargoOperationsController(IRepository<CargoOperation> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> CargoOperationsList()
        {
            var values = await _repository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CargoOperationsListById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CrateCargoOperation(CreateCargoOperationDto dto)
        {
            var value = new CargoOperation()
            {
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate
            };
            await _repository.CreateAsync(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto dto)
        {
            var value = await _repository.GetByIdAsync(dto.Id);
            value.Barcode = dto.Barcode;
            value.Description = dto.Description;
            value.OperationDate = dto.OperationDate;
            await _repository.UpdateAsync(value);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoOperation(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
            return Ok();
        }
    }
}