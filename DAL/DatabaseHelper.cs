using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = "Data Source=LG3636\\SQLEXPRESS;Initial Catalog=SGUExam;Integrated Security=True;TrustServerCertificate=True";

        // Explicit return type to avoid ambiguity
        public static Microsoft.Data.SqlClient.SqlConnection GetConnection()
        {
            return new Microsoft.Data.SqlClient.SqlConnection(connectionString);
        }

        // Dùng khi cần SELECT
        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Thực thi truy vấn không trả về dữ liệu (INSERT, UPDATE, DELETE, ...)
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        // Dùng cho truy vấn trả về 1 giá trị (vd: ID mới, COUNT, MAX...)
        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }
    }
}