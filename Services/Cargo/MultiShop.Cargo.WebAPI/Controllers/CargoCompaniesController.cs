using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.WebAPI.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.WebAPI.Entities;
using MultiShop.Cargo.WebAPI.Services;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly IRepository<CargoCompany> _repository;

        public CargoCompaniesController(IRepository<CargoCompany> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCompaniesList()
        {
            var values = await _repository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CargoCompaniesListById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto dto)
        {
            var value = new CargoCompany()
            {
                Name = dto.Name
            };
            await _repository.CreateAsync(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto dto)
        {
            var value = await _repository.GetByIdAsync(dto.Id);
            value.Name = dto.Name;
            await _repository.UpdateAsync(value);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
            return Ok();
        }
    }
}