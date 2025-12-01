using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public static class DatabaseHelper
    {
        //public static readonly string connectionString =
        //     "Data Source=DESKTOP-VNR8V8P\\DUYPHONG;" +
        //     "Initial Catalog=SGUExam2;Integrated Security=SSPI;" +
        //     "TrustServerCertificate=True;";

        private static readonly string connectionString =
    "Data Source = MSI\\SQLEXPRESS;Initial Catalog = SGUExam; User ID = sa; Password=kaka3135134162;Trust Server Certificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Dùng khi cần SELECT
        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Thực thi truy vấn không trả về dữ liệu (INSERT, UPDATE, DELETE, ...)
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        // Dùng cho truy vấn trả về 1 giá trị (vd: ID mới, COUNT, MAX...)
        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();
            using SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar();
        }
    }
}
