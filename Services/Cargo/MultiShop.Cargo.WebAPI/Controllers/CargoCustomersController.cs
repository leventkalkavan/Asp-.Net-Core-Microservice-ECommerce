using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.WebAPI.Dtos.CargoCustomerDto;
using MultiShop.Cargo.WebAPI.Entities;
using MultiShop.Cargo.WebAPI.Services;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly IRepository<CargoCustomer> _repository;

        public CargoCustomersController(IRepository<CargoCustomer> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCustomersList()
        {
            var values = await _repository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CargoCustomersListById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto dto)
        {
            var value = new CargoCustomer()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Phone = dto.Phone,
                District = dto.District,
                City = dto.City,
                Address = dto.Address
            };
            await _repository.CreateAsync(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto dto)
        {
            var value = await _repository.GetByIdAsync(dto.Id);
            value.Name = dto.Name;
            value.Surname = dto.Surname;
            value.Email = dto.Email;
            value.Phone = dto.Phone;
            value.District = dto.District;
            value.City = dto.City;
            value.Address = dto.Address;
            await _repository.UpdateAsync(value);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoCustomer(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
            return Ok();
        }
    }
}