using System;
using System.Drawing;
using System.Windows.Forms;

namespace App;

public class frmQuanLyMonHoc : Form
{
    private readonly TextBox txtMaMH = new TextBox { Location = new Point(90, 14), Width = 300 };
    private readonly TextBox txtTenMH = new TextBox { Location = new Point(90, 48), Width = 300 };
    private readonly DataGridView dgv = new DataGridView
    {
        Location = new Point(12, 140), Size = new Size(378, 200), ReadOnly = true, AllowUserToAddRows = false,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    };

    public frmQuanLyMonHoc()
    {
        Text = "Quản lý môn học";
        Font = new Font("Tahoma", 10);
        ClientSize = new Size(404, 356);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        Controls.Add(new Label { Text = "Mã mh", AutoSize = true, Location = new Point(12, 18) });
        Controls.Add(new Label { Text = "Tên mh", AutoSize = true, Location = new Point(12, 52) });
        var btnThem = new Button { Text = "Thêm", Location = new Point(90, 90), Size = new Size(90, 32) };
        var btnXoa = new Button { Text = "Xóa", Location = new Point(190, 90), Size = new Size(90, 32) };
        var btnSua = new Button { Text = "Sửa", Location = new Point(290, 90), Size = new Size(90, 32) };
        btnThem.Click += btnThem_Click;
        btnXoa.Click += btnXoa_Click;
        btnSua.Click += btnSua_Click;
        Controls.AddRange(new Control[] { txtMaMH, txtTenMH, btnThem, btnXoa, btnSua, dgv });

        dgv.CellClick += (s, e) =>
        {
            if (e.RowIndex < 0) return;
            txtMaMH.Text = dgv.Rows[e.RowIndex].Cells["MaMonHoc"].Value?.ToString();
            txtTenMH.Text = dgv.Rows[e.RowIndex].Cells["TenMonHoc"].Value?.ToString();
        };
        Load += (s, e) => LoadGrid();
    }

    private void LoadGrid() => Db.Load(dgv, "SELECT MaMonHoc, TenMonHoc FROM MonHoc ORDER BY MaMonHoc");

   
    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!Check.Require((txtMaMH, "Mã môn học"), (txtTenMH, "Tên môn học"))) return;
        if (Db.Run("INSERT INTO MonHoc(MaMonHoc, TenMonHoc) VALUES(@ma, @ten)", "Thêm môn học thành công!", "",
                   Db.P("@ma", txtMaMH.Text.Trim()), Db.P("@ten", txtTenMH.Text.Trim())))
            LoadGrid();
    }

    
    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (!Check.Require((txtMaMH, "Mã môn học"))) return;
        string ma = txtMaMH.Text.Trim();
        if (Db.Run("DELETE FROM MonHoc WHERE MaMonHoc = @ma", "Xóa môn học thành công!", $"Không tìm thấy môn học có mã \"{ma}\".", Db.P("@ma", ma)))
            LoadGrid();
    }

    
    private void btnSua_Click(object sender, EventArgs e)
    {
        if (!Check.Require((txtMaMH, "Mã môn học"), (txtTenMH, "Tên môn học"))) return;
        string ma = txtMaMH.Text.Trim();
        if (Db.Run("UPDATE MonHoc SET TenMonHoc = @ten WHERE MaMonHoc = @ma", "Sửa môn học thành công!", $"Không tìm thấy môn học có mã \"{ma}\".",
                   Db.P("@ten", txtTenMH.Text.Trim()), Db.P("@ma", ma)))
            LoadGrid();
    }
}
