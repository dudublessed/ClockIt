using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.UserDTOs;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.Extensions;

namespace ClockIt.src.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public void AddUser(UserRegisterDTO user)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = "INSERT INTO tb_users (username, login, user_password, user_type, enterprise_id) VALUES (@username, @login, @user_password, @user_type, @enterprise_id)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("username", NpgsqlDbType.Varchar).Value = user.UserName;
                    cmd.Parameters.Add("login", NpgsqlDbType.Varchar).Value = user.Login;
                    cmd.Parameters.Add("user_password", NpgsqlDbType.Varchar).Value = user.Password.Value;
                    cmd.Parameters.Add("user_type", NpgsqlDbType.Varchar).Value = user.Type.ToString();
                    cmd.Parameters.Add("enterprise_id", NpgsqlDbType.Integer).Value = user.EnterpriseId;

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public string GetAdminPasswordByEnterpriseId(int enterpriseId)
        {
            string adminPassword = "";

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"SELECT 
                                    user_password 
                                FROM 
                                    tb_users 
                                WHERE 
                                    login = 'ADMIN' 
                                AND enterprise_id = @enterprise_id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@enterprise_id", enterpriseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            adminPassword = reader.GetStringSafe("user_password");
                        }
                    }
                }
            }

            return adminPassword;
        }

        public void UpdateAdminPassword(UpdateAdminPasswordDTO credentials)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = "UPDATE tb_users SET user_password = @user_password WHERE login = @login";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("login", NpgsqlDbType.Varchar).Value = credentials.Login;
                    cmd.Parameters.Add("user_password", NpgsqlDbType.Varchar).Value = credentials.Password.Value;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<ShowUsersDTO> GetUsersByEnterpriseId(int enterpriseId)
        {
            var users = new List<ShowUsersDTO>();

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM tb_users WHERE enterprise_id = @enterpriseId";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@enterpriseId", enterpriseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new ShowUsersDTO(
                                reader.GetInt32Safe("id"),
                                reader.GetStringSafe("username"),
                                reader.GetStringSafe("login")
                            );

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public string GetPasswordHashByLoginAndEnterpriseId(string login, int enterpriseId)
        {
            string userPassword = "";

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"SELECT 
                                    user_password 
                                FROM 
                                    tb_users 
                                WHERE 
                                    login = @login 
                                AND enterprise_id = @enterprise_id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@enterprise_id", enterpriseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userPassword = reader.GetStringSafe("user_password");
                        }
                    }
                }
            }

            return userPassword;
        }
    }
}
