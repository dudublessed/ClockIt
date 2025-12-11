using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.Extensions;

namespace ClockIt.src.Infrastructure.Data.Repositories
{
    public class PositionsRepository : IPositionsRepository
    {
        private readonly string _connectionString;
        private readonly IMainContext _context;

        public PositionsRepository(string connectionstring, IMainContext context)
        {
            _connectionString = connectionstring;
            _context = context;
        }

        public List<PositionsModel> GetEnterprisePositions()
        {
            var enterprisePositions = new List<PositionsModel>();

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
                            var position = new PositionsModel(
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
