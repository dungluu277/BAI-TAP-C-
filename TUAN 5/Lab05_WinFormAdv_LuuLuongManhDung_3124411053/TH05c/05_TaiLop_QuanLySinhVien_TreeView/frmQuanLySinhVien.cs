using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App;

public record SinhVien(string Ma, string HoTen, string DiaChi);

public class frmQuanLySinhVien : Form
{
    private readonly TreeView trv = new TreeView { Location = new Point(10, 10), Size = new Size(260, 500), HideSelection = false };
    private readonly ComboBox cboLop = new ComboBox { Location = new Point(390, 18), Width = 370, DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly TextBox txtMa = new TextBox { Location = new Point(100, 35), Width = 340 };
    private readonly TextBox txtTen = new TextBox { Location = new Point(100, 80), Width = 340 };
    private readonly TextBox txtDiaChi = new TextBox { Location = new Point(100, 125), Width = 340 };
    private readonly CheckBox chkThemLop = new CheckBox { Text = "Thêm lớp", AutoSize = true, Location = new Point(290, 300) };
    private readonly GroupBox gbLop = new GroupBox { Text = "Thông tin lớp", Location = new Point(290, 330), Size = new Size(470, 90), Visible = false };
    private readonly TextBox txtLop = new TextBox { Location = new Point(100, 35), Width = 200 };
    private readonly TreeNode root = new TreeNode("Danh sách lớp");

    public frmQuanLySinhVien()
    {
        Text = "Quản lý sinh viên";
        Font = new Font("Times New Roman", 11);
        ClientSize = new Size(780, 520);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        Controls.Add(new Label { Text = "Chọn Lớp", AutoSize = true, Location = new Point(290, 22) });
        var gbSV = new GroupBox { Text = "Thông tin sinh viên", Location = new Point(290, 55), Size = new Size(470, 230) };
        gbSV.Controls.Add(new Label { Text = "Mã SV:", AutoSize = true, Location = new Point(20, 38) });
        gbSV.Controls.Add(new Label { Text = "Họ Tên:", AutoSize = true, Location = new Point(20, 83) });
        gbSV.Controls.Add(new Label { Text = "Địa Chỉ:", AutoSize = true, Location = new Point(20, 128) });
        var btnCapNhat = new Button { Text = "Cập Nhật", Location = new Point(100, 175), Size = new Size(150, 36) };
        var btnXoa = new Button { Text = "Xóa", Location = new Point(270, 175), Size = new Size(100, 36) };
        gbSV.Controls.AddRange(new Control[] { txtMa, txtTen, txtDiaChi, btnCapNhat, btnXoa });

        gbLop.Controls.Add(new Label { Text = "Tên lớp", AutoSize = true, Location = new Point(20, 38) });
        var btnThemLop = new Button { Text = "Thêm lớp", Location = new Point(320, 32), Size = new Size(120, 32) };
        gbLop.Controls.AddRange(new Control[] { txtLop, btnThemLop });

        Controls.AddRange(new Control[] { trv, cboLop, gbSV, chkThemLop, gbLop });
        trv.Nodes.Add(root);
        foreach (string lop in new[] { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" })
        {
            root.Nodes.Add(lop);
            cboLop.Items.Add(lop);
        }
        root.Expand();
        cboLop.SelectedIndex = 0;

        chkThemLop.CheckedChanged += (s, e) => gbLop.Visible = chkThemLop.Checked; // ẩn/hiện cả nhóm
        btnThemLop.Click += btnThemLop_Click;
        btnCapNhat.Click += btnCapNhat_Click;
        btnXoa.Click += btnXoa_Click;
        trv.AfterSelect += trv_AfterSelect;
    }

    private static void Warn(string m) => MessageBox.Show(m, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    private TreeNode FindLop(string ten) =>
        root.Nodes.Cast<TreeNode>().FirstOrDefault(n => string.Equals(n.Text, ten, StringComparison.OrdinalIgnoreCase));

    private bool MaSVTonTai(string ma) =>
        root.Nodes.Cast<TreeNode>().SelectMany(l => l.Nodes.Cast<TreeNode>())
            .Any(n => n.Tag is SinhVien sv && string.Equals(sv.Ma, ma, StringComparison.OrdinalIgnoreCase));

    private void btnThemLop_Click(object sender, EventArgs e)
    {
        string ten = txtLop.Text.Trim();
        if (ten == "") { Warn("Vui lòng nhập tên lớp!"); txtLop.Focus(); return; }
        if (FindLop(ten) != null) { Warn("Lớp đã tồn tại!"); txtLop.SelectAll(); txtLop.Focus(); return; }

        root.Nodes.Add(ten);
        cboLop.Items.Add(ten);
        cboLop.SelectedItem = ten;
        txtLop.Clear();
        txtLop.Focus();
    }

    private void btnCapNhat_Click(object sender, EventArgs e)
    {
        var lop = FindLop(cboLop.Text);
        if (lop == null) { Warn("Vui lòng chọn lớp!"); return; }

        string ma = txtMa.Text.Trim(), ten = txtTen.Text.Trim(), dc = txtDiaChi.Text.Trim();
        foreach (var (box, name) in new[] { (txtMa, "Mã SV"), (txtTen, "Họ tên"), (txtDiaChi, "Địa chỉ") })
            if (box.Text.Trim() == "") { Warn($"{name} không được để trống!"); box.Focus(); return; }
        if (MaSVTonTai(ma)) { Warn("Mã sinh viên đã tồn tại!"); txtMa.SelectAll(); txtMa.Focus(); return; }

        
        var node = new TreeNode($"{ma}, {ten}") { Tag = new SinhVien(ma, ten, dc) };
        node.Nodes.Add(dc);
        lop.Nodes.Add(node);
        lop.Expand();
        ClearInput();
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        var node = trv.SelectedNode;
        if (node?.Tag is not SinhVien) { Warn("Chỉ được xóa node là sinh viên. Hãy chọn một sinh viên trên TreeView!"); return; }
        if (MessageBox.Show($"Bạn có chắc muốn xóa sinh viên {node.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        node.Remove();
        ClearInput();
    }
    private void trv_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node.Tag is SinhVien sv)
        {
            txtMa.Text = sv.Ma; txtTen.Text = sv.HoTen; txtDiaChi.Text = sv.DiaChi;
            cboLop.SelectedItem = e.Node.Parent.Text;
        }
    }

    private void ClearInput()
    {
        txtMa.Clear(); txtTen.Clear(); txtDiaChi.Clear();
        txtMa.Focus();
    }
}
