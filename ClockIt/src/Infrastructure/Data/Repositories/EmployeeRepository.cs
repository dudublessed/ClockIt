using ClockIt.src.ApplicationLayer.Context;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.Core.Domain.BOs;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.EmployeeDTOs;
using ClockIt.src.Shared.Extensions;
using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Infrastructure.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;
        private readonly IUserLoggedContext _userContext;

        public EmployeeRepository(string connectionString, IUserLoggedContext userContext)
        {
            _connectionString = connectionString;
            _userContext = userContext;
        }

        public async Task RegisterEmployee(EmployeeDTO employee)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"INSERT INTO tb_employees 
                                    (user_id, 
                                    full_name, 
                                    cpf,
                                    birth_date, 
                                    email, 
                                    position_id) 
                                 VALUES 
                                    (@user_id,
                                    @full_name,
                                    @cpf,
                                    @birth_date,
                                    @email,
                                    @position_id)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@user_id", NpgsqlDbType.Integer).Value = employee.UserId;
                    cmd.Parameters.Add("@full_name", NpgsqlDbType.Varchar).Value = employee.FullName;
                    cmd.Parameters.Add("@cpf", NpgsqlDbType.Varchar).Value = employee.CPF;
                    cmd.Parameters.Add("@birth_date", NpgsqlDbType.Date).Value = employee.BirthDate.Date;
                    cmd.Parameters.Add("@email", NpgsqlDbType.Varchar).Value = employee.Email.Value;
                    cmd.Parameters.Add("@position_id", NpgsqlDbType.Integer).Value = employee.PositionId;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public async Task<EmployeeModel> GetEmployeeByUserId(int userId)
        {
            EmployeeModel employee = null;

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"SELECT 
                                     te.*
                                FROM
                                    tb_employees AS te
                                WHERE
                                    te.user_id = @user_id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@user_id", NpgsqlDbType.Integer).Value = userId;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new EmployeeModel(
                                reader.GetInt32Safe("id"),
                                reader.GetInt32Safe("user_id"),
                                reader.GetStringSafe("full_name"),
                                reader.GetStringSafe("cpf"),
                                reader.GetDateTimeSafe("birth_date"),
                                reader.GetStringSafe("email"),
                                reader.GetInt32Safe("position_id")
                            );
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
            }

            return employee;
        }

        public async Task<EmployeeModel> GetEmployeeByUserContext()
        {
            EmployeeModel employee = null;

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"SELECT 
                                     te.*
                                FROM
                                    tb_employees AS te
                                WHERE
                                    te.user_id = @user_id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@user_id", NpgsqlDbType.Integer).Value = _userContext.User.Id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new EmployeeModel(
                                reader.GetInt32Safe("id"),
                                reader.GetInt32Safe("user_id"),
                                reader.GetStringSafe("full_name"),
                                reader.GetStringSafe("cpf"),
                                reader.GetDateTimeSafe("birth_date"),
                                reader.GetStringSafe("email"),
                                reader.GetInt32Safe("position_id")
                            );
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
            }

            return employee;
        }
    }
}
