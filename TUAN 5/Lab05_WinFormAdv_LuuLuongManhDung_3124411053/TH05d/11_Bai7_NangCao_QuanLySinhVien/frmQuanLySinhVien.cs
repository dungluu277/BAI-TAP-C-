using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace App;

public class frmQuanLySinhVien : Form
{
    private readonly TextBox txtMaLop = new TextBox { Location = new Point(90, 14), Width = 300 };
    private readonly TextBox txtMaSV = new TextBox { Location = new Point(90, 48), Width = 300 };
    private readonly TextBox txtHoTen = new TextBox { Location = new Point(90, 82), Width = 300 };
    private readonly MaskedTextBox mskNgaySinh = new MaskedTextBox { Location = new Point(90, 116), Width = 300, Mask = "00\\/00\\/0000", PromptChar = '_' };
    private readonly DataGridView dgv = new DataGridView
    {
        Location = new Point(12, 215), Size = new Size(378, 200), ReadOnly = true, AllowUserToAddRows = false,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    };

    public frmQuanLySinhVien()
    {
        Text = "Quản lý sinh viên";
        Font = new Font("Tahoma", 10);
        ClientSize = new Size(404, 430);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        string[] nhan = { "Mã lớp", "Mã sv", "Họ tên", "Ngày sinh" };
        for (int i = 0; i < nhan.Length; i++)
            Controls.Add(new Label { Text = nhan[i], AutoSize = true, Location = new Point(12, 18 + i * 34) });
        var btnThem = new Button { Text = "Thêm", Location = new Point(90, 160), Size = new Size(90, 34) };
        var btnXoa = new Button { Text = "Xóa", Location = new Point(190, 160), Size = new Size(90, 34) };
        var btnSua = new Button { Text = "Sửa", Location = new Point(290, 160), Size = new Size(90, 34) };
        btnThem.Click += btnThem_Click;
        btnXoa.Click += btnXoa_Click;
        btnSua.Click += btnSua_Click;
        Controls.AddRange(new Control[] { txtMaLop, txtMaSV, txtHoTen, mskNgaySinh, btnThem, btnXoa, btnSua, dgv });

        dgv.CellClick += (s, e) =>
        {
            if (e.RowIndex < 0) return;
            var c = dgv.Rows[e.RowIndex].Cells;
            txtMaSV.Text = c["MaSinhVien"].Value?.ToString();
            txtHoTen.Text = c["HoTen"].Value?.ToString();
            txtMaLop.Text = c["MaLop"].Value?.ToString();
            mskNgaySinh.Text = c["NgaySinh"].Value is DateTime d ? d.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : "";
        };
        Load += (s, e) => LoadGrid();
    }

    private void LoadGrid()
    {
        Db.Load(dgv, "SELECT MaSinhVien, HoTen, NgaySinh, MaLop FROM SinhVien ORDER BY MaSinhVien");
        if (dgv.Columns["NgaySinh"] != null) dgv.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
    }

    private static void Warn(string m) => MessageBox.Show(m, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

   
    private bool NgayRong => string.IsNullOrWhiteSpace(mskNgaySinh.Text.Replace("/", "").Replace("_", ""));

    
    private bool DocNgay(out DateTime ngay)
    {
        if (DateTime.TryParseExact(mskNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngay)) return true;
        Warn("Ngày sinh không hợp lệ (định dạng dd/MM/yyyy)!");
        mskNgaySinh.Focus();
        return false;
    }

    
    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!Check.Require((txtMaLop, "Mã lớp"), (txtMaSV, "Mã sinh viên"), (txtHoTen, "Tên sinh viên"))) return;
        if (NgayRong) { Warn("Ngày sinh không được để trống!"); mskNgaySinh.Focus(); return; }
        if (!DocNgay(out DateTime ngay)) return;

        if (Db.Run("INSERT INTO SinhVien(MaSinhVien, HoTen, NgaySinh, MaLop) VALUES(@ma, @ten, @ns, @lop)",
                   "Thêm sinh viên thành công!", "",
                   Db.P("@ma", txtMaSV.Text.Trim()), Db.P("@ten", txtHoTen.Text.Trim()), Db.P("@ns", ngay), Db.P("@lop", txtMaLop.Text.Trim())))
            LoadGrid();
    }

    
    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (!Check.Require((txtMaSV, "Mã sinh viên"), (txtHoTen, "Tên sinh viên"))) return;
        if (Db.Run("DELETE FROM SinhVien WHERE MaSinhVien = @ma AND HoTen = @ten", "Xóa sinh viên thành công!",
                   "Không có sinh viên nào trùng cả mã sinh viên và tên đã nhập.",
                   Db.P("@ma", txtMaSV.Text.Trim()), Db.P("@ten", txtHoTen.Text.Trim())))
            LoadGrid();
    }

    
    private void btnSua_Click(object sender, EventArgs e)
    {
        if (!Check.Require((txtMaSV, "Mã sinh viên"))) return;

        var sets = new List<string>();
        var ps = new List<SqlParameter> { Db.P("@ma", txtMaSV.Text.Trim()) };
        if (txtMaLop.Text.Trim() != "") { sets.Add("MaLop = @lop"); ps.Add(Db.P("@lop", txtMaLop.Text.Trim())); }
        if (txtHoTen.Text.Trim() != "") { sets.Add("HoTen = @ten"); ps.Add(Db.P("@ten", txtHoTen.Text.Trim())); }
        if (!NgayRong)
        {
            if (!DocNgay(out DateTime ngay)) return;
            sets.Add("NgaySinh = @ns"); ps.Add(Db.P("@ns", ngay));
        }
        if (sets.Count == 0) { Warn("Mã lớp, Tên sinh viên, Ngày sinh phải có ít nhất một trường có dữ liệu!"); return; }

        
        if (Db.Run($"UPDATE SinhVien SET {string.Join(", ", sets)} WHERE MaSinhVien = @ma", "Sửa sinh viên thành công!",
                   "Không tìm thấy sinh viên có mã đã nhập.", ps.ToArray()))
            LoadGrid();
    }
}
