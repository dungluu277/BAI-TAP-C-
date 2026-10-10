using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App;

public class frmLop : Form
{
    private readonly TextBox txtMaKhoa = new TextBox { Location = new Point(90, 14), Width = 300 };
    private readonly TextBox txtMaLop = new TextBox { Location = new Point(90, 48), Width = 300 };
    private readonly TextBox txtTenLop = new TextBox { Location = new Point(90, 82), Width = 300 };
    private readonly DataGridView dgv = new DataGridView
    {
        Location = new Point(12, 175), Size = new Size(378, 190), ReadOnly = true, AllowUserToAddRows = false,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    };

    public frmLop()
    {
        Text = "frmLop";
        Font = new Font("Tahoma", 10);
        ClientSize = new Size(404, 380);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        string[] nhan = { "Mã khoa", "Mã lớp", "Tên lớp" };
        for (int i = 0; i < nhan.Length; i++)
            Controls.Add(new Label { Text = nhan[i], AutoSize = true, Location = new Point(12, 18 + i * 34) });
        var btnThem = new Button { Text = "Thêm", Location = new Point(90, 124), Size = new Size(90, 34) };
        var btnXoa = new Button { Text = "Xóa", Location = new Point(190, 124), Size = new Size(90, 34) };
        var btnSua = new Button { Text = "Sửa", Location = new Point(290, 124), Size = new Size(90, 34) };
        btnThem.Click += btnThem_Click;
        btnXoa.Click += btnXoa_Click;
        btnSua.Click += btnSua_Click;
        Controls.AddRange(new Control[] { txtMaKhoa, txtMaLop, txtTenLop, btnThem, btnXoa, btnSua, dgv });

        dgv.CellClick += (s, e) =>
        {
            if (e.RowIndex < 0) return;
            var c = dgv.Rows[e.RowIndex].Cells;
            txtMaKhoa.Text = c["MaKhoa"].Value?.ToString();
            txtMaLop.Text = c["MaLop"].Value?.ToString();
            txtTenLop.Text = c["TenLop"].Value?.ToString();
        };
        Load += (s, e) => LoadGrid();
    }

    private void LoadGrid() => Db.Load(dgv, "SELECT MaKhoa, MaLop, TenLop FROM Lop ORDER BY MaLop");

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!Check.Require((txtMaKhoa, "Mã khoa"), (txtMaLop, "Mã lớp"), (txtTenLop, "Tên lớp"))) return;
        if (Db.Run("INSERT INTO Lop(MaLop, TenLop, MaKhoa) VALUES(@lop, @ten, @khoa)", "Thêm lớp thành công!", "",
                   Db.P("@lop", txtMaLop.Text.Trim()), Db.P("@ten", txtTenLop.Text.Trim()), Db.P("@khoa", txtMaKhoa.Text.Trim())))
            LoadGrid();
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (!Check.Require((txtMaLop, "Mã lớp"))) return;
        string ma = txtMaLop.Text.Trim();
        if (Db.Run("DELETE FROM Lop WHERE MaLop = @lop", "Xóa lớp thành công!", $"Không tìm thấy lớp có mã \"{ma}\".", Db.P("@lop", ma)))
            LoadGrid();
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (!Check.Require((txtMaLop, "Mã lớp"))) return;

        var sets = new List<string>();
        var ps = new List<SqlParameter> { Db.P("@lop", txtMaLop.Text.Trim()) };
        if (txtMaKhoa.Text.Trim() != "") { sets.Add("MaKhoa = @khoa"); ps.Add(Db.P("@khoa", txtMaKhoa.Text.Trim())); }
        if (txtTenLop.Text.Trim() != "") { sets.Add("TenLop = @ten"); ps.Add(Db.P("@ten", txtTenLop.Text.Trim())); }
        if (sets.Count == 0)
        {
            MessageBox.Show("Mã khoa, Tên lớp phải có ít nhất 1 trường có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (Db.Run($"UPDATE Lop SET {string.Join(", ", sets)} WHERE MaLop = @lop", "Sửa lớp thành công!",
                   $"Không tìm thấy lớp có mã \"{txtMaLop.Text.Trim()}\".", ps.ToArray()))
            LoadGrid();
    }
}
