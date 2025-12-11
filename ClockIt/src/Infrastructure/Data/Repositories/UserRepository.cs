using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.UserDTOs;
using ClockIt.src.Shared.Extensions;

namespace ClockIt.src.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMainContext _context;

        private readonly string _connectionString;

        public UserRepository(IMainContext context, string connectionstring)
        {
            _context = context;
            _connectionString = connectionstring;
        }

        public void RegisterUser(UserDTO user)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = "INSERT INTO tb_users (username, login, user_password, user_type, enterprise_id) VALUES (@username, @login, @user_password, @user_type, @enterprise_id)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@username", NpgsqlDbType.Varchar).Value = user.UserName;
                    cmd.Parameters.Add("@login", NpgsqlDbType.Varchar).Value = user.Login;
                    cmd.Parameters.Add("@user_password", NpgsqlDbType.Varchar).Value = user.Password.Value;
                    cmd.Parameters.Add("@user_type", NpgsqlDbType.Varchar).Value = user.Type.ToString();
                    cmd.Parameters.Add("@enterprise_id", NpgsqlDbType.Integer).Value = user.EnterpriseId;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool IsUserRegistered(UserDTO user)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"SELECT 
                                    true
                                 FROM tb_users 
                                 WHERE 
	                                username = @username
	                                AND login = @login
	                                AND user_type = @user_type
	                                AND enterprise_id = @enterprise_id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@username", NpgsqlDbType.Varchar).Value = user.UserName;
                    cmd.Parameters.Add("@login", NpgsqlDbType.Varchar).Value = user.Login;
                    cmd.Parameters.Add("@user_type", NpgsqlDbType.Varchar).Value = user.Type.ToString();
                    cmd.Parameters.Add("@enterprise_id", NpgsqlDbType.Integer).Value = user.EnterpriseId;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) return true;
                    }
                }
            }

            return false;
        }

        public void UpdateAdminPassword(UpdateAdminPasswordDTO credentials)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = "UPDATE tb_users SET user_password = @user_password WHERE login = @login";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@login", NpgsqlDbType.Varchar).Value = credentials.Login;
                    cmd.Parameters.Add("@user_password", NpgsqlDbType.Varchar).Value = credentials.Password.Value;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string GetEnterpriseAdminPassword()
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
                    cmd.Parameters.Add("@enterprise_id", NpgsqlDbType.Integer).Value = _context.Enterprise.Id;

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

        public List<ShowUsersDTO> GetEnterpriseUsers()
        {
            var users = new List<ShowUsersDTO>();

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM tb_users WHERE enterprise_id = @enterprise_id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@enterprise_id", NpgsqlDbType.Integer).Value = _context.Enterprise.Id;

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

        public List<ShowUsersDTO> GetEnterpriseEmployeeUsers()
        {
            var employeeUsers = new List<ShowUsersDTO>();

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"SELECT 
                                    tu.* 
                                FROM tb_users AS tu 
                                WHERE 
                                    tu.login = 'ADMIN'

                                UNION ALL

                                SELECT 
	                                tu.* 
                                FROM tb_users AS tu 
                                INNER JOIN tb_employees AS te ON te.user_id = tu.id 
                                WHERE 
	                                tu.enterprise_id = @enterprise_id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@enterprise_id", NpgsqlDbType.Integer).Value = _context.Enterprise.Id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new ShowUsersDTO(
                                reader.GetInt32Safe("id"),
                                reader.GetStringSafe("username"),
                                reader.GetStringSafe("login")
                            );

                            employeeUsers.Add(user);
                        }
                    }
                }
            }

            return employeeUsers;
        }

        public List<ShowUsersDTO> GetNotEmployeeUsers()
        {
            var notEmployeeUsers = new List<ShowUsersDTO>();

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"SELECT 
	                                tu.* 
                                FROM tb_users AS tu 
                                LEFT JOIN tb_employees AS te ON te.user_id = tu.id 
                                WHERE 
	                                tu.enterprise_id = @enterprise_id 
	                                AND te.id IS NULL 
	                                AND NOT tu.login = 'ADMIN'";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@enterprise_id", NpgsqlDbType.Integer).Value = _context.Enterprise.Id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new ShowUsersDTO(
                                reader.GetInt32Safe("id"),
                                reader.GetStringSafe("username"),
                                reader.GetStringSafe("login")
                            );

                            notEmployeeUsers.Add(user);
                        }
                    }
                }
            }

            return notEmployeeUsers;
        }

        public string GetUserHashPasswordByLogin(string login)
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
                    cmd.Parameters.Add("@login", NpgsqlDbType.Varchar).Value = login;
                    cmd.Parameters.Add("@enterprise_id", NpgsqlDbType.Integer).Value = _context.Enterprise.Id;

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
