using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App;


internal static class Db
{
    public const string ConnectionString = @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True";

    public static SqlParameter P(string name, object value) => new SqlParameter(name, value ?? DBNull.Value);

    public static DataTable Query(string sql, params SqlParameter[] ps)
    {
        var table = new DataTable();
        using var da = new SqlDataAdapter(sql, ConnectionString);
        da.SelectCommand.Parameters.AddRange(ps);
        da.Fill(table);
        return table;
    }

    public static bool Run(string sql, string thanhCong, string khongTimThay, params SqlParameter[] ps)
    {
        try
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(ps);
            conn.Open();
            int n = cmd.ExecuteNonQuery();                
            if (n == 0) { MessageBox.Show(khongTimThay, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            MessageBox.Show(thanhCong, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        catch (SqlException ex)
        {
            MessageBox.Show(Explain(ex), "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    public static string Explain(SqlException ex) => ex.Number switch
    {
        2627 or 2601 => "Dữ liệu đã tồn tại (trùng khóa chính).",
        547 => "Vi phạm ràng buộc khóa ngoại: mã tham chiếu không tồn tại hoặc dữ liệu đang được sử dụng.",
        _ => "Lỗi cơ sở dữ liệu: " + ex.Message + "\n\n(Kiểm tra lại chuỗi kết nối trong Db.cs và đã chạy SQL/QLSinhVien.sql chưa.)"
    };

    public static void Load(DataGridView dgv, string sql)
    {
        try { dgv.DataSource = Query(sql); }
        catch (SqlException ex) { MessageBox.Show(Explain(ex), "Không đọc được dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
}

internal static class Check
{
    public static bool Require(params (Control box, string name)[] fields)
    {
        foreach (var (box, name) in fields)
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                MessageBox.Show($"{name} không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }
        return true;
    }
}
