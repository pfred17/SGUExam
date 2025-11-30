using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString =
    "Server=localhost;Database=SGUExam;User ID=root;Password=13376655;SslMode=Disabled;";


        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // ---------- Helpers ----------
        private static void AddParameters(MySqlCommand cmd, params MySqlParameter[] parameters)
        {
            if (parameters == null) return;
            cmd.Parameters.AddRange(parameters);
        }

        private static void AddParameters(MySqlCommand cmd, params DbParameter[] dbParameters)
        {
            if (dbParameters == null) return;

            foreach (var p in dbParameters)
            {
                // Nếu bản thân là MySqlParameter (hiếm khi xảy ra khi caller dùng MySql), ta cast luôn
                if (p is MySqlParameter mp)
                {
                    cmd.Parameters.Add(mp);
                    continue;
                }

                // Chuyển DbParameter (ví dụ SqlParameter) sang MySqlParameter
                var newParam = new MySqlParameter
                {
                    ParameterName = p.ParameterName,
                    Value = p.Value ?? DBNull.Value,
                    DbType = p.DbType,
                    Direction = p.Direction
                };

                // Copy kích thước nếu có
                try
                {
                    if (p.Size > 0)
                        newParam.Size = p.Size;
                }
                catch { /* một số DbParameter có thể không hỗ trợ Size - bỏ qua an toàn */ }

                cmd.Parameters.Add(newParam);
            }
        }

        // ---------- ExecuteQuery overloads ----------
        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    AddParameters(cmd, parameters);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static DataTable ExecuteQuery(string query, params DbParameter[] parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    AddParameters(cmd, parameters);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // ---------- ExecuteNonQuery overloads ----------
        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    AddParameters(cmd, parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int ExecuteNonQuery(string query, params DbParameter[] parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    AddParameters(cmd, parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                AddParameters(command, parameters);
                connection.Open();
                return command.ExecuteScalar();
            }
        }
    }
}
