using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.PositionDTOs;
using ClockIt.src.Shared.Extensions;
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
    public class PositionRepository : IPositionRepository
    {
        private readonly string _connectionString;
        private readonly IMainContext _context;

        public PositionRepository(string connectionstring, IMainContext context)
        {
            _connectionString = connectionstring;
            _context = context;
        }

        public async Task RegisterPosition(PositionDTO position)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"INSERT INTO tb_positions 
                                    (name,
                                    description,
                                    enterprise_id) 
                                 VALUES 
                                    (@name,
                                    @description,
                                    @enterprise_id)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@name", NpgsqlDbType.Varchar).Value = position.Name;
                    cmd.Parameters.Add("@description", NpgsqlDbType.Varchar).Value = position.Description;
                    cmd.Parameters.Add("@enterprise_id", NpgsqlDbType.Integer).Value = position.EnterpriseId;

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public List<PositionModel> GetEnterprisePositions()
        {
            var enterprisePositions = new List<PositionModel>();

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM tb_positions WHERE enterprise_id = @enterprise_id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("enterprise_id", NpgsqlDbType.Integer).Value = _context.Enterprise.Id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var position = new PositionModel(
                                reader.GetInt32Safe("id"),
                                reader.GetStringSafe("name"),
                                reader.GetStringSafe("description"),
                                reader.GetInt32Safe("enterprise_id")

                            );

                            enterprisePositions.Add(position);
                        }
                    }
                }
            }


            return enterprisePositions;
        }
    }
}
