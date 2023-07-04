using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Stgen.Domain.Dto;
using Stgen.Domain.Entities;
using Stgen.Domain.Repository;
using Stgen.Sql.Queries;

namespace Stgen.Infrastructure.Repository
{
    public class AnimalRespository : IAnimalRepository
    {
        private readonly IConfiguration configuration;

        public AnimalRespository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IEnumerable<Animal>> GetAll()
        {
            using IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
            connection.Open();
            return await connection.QueryAsync<Animal>(AnimalQueries.GetAll);
        }

        public async Task<Animal> GetById(int animalId)
        {
            using IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
            connection.Open();
            return await connection.QuerySingleOrDefaultAsync<Animal>(AnimalQueries.GetById, new { AnimalId = animalId });
        }

        public async Task<int> Add(Animal animal)
        {
            using IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
            connection.Open();
            return await connection.ExecuteAsync(AnimalQueries.Add, animal);
        }

        public async Task<int> Update(Animal animal)
        {
            using IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
            connection.Open();
            return await connection.ExecuteAsync(AnimalQueries.Update, animal);
        }

        public async Task<int> Delete(int animalId)
        {
            using IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
            connection.Open();
            return await connection.ExecuteAsync(AnimalQueries.Delete, new { AnimalId = animalId });
        }

        public async Task<IEnumerable<Animal>> Filter(AnimalFilter filter)
        {
            using IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
            connection.Open();
            var builder = new SqlBuilder();
            var selector = builder.AddTemplate(AnimalQueries.Filter);
            if (filter.AnimalId.HasValue)
                builder.Where("AnimalId = @AnimalId", new { filter.AnimalId });

            if (!string.IsNullOrEmpty(filter.Name))
                builder.Where("Name = @Name", new { filter.Name });

            if (filter.Sex.HasValue)
                builder.Where("Sex = @Sex", new { filter.Sex });

            if (filter.Status.HasValue)
                builder.Where("Status = @Status", new { filter.Status });
            return await connection.QueryAsync<Animal>(selector.RawSql, filter);
        }
    }
}
