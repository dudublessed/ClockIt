using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ClockIt.src.Shared.Extensions
{
    public static class DataReaderExtensions
    {
        public static int GetInt32Safe(this NpgsqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? 0 : reader.GetInt32(index);
        }

        public static Guid GetGuidSafe(this NpgsqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? Guid.Empty : reader.GetGuid(index);
        }

        public static string GetStringSafe(this NpgsqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? string.Empty : reader.GetString(index);
        }

        public static DateTime GetDateTimeSafe(this NpgsqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? DateTime.MinValue : reader.GetDateTime(index);
        }

        public static DateTimeOffset GetDateTimeOffsetSafe(this NpgsqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? DateTimeOffset.MinValue : reader.GetDateTime(index);
        }

        public static TimeSpan GetTimeSpanSafe(this NpgsqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? TimeSpan.MinValue : reader.GetTimeSpan(index);
        }
    }
}
