using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Stgen.Domain.Entities;
using Stgen.Domain.Enums;
using Stgen.Domain.Repository;
using Stgen.Sql.Queries;

namespace Stgen.Infrastructure.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly IConfiguration _configuration;

        public PurchaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Purchase?> GetActive(int userId)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            connection.Open();
            return await connection.QuerySingleOrDefaultAsync<Purchase>(PurchaseQueries.FilterByStatusAndUserId, new { Status = PurchaseStatus.Active, UserId = userId });
        }

        public async Task<int> CountAnimals(int id)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            connection.Open();
            return await connection.QuerySingleAsync<int>(PurchaseQueries.CountAnimals, new { Id = id });
        }

        public async Task<IEnumerable<AnimalPurchase>> GetAnimals(int id)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            connection.Open();
            return await connection.QueryAsync<AnimalPurchase>(PurchaseQueries.GetAnimals, new { Id = id });
        }

        public async Task<int> AddAnimal(AnimalPurchase animal)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            connection.Open();
            return await connection.ExecuteAsync(PurchaseQueries.AddAnimal, animal);
        }

        public async Task<int> Create(Purchase purchase)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            connection.Open();
            return await connection.ExecuteAsync(PurchaseQueries.Create, purchase);
        }

        public async Task<int> Update(Purchase purchase)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            connection.Open();
            return await connection.ExecuteAsync(PurchaseQueries.Update, purchase);
        }
    }
}
