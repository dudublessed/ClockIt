using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.AttendanceDTOs.RecordDTOs;
using ClockIt.src.Shared.Extensions;
using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Infrastructure.Data.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly string _connectionString;
        private readonly IEmployeeLoggedContext _employeeContext;

        public RecordRepository(string connectionString, IEmployeeLoggedContext employeeContext)
        {
            _connectionString = connectionString;
            _employeeContext = employeeContext;
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
                    cmd.Parameters.Add("@recorded_at", NpgsqlDbType.TimestampTz).Value = record.RecordedAt.UtcDateTime;
                    cmd.Parameters.Add("@record_hour", NpgsqlDbType.Time).Value = record.RecordHour;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<RecordDTO> GetEmployeeTodayRecords(int attendanceId)
        {
            List<RecordDTO>? records = new List<RecordDTO>();

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"SELECT 
	                                tr.*
                                FROM tb_record AS tr 
                                WHERE 
	                                tr.attendance_id = @attendance_id
	                                AND tr.employee_id = @employee_id
                                ORDER BY 
	                                tr.record_type";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@attendance_id", NpgsqlDbType.Integer).Value = attendanceId;
                    cmd.Parameters.Add("@employee_id", NpgsqlDbType.Integer).Value = _employeeContext.Employee.Id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var record = new RecordDTO(
                                reader.GetInt32Safe("attendance_id"),
                                reader.GetInt32Safe("employee_id"),
                                reader.GetStringSafe("record_type"),
                                reader.GetDateTimeOffsetSafe("recorded_at"),
                                reader.GetTimeSpanSafe("record_hour")
                            );

                            records.Add(record);
                        }
                    }
                }
            }

            return records;
        }

        public bool EmployeeHasRegisteredAllTodayRecords(int attendanceId)
        {
            bool employeeHasRegisteredAllTodayRecords = false;

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"SELECT 
                                    EXISTS (
                                        SELECT 1 FROM tb_record 
                                        WHERE attendance_id = @attendance_id 
                                          AND employee_id = @employee_id 
                                          AND record_type = 'entry'
                                    )
                                    AND EXISTS (
                                        SELECT 1 FROM tb_record 
                                        WHERE attendance_id = @attendance_id 
                                          AND employee_id = @employee_id 
                                          AND record_type = 'lunch_entry'
                                    )
	                                AND EXISTS (
	                                        SELECT 1 FROM tb_record 
	                                        WHERE attendance_id = @attendance_id 
	                                          AND employee_id = @employee_id 
	                                          AND record_type = 'lunch_exit'
	                                    )
	                                AND EXISTS (
	                                        SELECT 1 FROM tb_record 
	                                        WHERE attendance_id = @attendance_id 
	                                          AND employee_id = @employee_id 
	                                          AND record_type = 'exit'
	                                    )AS employee_registered_all_today_records;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@attendance_id", NpgsqlDbType.Integer).Value = attendanceId;
                    cmd.Parameters.Add("@employee_id", NpgsqlDbType.Integer).Value = _employeeContext.Employee.Id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employeeHasRegisteredAllTodayRecords = reader.GetBoolean("employee_registered_all_today_records");
                        }
                    }
                }
            }

            return employeeHasRegisteredAllTodayRecords;
        }
    }
}
