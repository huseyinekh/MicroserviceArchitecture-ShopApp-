using Dapper;
using FreeCourse.Discount.Models;
using FreeCourse.Shared.Models;
using Npgsql;
using System.Data;

namespace FreeCourse.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDbConnection _dbConnection;
        private readonly IConfiguration _configuration;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection
                    (_configuration.GetConnectionString("PosegreSql"));
        }

        public async Task<Response<List<DiscountModel>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<DiscountModel>
                                ("Select * from discount");

            return Response<List<DiscountModel>>.Success(discounts.ToList(), 200);
        }

        public async Task<Response<DiscountModel>> GetById(int id)
        {
            var discount = await _dbConnection.QueryFirstAsync<DiscountModel>
                ($"Select * from discount where Id=@id", new { Id = id });

            var res =
                discount == null ?
                     Response<DiscountModel>.Fail("Discount Not Found_", 404)
                        : Response<DiscountModel>.Success(discount, 200);


            return res;
        }

        public async Task<Response<DiscountModel>> GetByUserIdAndCode(string userId, string code)
        {
            var discount = await _dbConnection.QueryAsync<DiscountModel>
                ("Select  * from discount where userId=@UserId and code=@Code"
                , new { UserId = userId, Code = code });
            if (discount == null)
            {
                return Response<DiscountModel>.Fail("discount not found", 404);

            }
            return Response<DiscountModel>.Success(discount.First(), 200);
        }

        public async Task<Response<NoConetent>> Save(DiscountModel model)
        {
            var saveStatus = await _dbConnection.ExecuteAsync
                ("INSERT INTO discount(rate,userId,Code) Values(@Rate,@UserId,@Code) ", model);
            if (saveStatus > 0)

                return Response<NoConetent>.Success(204);
            return Response<NoConetent>.Fail("Error at insert proccess_", 500);
        }

        public async Task<Response<NoConetent>> Update(DiscountModel model)
        {
            var updateStatus = await _dbConnection.ExecuteAsync
                ($"Update discount SET userid=@UserId,rate=@Rate,code=@Code Where id=@Id", model);

            if (updateStatus > 0)
                return Response<NoConetent>.Success(204);
            return Response<NoConetent>.Fail("error occured on update proccess_", 500);
        }

        public async Task<Response<NoConetent>> Delete(int id)
        {
            var deleteStatus = await _dbConnection.ExecuteAsync
                ("delete from discount where id=@Id", new { Id = id });

            return deleteStatus > 0 ? Response<NoConetent>.Success(204)
                            : Response<NoConetent>.Fail("discount cannot deleted", 404);

        }

    }
}
