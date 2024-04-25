using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Services;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResultDiscountCouponDto>>> GetAllCoupons()
        {
            var coupons = await _discountService.GetAllDiscountCouponAsync();
            return Ok(coupons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetByIdDiscountCouponDto>> GetCouponById(int id)
        {
            var coupon = await _discountService.GetByIdDiscountCouponAsync(id);
            if (coupon == null)
            {
                return NotFound();
            }

            return Ok(coupon);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCoupon(CreateDiscountCouponDto createDiscountCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createDiscountCouponDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCoupon(int id, UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            updateDiscountCouponDto.Id = id;
            await _discountService.UpdateDiscountCouponAsync(updateDiscountCouponDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok();
        }
    }
}