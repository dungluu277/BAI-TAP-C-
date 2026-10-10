using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace App;

public class frmQuanLyDiem : Form
{
    private readonly TextBox txtMaSV = new TextBox { Location = new Point(90, 14), Width = 300 };
    private readonly TextBox txtMaMH = new TextBox { Location = new Point(90, 48), Width = 300 };
    private readonly TextBox txtDiem = new TextBox { Location = new Point(90, 82), Width = 300 };
    private readonly DataGridView dgv = new DataGridView
    {
        Location = new Point(12, 175), Size = new Size(378, 190), ReadOnly = true, AllowUserToAddRows = false,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    };

    public frmQuanLyDiem()
    {
        Text = "Quản lý Điểm";
        Font = new Font("Tahoma", 10);
        ClientSize = new Size(404, 380);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        string[] nhan = { "Mã sv", "Mã mh", "Điểm" };
        for (int i = 0; i < nhan.Length; i++)
            Controls.Add(new Label { Text = nhan[i], AutoSize = true, Location = new Point(12, 18 + i * 34) });
        var btnThem = new Button { Text = "Thêm", Location = new Point(90, 124), Size = new Size(90, 34) };
        var btnXoa = new Button { Text = "Xóa", Location = new Point(190, 124), Size = new Size(90, 34) };
        var btnSua = new Button { Text = "Sửa", Location = new Point(290, 124), Size = new Size(90, 34) };
        btnThem.Click += btnThem_Click;
        btnXoa.Click += btnXoa_Click;
        btnSua.Click += btnSua_Click;
        Controls.AddRange(new Control[] { txtMaSV, txtMaMH, txtDiem, btnThem, btnXoa, btnSua, dgv });

        dgv.CellClick += (s, e) =>
        {
            if (e.RowIndex < 0) return;
            var c = dgv.Rows[e.RowIndex].Cells;
            txtMaSV.Text = c["MaSinhVien"].Value?.ToString();
            txtMaMH.Text = c["MaMonHoc"].Value?.ToString();
            txtDiem.Text = Convert.ToDouble(c["Diem"].Value, CultureInfo.InvariantCulture).ToString("0.##", CultureInfo.CurrentCulture);
        };
        Load += (s, e) => LoadGrid();
    }

    private void LoadGrid() => Db.Load(dgv, "SELECT MaSinhVien, MaMonHoc, Diem FROM Diem ORDER BY MaSinhVien, MaMonHoc");

    private bool DocDiem(out double diem)
    {
        string s = txtDiem.Text.Trim();
        bool ok = double.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out diem)
               || double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out diem);
        if (!ok || diem < 0 || diem > 10)
        {
            MessageBox.Show("Điểm phải là số từ 0 đến 10!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDiem.SelectAll(); txtDiem.Focus();
            return false;
        }
        return true;
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!Check.Require((txtMaSV, "Mã sinh viên"), (txtMaMH, "Mã môn học"), (txtDiem, "Điểm"))) return;
        if (!DocDiem(out double diem)) return;
        if (Db.Run("INSERT INTO Diem(MaSinhVien, MaMonHoc, Diem) VALUES(@sv, @mh, @d)", "Thêm điểm thành công!", "",
                   Db.P("@sv", txtMaSV.Text.Trim()), Db.P("@mh", txtMaMH.Text.Trim()), Db.P("@d", diem)))
            LoadGrid();
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (!Check.Require((txtMaSV, "Mã sinh viên"), (txtMaMH, "Mã môn học"))) return;
        if (Db.Run("DELETE FROM Diem WHERE MaSinhVien = @sv AND MaMonHoc = @mh", "Xóa điểm thành công!",
                   "Không tìm thấy điểm của sinh viên này ở môn học đã nhập.",
                   Db.P("@sv", txtMaSV.Text.Trim()), Db.P("@mh", txtMaMH.Text.Trim())))
            LoadGrid();
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (!Check.Require((txtMaSV, "Mã sinh viên"), (txtMaMH, "Mã môn học"), (txtDiem, "Điểm"))) return;
        if (!DocDiem(out double diem)) return;
        if (Db.Run("UPDATE Diem SET Diem = @d WHERE MaSinhVien = @sv AND MaMonHoc = @mh", "Sửa điểm thành công!",
                   "Không tìm thấy điểm của sinh viên này ở môn học đã nhập.",
                   Db.P("@d", diem), Db.P("@sv", txtMaSV.Text.Trim()), Db.P("@mh", txtMaMH.Text.Trim())))
            LoadGrid();
    }
}
