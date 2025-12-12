using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.AttendanceDTOs.RecordDTOs;
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
    public class RecordRepository : IRecordRepository
    {
        private readonly string _connectionString;

        public RecordRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void RegisterRecord(RecordDTO record)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO tb_record 
                                    (attendance_id,
                                    employee_id,
                                    record_type,
                                    recorded_at,    
                                    record_hour) 
                                 VALUES 
                                    (@attendance_id,
                                    @employee_id,
                                    @record_type,
                                    @recorded_at,    
                                    @record_hour)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@attendance_id", NpgsqlDbType.Integer).Value = record.AttendanceId;
                    cmd.Parameters.Add("@employee_id", NpgsqlDbType.Integer).Value = record.EmployeeId;
                    var pRecordType = new NpgsqlParameter("record_type", NpgsqlDbType.Unknown)
                    {
                        Value = record.RecordType,
                        DataTypeName = "public.record_type" 
                    };
                    cmd.Parameters.Add(pRecordType);
                    cmd.Parameters.Add("@recorded_at", NpgsqlDbType.TimestampTz).Value = record.RecordedAt.DateTime;
                    cmd.Parameters.Add("@record_hour", NpgsqlDbType.Time).Value = record.RecordHour.TimeOfDay;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<RecordDTO> GetEmployeeTodayRecords()
        {
            throw new NotImplementedException();
        }

        public bool EmployeeHasRegisteredAllTodayRecords(int attendanceId)
        {
            throw new NotImplementedException();
        }
    }
}
