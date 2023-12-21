using Dapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {

        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            int affectedCoupon = await connection.ExecuteAsync("INSERT INTO Coupon (ProductName , Description , Amount) VALUES (@productName, @description , @amount)", new { productName = coupon.ProductName, description = coupon.Description, amount = coupon.Amount });

            if (affectedCoupon == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affectedCoupon = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

            if (affectedCoupon == 0)
                return false;

            return true;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });
            if (coupon == null) { return new Coupon { Amount = 0, ProductName = "No Discount", Description = "No Discount Available" }; }
            return coupon;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            int affectedCoupon = await connection.ExecuteAsync("UPDATE Coupon SET ProductName = @productName , Description = @description , Amount = @amount WHERE Id= @id", new { productName = coupon.ProductName, description = coupon.Description, amount = coupon.Amount, id = coupon.Id });

            if (affectedCoupon == 0)
                return false;

            return true;
        }
    }
}
