using System;
using System.Data;
using System.Linq;

public static class BangDiemHelper
{
    public static DataTable PivotBangDiem(DataTable dtNguon)
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("MSSV", typeof(string));
        dt.Columns.Add("Họ tên", typeof(string));

        var dsDe = dtNguon.AsEnumerable()
            .Where(r => r["ten_de"] != DBNull.Value)
            .Select(r => r["ten_de"].ToString())
            .Distinct()
            .ToList();

        foreach (var de in dsDe)
            dt.Columns.Add(de, typeof(double));

        dt.Columns.Add("Điểm TB", typeof(double));

        var svGroup = dtNguon.AsEnumerable()
            .GroupBy(r => new
            {
                MSSV = r["MSSV"]?.ToString(),
                HoTen = r["ho_ten"]?.ToString()
            });

        foreach (var sv in svGroup)
        {
            DataRow row = dt.NewRow();
            row["MSSV"] = sv.Key.MSSV;
            row["Họ tên"] = sv.Key.HoTen;

            double tong = 0;
            int dem = 0;

            foreach (var de in dsDe)
            {
                var record = sv.FirstOrDefault(r => r["ten_de"].ToString() == de);

                if (record != null && record["diem"] != DBNull.Value)
                {
                    double diem = Convert.ToDouble(record["diem"]);
                    row[de] = diem;
                    tong += diem;
                    dem++;
                }
                else
                {
                    row[de] = DBNull.Value;
                }
            }

            row["Điểm TB"] = dem > 0 ? Math.Round(tong / dem, 2) : DBNull.Value;
            dt.Rows.Add(row);
        }

        return dt;
    }
}

