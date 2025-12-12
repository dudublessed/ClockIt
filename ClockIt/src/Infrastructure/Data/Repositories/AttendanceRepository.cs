using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.Core.Domain.BOs;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.AttendanceDTOs;
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
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly string _connectionString;
        private readonly IEmployeeLoggedContext _employeeContext;

        public AttendanceRepository(string connectionString, IEmployeeLoggedContext employeeContext) 
        { 
            _connectionString = connectionString;
        }

        public void RegisterTodayAttendance(DailyAttendanceDTO dailyAttendance)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = "INSERT INTO tb_attendance (employee_id, record_date) VALUES (@employee_id, @record_date)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("employee_id", NpgsqlDbType.Integer).Value = dailyAttendance.EmployeeId;
                    cmd.Parameters.Add("record_date", NpgsqlDbType.Date).Value = dailyAttendance.Date;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AttendanceModel GetEmployeeTodayAttendance()
        {
            AttendanceModel employeeTodayAttendance = null;

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"SELECT 
                                     ta.id,
                                     ta.employee_id,
                                     ta.record_date
                                 FROM 
                                     tb_attendance AS ta
                                 WHERE 
                                     ta.employee_id = @employee_id 
                                     AND ta.record_date = @record_date";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("employee_id", NpgsqlDbType.Integer).Value = _employeeContext.Employee.Id;
                    cmd.Parameters.Add("record_date", NpgsqlDbType.Date).Value = DateTime.Now.Date;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employeeTodayAttendance = new AttendanceModel(
                                reader.GetInt32Safe("id"),
                                reader.GetInt32Safe("employee_id"),
                                reader.GetDateTimeSafe("record_date")
                            );
                        }
                    }
                }
            }

            return employeeTodayAttendance;
        }

        public bool EmployeeHasRegisteredTodayAttendance()
        {
            bool employeeRegisteredTodayAttendance = false;

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"SELECT 
                                     1
                                 FROM 
                                     tb_attendance AS ta
                                 WHERE 
                                     ta.employee_id = @employee_id 
                                     AND ta.record_date = @record_date";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add("employee_id", NpgsqlDbType.Integer).Value = _employeeContext.Employee.Id;
                    cmd.Parameters.Add("record_date", NpgsqlDbType.Date).Value = DateTime.Now.Date;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employeeRegisteredTodayAttendance = true;
                        }
                    }
                }
            }

            return employeeRegisteredTodayAttendance;
        }
    }
}
