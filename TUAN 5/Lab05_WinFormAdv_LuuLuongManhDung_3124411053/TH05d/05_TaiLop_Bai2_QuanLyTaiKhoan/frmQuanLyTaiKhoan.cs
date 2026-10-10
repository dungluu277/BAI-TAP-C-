using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace App;

public class frmQuanLyTaiKhoan : Form
{
    private static readonly CultureInfo CI = CultureInfo.InvariantCulture; 

    private readonly TextBox txtSTK = new TextBox { Location = new Point(225, 70), Width = 400 };
    private readonly TextBox txtTen = new TextBox { Location = new Point(225, 105), Width = 400 };
    private readonly TextBox txtDiaChi = new TextBox { Location = new Point(225, 140), Width = 400 };
    private readonly TextBox txtTien = new TextBox { Location = new Point(225, 175), Width = 400, TextAlign = HorizontalAlignment.Right };
    private readonly TextBox txtTong = new TextBox { Location = new Point(465, 452), Width = 160, ReadOnly = true, TextAlign = HorizontalAlignment.Right };
    private readonly Button btnThem = new Button { Text = "Thêm", Location = new Point(225, 215), Size = new Size(95, 32) };
    private readonly Button btnLuu = new Button { Text = "Lưu", Location = new Point(330, 215), Size = new Size(95, 32), Enabled = false };
    private readonly Button btnXoa = new Button { Text = "Xóa", Location = new Point(435, 215), Size = new Size(95, 32), Enabled = false };
    private readonly Button btnThoat = new Button { Text = "Thoát", Location = new Point(540, 215), Size = new Size(85, 32) };
    private readonly ListView lv = new ListView
    {
        Location = new Point(15, 260), Size = new Size(610, 180), View = View.Details,
        FullRowSelect = true, GridLines = true, HideSelection = false, MultiSelect = false
    };
    private bool dangThem;

    public frmQuanLyTaiKhoan()
    {
        Text = "frmBaiTap2";
        Font = new Font("Tahoma", 10);
        ClientSize = new Size(640, 495);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        Controls.Add(new Label { Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN", Font = new Font("Tahoma", 16, FontStyle.Bold), ForeColor = Color.Blue, TextAlign = ContentAlignment.MiddleCenter, Location = new Point(10, 10), Size = new Size(620, 40) });
        string[] nhan = { "Số tài khoản", "Tên khách hàng", "Địa chỉ khách hàng", "Số tiền trong tài khoản" };
        for (int i = 0; i < nhan.Length; i++)
            Controls.Add(new Label { Text = nhan[i], TextAlign = ContentAlignment.MiddleRight, Location = new Point(15, 68 + i * 35), Size = new Size(200, 24) });
        Controls.Add(new Label { Text = "Tổng tiền", AutoSize = true, Location = new Point(380, 456) });

        lv.Columns.Add("STT", 50);
        lv.Columns.Add("Số tài khoản", 140);
        lv.Columns.Add("Tên khách hàng", 170);
        lv.Columns.Add("Địa chỉ", 120);
        lv.Columns.Add(new ColumnHeader { Text = "Số tiền", Width = 110, TextAlign = HorizontalAlignment.Right });

        Controls.AddRange(new Control[] { txtSTK, txtTen, txtDiaChi, txtTien, txtTong, btnThem, btnLuu, btnXoa, btnThoat, lv });
        btnThem.Click += btnThem_Click;
        btnLuu.Click += btnLuu_Click;
        btnXoa.Click += btnXoa_Click;
        btnThoat.Click += (s, e) => Close();
        lv.SelectedIndexChanged += lv_SelectedIndexChanged;

        CapNhatTong();
        SetMode(false);
    }

    private static void Warn(string m) => MessageBox.Show(m, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

   
    private void SetMode(bool them)
    {
        dangThem = them;
        btnThem.Text = them ? "Hủy" : "Thêm";
        btnLuu.Enabled = them;
        lv.Enabled = !them;
        foreach (var t in new[] { txtSTK, txtTen, txtDiaChi, txtTien }) { t.ReadOnly = !them; t.Clear(); }
        btnXoa.Enabled = !them && lv.SelectedItems.Count > 0;
        if (them) txtSTK.Focus();
    }

    private void btnThem_Click(object sender, EventArgs e) => SetMode(!dangThem); 

    private void btnLuu_Click(object sender, EventArgs e)
    {
        foreach (var (box, name) in new[] { (txtSTK, "Số tài khoản"), (txtTen, "Tên khách hàng"), (txtDiaChi, "Địa chỉ"), (txtTien, "Số tiền") })
            if (box.Text.Trim() == "") { Warn($"{name} không được để trống!"); box.Focus(); return; }

        if (!decimal.TryParse(txtTien.Text.Trim(), NumberStyles.Number, CI, out decimal tien) || tien < 0)
        {
            Warn("Số tiền phải là số không âm!"); txtTien.SelectAll(); txtTien.Focus(); return;
        }
        string stk = txtSTK.Text.Trim();
        if (lv.Items.Cast<ListViewItem>().Any(i => i.SubItems[1].Text == stk))
        {
            Warn("Số tài khoản đã tồn tại!"); txtSTK.SelectAll(); txtSTK.Focus(); return;
        }

        
        lv.Items.Add(new ListViewItem(new[] { "", stk, txtTen.Text.Trim(), txtDiaChi.Text.Trim(), tien.ToString("N0", CI) }) { Tag = tien });
        DanhSoVaTinhTong();
        SetMode(false);
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (lv.SelectedItems.Count == 0) return;
        if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        lv.SelectedItems[0].Remove();
        DanhSoVaTinhTong();
        SetMode(false);
    }

    private void lv_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dangThem) return;
        btnXoa.Enabled = lv.SelectedItems.Count > 0;           
        if (lv.SelectedItems.Count == 0) return;
        var it = lv.SelectedItems[0];
        txtSTK.Text = it.SubItems[1].Text;
        txtTen.Text = it.SubItems[2].Text;
        txtDiaChi.Text = it.SubItems[3].Text;
        txtTien.Text = ((decimal)it.Tag).ToString("0.##", CI);
    }

    private void DanhSoVaTinhTong()
    {
        for (int i = 0; i < lv.Items.Count; i++) lv.Items[i].Text = (i + 1).ToString(); 
        CapNhatTong();
    }

    private void CapNhatTong() =>
        txtTong.Text = lv.Items.Cast<ListViewItem>().Sum(i => (decimal)i.Tag).ToString("N0", CI);

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (e.CloseReason != CloseReason.WindowsShutDown &&
            MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            e.Cancel = true;
        base.OnFormClosing(e);
    }
}
