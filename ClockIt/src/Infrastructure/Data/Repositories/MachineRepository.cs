using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.MachineDTOs;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.Extensions;

namespace ClockIt.src.Infrastructure.Data.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly string _connectionString;

        public MachineRepository(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public async Task<MachineModel> GetMachineByGuid(Guid guid)
        {
            MachineModel machine = null;

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = "SELECT * FROM tb_machines WHERE guid = @guid";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("guid", NpgsqlDbType.Uuid).Value = guid;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            machine = new MachineModel(
                                reader.GetInt32Safe("id"),
                                reader.GetGuidSafe("guid"),
                                reader.GetInt32Safe("enterprise_id")

                            );
                        }
                    }
                }
            }

            return machine;
        }

        public async Task AddMachine(MachineRegisterDTO machine)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = "INSERT INTO tb_machines (guid, enterprise_id) VALUES (@guid, @enterprise_id)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("guid", NpgsqlDbType.Uuid).Value = machine.Guid;
                    cmd.Parameters.Add("enterprise_id", NpgsqlDbType.Integer).Value = machine.EnterpriseId;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public async Task<bool> IsMachineRegistered(Guid guid)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"SELECT 
                                    1 
                                 FROM 
                                    tb_machines AS tm
                                 WHERE 
                                    tm.guid = @guid";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("guid", NpgsqlDbType.Uuid).Value = guid;

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
