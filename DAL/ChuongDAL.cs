using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ChuongDAL
    {
        public List<ChuongDTO> GetAllChuong()
        {
            List<ChuongDTO> list = new List<ChuongDTO>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT ma_chuong, ten_chuong, ma mon hoc FROM chuong";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new ChuongDTO
                    {
                        MaChuong = reader.GetInt64(0),
                        TenChuong = reader.GetString(1),
                        MaMonHoc = reader.GetInt64(2)
                    });
                }
                return list;
            }
        }

        public void AddRandomChuongForMonHoc(long maMonHoc)
        {

            string[] templates = new[]
            {
                "Giới thiệu môn học và mục tiêu học tập",
                "Các khái niệm cơ bản trong chương trình học",
                "Tổng quan lý thuyết trọng tâm",
                "Ứng dụng thực tiễn của kiến thức",
                "Bài tập và câu hỏi ôn tập"
            };

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                var random = new Random();
                for (int i = 0; i < 3; i++)
                {
                    string noiDung = templates[random.Next(templates.Length)];

                    string query = "INSERT INTO chuong (ten_chuong, ma_mh) VALUES (@ten_chuong, @ma_mh)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ten_chuong", noiDung);
                        cmd.Parameters.AddWithValue("@ma_mh", maMonHoc);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
