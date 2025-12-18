using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.EmployeeDTOs.ScheduleDTOs;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Infrastructure.Data.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly string _connectionString;

        public ScheduleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void RegisterEmployeeSchedule(ScheduleDTO schedule)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO tb_schedule 
                                    (employee_id, 
                                    entry_time, 
                                    lunch_entry_time,
                                    lunch_exit_time, 
                                    exit_time, 
                                    created_at, 
                                    active) 
                                 VALUES 
                                    (@employee_id,
                                    @entry_time,
                                    @lunch_entry_time,
                                    @lunch_exit_time,
                                    @exit_time,
                                    @created_at,
                                    @active)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@employee_id", NpgsqlDbType.Integer).Value = schedule.EmployeeId;
                    cmd.Parameters.Add("@entry_time", NpgsqlDbType.Time).Value = schedule.EntryTime.TimeOfDay;
                    cmd.Parameters.Add("@lunch_entry_time", NpgsqlDbType.Time).Value = schedule.LunchEntryTime.TimeOfDay;
                    cmd.Parameters.Add("@lunch_exit_time", NpgsqlDbType.Time).Value = schedule.LunchExitTime.TimeOfDay;
                    cmd.Parameters.Add("@exit_time", NpgsqlDbType.Time).Value = schedule.ExitTime.TimeOfDay;
                    cmd.Parameters.Add("@created_at", NpgsqlDbType.TimestampTz).Value = schedule.CreatedAt.UtcDateTime;
                    cmd.Parameters.Add("@active", NpgsqlDbType.Boolean).Value = schedule.Active;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
