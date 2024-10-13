using FootyFolio.Model;
using FootyFolio.Repository.Common;
using FootyFolioLogic.Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyFolio.Repository
{
    public class FootballerRepository : IFootballerRepository
    {
        private const string _connectionString = "Host=localhost;" +
            "Port=5432;" +
            "Database=FootyFolio;" +
            "Username=postgres;" +
            "Password=postgres";

        public async Task<List<Footballer>> GetFootballersAsync(FootballerFilter footballerFilter)
        {
            var footballers = new List<Footballer>();
            using var connection = new NpgsqlConnection(_connectionString);

            // Base SQL query with WHERE 1 = 1
            var commandText = new StringBuilder(@"
                SELECT 
                    f.""Id"", 
                    f.""FirstName"", 
                    f.""LastName"", 
                    f.""Price"",
                    f.""IsForSale"",
                    f.""UserId""
                FROM ""Footballer"" f
                WHERE 1 = 1
            ");

            // Append filtering condition if the filter name is provided
            if (!string.IsNullOrEmpty(footballerFilter.Name))
            {
                commandText.Append(" AND (f.\"FirstName\" ILIKE @Name OR f.\"LastName\" ILIKE @Name)");
            }

            if(footballerFilter.IsForSale != null)
            {
                commandText.Append(" AND f.\"IsForSale\" = @IsForSale");
            }

            using var command = new NpgsqlCommand(commandText.ToString(), connection);

            // Add the name parameter only if the filter name is provided
            if (!string.IsNullOrEmpty(footballerFilter.Name))
            {
                command.Parameters.AddWithValue("@Name", $"%{footballerFilter.Name}%");
            }
                
            connection.Open();

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var footballer = new Footballer
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Price = Convert.ToDouble(reader["Price"]),
                        IsForSale = Convert.ToBoolean(reader["IsForSale"]),
                        UserId = Guid.Parse(reader["UserId"].ToString())
                    };

                    footballers.Add(footballer);
                }
            }
            connection.Close();

            return footballers;
        }

        public async Task<List<Footballer>> GetFootballersByUserIdAsync(Guid userId)
        {
            var footballers = new List<Footballer>();
            using var connection = new NpgsqlConnection(_connectionString);

            // SQL query to fetch footballers by UserId
            var commandText = @"
            SELECT 
                f.""Id"", 
                f.""FirstName"", 
                f.""LastName"", 
                f.""Price"", 
                f.""IsForSale"",
                f.""UserId""
            FROM ""Footballer"" f
            WHERE f.""UserId"" = @UserId;
        ";

            using var command = new NpgsqlCommand(commandText, connection);

            // Add parameter for UserId
            command.Parameters.AddWithValue("@UserId", userId);

            connection.Open();

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var footballer = new Footballer
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Price = Convert.ToDouble(reader["Price"]),
                        IsForSale = Convert.ToBoolean(reader["IsForSale"]),
                        UserId = Guid.Parse(reader["UserId"].ToString())
                    };

                    footballers.Add(footballer);
                }
            }
            connection.Close();

            return footballers;
        }

    }
}
