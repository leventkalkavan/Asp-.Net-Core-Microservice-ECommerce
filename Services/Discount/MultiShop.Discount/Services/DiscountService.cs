using Dapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly DapperContext _context;

    public DiscountService(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
    {
        string query = "SELECT * FROM Coupons";
        using (var connection = _context.CreateConnection())
        {
            var coupons = await connection.QueryAsync<ResultDiscountCouponDto>(query);
            return coupons.ToList();
        }
    }

    public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
    {
        string query = "insert into Coupons (Code,Rate,Status,ValidDate) values (@code,@rate,@status,@validDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code", createDiscountCouponDto.Code);
        parameters.Add("@rate", createDiscountCouponDto.Rate);
        parameters.Add("@status", createDiscountCouponDto.Status);
        parameters.Add("@validDate", createDiscountCouponDto.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
    {
        string query =
            "UPDATE Coupons SET Code = @code, Rate = @rate, Status = @status, ValidDate = @validDate WHERE Id = @id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", updateDiscountCouponDto.Id);
        parameters.Add("@code", updateDiscountCouponDto.Code);
        parameters.Add("@rate", updateDiscountCouponDto.Rate);
        parameters.Add("@status", updateDiscountCouponDto.Status);
        parameters.Add("@validDate", updateDiscountCouponDto.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteDiscountCouponAsync(int id)
    {
        string query = "DELETE FROM Coupons WHERE Id = @id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
    {
        string query = "SELECT * FROM Coupons WHERE Id = @id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
        using (var connection = _context.CreateConnection())
        {
            var coupon = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
            return coupon;
        }
    }
}