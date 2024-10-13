using FootyFolio.Model;
using FootyFolio.Repository.Common;
using Npgsql;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace FootyFolio.Repository
{
    public class UserRepository : IUserRepository
    {
        private const string _connectionString = "Host=localhost;" +
            "Port=5432;" +
            "Database=FootyFolio;" +
            "Username=postgres;" +
            "Password=postgres";

        public async Task<User> GetUserInfoAsync(Guid id)
        {
            var user = new User();
            using var connection = new NpgsqlConnection(_connectionString);
            var commandText = @"SELECT 
                            u.""Id"" AS ""Id"",
                            u.""Username"" AS ""Username"",
                            u.""Email"" AS ""Email""
                        FROM ""User"" u
                        WHERE u.""Id"" = @id;";

            using var command = new NpgsqlCommand(commandText, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                await reader.ReadAsync();
                user.Id = Guid.Parse(reader["Id"].ToString());
                user.Username = reader["Username"].ToString();
                user.Email = reader["Email"].ToString();
            }

            return user;
        }

        public async Task<List<Footballer>> GetUserWishlistAsync(Guid userId)
        {
            var footballers = new List<Footballer>();
            using var connection = new NpgsqlConnection(_connectionString);

            // SQL query to fetch footballers from Wishlist associated with a specific UserId
            var commandText = @"
            SELECT 
                f.""Id"", 
                f.""FirstName"", 
                f.""LastName"", 
                f.""Price"", 
                f.""IsForSale"",
                f.""UserId""
            FROM ""Footballer"" f
            JOIN ""Wishlist"" w ON w.""FootballerId"" = f.""Id""
            WHERE w.""UserId"" = @UserId;
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

            return footballers;
        }

        public async Task<bool> InsertFootballerIntoWishlistAsnyc(Guid userId, Footballer footballer)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            // SQL query to insert a footballer into the wishlist
            var commandText = @"
            INSERT INTO ""Wishlist"" 
                (""UserId"", ""FootballerId"") 
            VALUES 
                (@UserId, @FootballerId);
        ";

            using var command = new NpgsqlCommand(commandText, connection);
            // Add the required parameters
            command.Parameters.AddWithValue("@UserId", userId);
            command.Parameters.AddWithValue("@FootballerId", footballer.Id);  // Use footballer object's Id

            connection.Open();

            // Execute the query and check if the row was inserted
            var result = await command.ExecuteNonQueryAsync();

            connection.Close();

            // Return true if one row was inserted
            return result > 0;
        }

        public async Task<bool> InsertUserAsync(User user)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var commandText = @"
                INSERT INTO ""User"" 
                    (""Id"", ""Username"", ""Email"") 
                VALUES 
                    (@Id, @Username, @Email);";

            using var command = new NpgsqlCommand(commandText, connection);

            // Add parameters for Id, Username, and Email
            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Email", user.Email);

            connection.Open();

            // Execute the query and check if one row was affected
            var result = await command.ExecuteNonQueryAsync();

            connection.Close();

            return result > 0;  // Return true if one row was inserted
        }

        public async Task<bool> UpdateUserByIdAsync(Guid id, User user)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            // Build the SQL query dynamically based on which fields need to be updated
            var commandText = new StringBuilder("UPDATE \"User\" SET ");

            bool hasUpdates = false;

            if (!string.IsNullOrEmpty(user.Username))
            {
                commandText.Append("\"Username\" = @Username");
                hasUpdates = true;
            }

            if (!string.IsNullOrEmpty(user.Email))
            {
                if (hasUpdates)
                {
                    commandText.Append(", ");
                }
                commandText.Append("\"Email\" = @Email");
                hasUpdates = true;
            }

            // If there's nothing to update, return false
            if (!hasUpdates)
            {
                return false;
            }

            // Add WHERE clause to the query
            commandText.Append(" WHERE \"Id\" = @Id;");

            using var command = new NpgsqlCommand(commandText.ToString(), connection);

            // Add the parameters only for non-empty fields
            if (!string.IsNullOrEmpty(user.Username))
            {
                command.Parameters.AddWithValue("@Username", user.Username);
            }

            if (!string.IsNullOrEmpty(user.Email))
            {
                command.Parameters.AddWithValue("@Email", user.Email);
            }

            // Add the Id parameter
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();

            // Execute the query and check if any row was affected
            var result = await command.ExecuteNonQueryAsync();

            connection.Close();

            // Return true if a row was affected
            return result > 0;
        }

    }
}
