using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using ClockIt.src.Shared.DTOs.EnterpriseDTOs;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.Extensions;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Core.Domain.ValueObjects;

namespace ClockIt.src.Infrastructure.Data.Repositories
{
    class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly string _connectionString;

        public EnterpriseRepository(string connectionString) { 
            _connectionString = connectionString;
        }

        public async Task<int> RegisterEnterprise(EnterpriseRegisterDTO enterprise)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = "INSERT INTO tb_enterprises (enterprise_name, enterprise_email, enterprise_country, enterprise_state, enterprise_city) VALUES (@Name, @Email, @Country, @State, @City) RETURNING id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("Name", NpgsqlDbType.Varchar).Value = enterprise.Name.ToUpper();
                    cmd.Parameters.Add("Email", NpgsqlDbType.Varchar).Value = enterprise.Email.Value;
                    cmd.Parameters.Add("Country", NpgsqlDbType.Varchar).Value = enterprise.Location.Country;
                    cmd.Parameters.Add("State", NpgsqlDbType.Varchar).Value = enterprise.Location.State;
                    cmd.Parameters.Add("City", NpgsqlDbType.Varchar).Value = enterprise.Location.City;

                    int generatedEnterpriseId = Convert.ToInt32(cmd.ExecuteScalar());

                    return generatedEnterpriseId;
                }
            }
        }

        public async Task<EnterpriseModel> GetEnterpriseById(int id)
        {
            EnterpriseModel? enterprise = null;

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = "SELECT * FROM tb_enterprises WHERE id = @id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Email email = new Email(reader.GetStringSafe("enterprise_email"));

                            var country = reader.GetStringSafe("enterprise_country");
                            var state = reader.GetStringSafe("enterprise_state");
                            var city = reader.GetStringSafe("enterprise_city");

                            Location location = new Location(country, state, city);

                            enterprise = new EnterpriseModel
                            (
                                reader.GetInt32Safe("id"),
                                reader.GetStringSafe("enterprise_name"),
                                email,
                                location
                            );
                        }
                    }
                }
            }

            return enterprise!;
        }

        public async Task<int> GetEnterpriseIdByName(string enterpriseName)
        {
            int enterpriseId = 0;

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = "SELECT id FROM tb_enterprises WHERE enterprise_name = @enterprise_name";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@enterprise_name", enterpriseName);
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            enterpriseId = reader.GetInt32Safe("id");
                        }
                    }
                }
            }

            return enterpriseId;
        }


        public async Task<string> GetEnterpriseNameById(int enterpriseId)
        {
            string enterpriseName = "";

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = "SELECT enterprise_name FROM tb_enterprises WHERE id = @id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", enterpriseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            enterpriseName = reader.GetStringSafe("enterprise_name");
                        }
                    }
                }
            }

            return enterpriseName;
        }

        public async Task<bool> ExistsEnterprise(EnterpriseRegisterDTO enterprise)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"SELECT 
                                    1 
                                 FROM 
                                    tb_enterprises AS te 
                                 WHERE 
                                    te.enterprise_name = @enterprise_name
                                 AND
                                    te.enterprise_email = @enterprise_email
                                 AND
                                    te.enterprise_country = @enterprise_country
                                 AND
                                    te.enterprise_state = @enterprise_state
                                 AND
                                    te.enterprise_city = @enterprise_city
                                 LIMIT 1";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("enterprise_name", enterprise.Name);
                    cmd.Parameters.AddWithValue("enterprise_email", enterprise.Email.Value);
                    cmd.Parameters.AddWithValue("enterprise_country", enterprise.Location.Country);
                    cmd.Parameters.AddWithValue("enterprise_state", enterprise.Location.State);
                    cmd.Parameters.AddWithValue("enterprise_city", enterprise.Location.City);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
