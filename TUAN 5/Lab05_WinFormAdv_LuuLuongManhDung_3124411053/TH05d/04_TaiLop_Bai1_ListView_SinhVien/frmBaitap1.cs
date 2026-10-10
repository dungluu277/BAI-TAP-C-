using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App;

public class frmBaitap1 : Form
{
    private readonly TextBox txtTen = new TextBox { Location = new Point(250, 18), Width = 370 };
    private readonly TextBox txtMa = new TextBox { Location = new Point(250, 58), Width = 370 };
    private readonly RadioButton rdoNam = new RadioButton { Text = "Nam", Checked = true, AutoSize = true, Location = new Point(250, 100) };
    private readonly RadioButton rdoNu = new RadioButton { Text = "Nữ", AutoSize = true, Location = new Point(350, 100) };
    private readonly CheckBox chkAnh = new CheckBox { Text = "Anh", Checked = true, AutoSize = true, Location = new Point(250, 140) };
    private readonly CheckBox chkPhap = new CheckBox { Text = "Pháp", AutoSize = true, Location = new Point(350, 140) };
    private readonly CheckBox chkHoa = new CheckBox { Text = "Hoa", AutoSize = true, Location = new Point(450, 140) };
    private readonly ComboBox cboDanToc = new ComboBox { Location = new Point(250, 178), Width = 370, DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ListView lv = new ListView
    {
        Location = new Point(20, 225), Size = new Size(660, 280), View = View.Details,
        FullRowSelect = true, GridLines = true, HideSelection = false, MultiSelect = false
    };

    public frmBaitap1()
    {
        Text = "frmBaitap1";
        Font = new Font("Tahoma", 10);
        ClientSize = new Size(700, 575);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        string[] nhan = { "Họ và Tên", "Mã sinh viên", "Giới tính", "Ngoại ngữ", "Dân tộc" };
        int[] y = { 21, 61, 101, 141, 181 };
        for (int i = 0; i < nhan.Length; i++)
            Controls.Add(new Label { Text = nhan[i], AutoSize = true, Location = new Point(90, y[i]) });

        foreach (var (ten, rong) in new[] { ("Họ tên", 180), ("Mã sinh viên", 110), ("Giới tính", 90), ("Ngoại ngữ", 160), ("Dân tộc", 100) })
            lv.Columns.Add(ten, rong);

        var btnThem = MakeButton("Thêm", 150, btnThem_Click);
        var btnXoa = MakeButton("Xóa", 290, (s, e) => Xoa());
        var btnSua = MakeButton("Sửa", 430, btnSua_Click);
        Controls.AddRange(new Control[] { txtTen, txtMa, rdoNam, rdoNu, chkAnh, chkPhap, chkHoa, cboDanToc, lv, btnThem, btnXoa, btnSua });

     
        var menu = new ContextMenuStrip();
        menu.Items.Add("Xóa", null, (s, e) => Xoa());
        menu.Opening += (s, e) => e.Cancel = lv.SelectedItems.Count == 0;
        lv.ContextMenuStrip = menu;

       
        Load += (s, e) =>
        {
            cboDanToc.Items.AddRange(new object[] { "Kinh", "Hoa", "K’Me", "H’Mong", "Khác" });
            cboDanToc.SelectedIndex = 0;
        };

        lv.SelectedIndexChanged += lv_SelectedIndexChanged;
   
        lv.MouseUp += (s, e) =>
        {
            if (e.Button == MouseButtons.Left && lv.HitTest(e.Location).Item == null) { lv.SelectedItems.Clear(); ClearInput(); }
        };
    }

    private Button MakeButton(string text, int x, EventHandler click)
    {
        var b = new Button { Text = text, Location = new Point(x, 522), Size = new Size(120, 38) };
        b.Click += click;
        return b;
    }

    private static void Warn(string m) => MessageBox.Show(m, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    
    private string[] LayDong() => new[]
    {
        txtTen.Text.Trim(), txtMa.Text.Trim(), rdoNam.Checked ? "Nam" : "Nữ",
        string.Join(", ", new[] { chkAnh, chkPhap, chkHoa }.Where(c => c.Checked).Select(c => c.Text)),
        cboDanToc.Text
    };

    private bool HopLe()
    {
        if (txtTen.Text.Trim() == "") { Warn("Vui lòng nhập Họ và Tên!"); txtTen.Focus(); return false; }
        if (txtMa.Text.Trim() == "") { Warn("Vui lòng nhập Mã sinh viên!"); txtMa.Focus(); return false; }
        return true;
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!HopLe()) return;
        
        if (lv.Items.Cast<ListViewItem>().Any(i => string.Equals(i.SubItems[1].Text, txtMa.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
        {
            Warn("Mã sinh viên đã tồn tại!"); txtMa.SelectAll(); txtMa.Focus(); return;
        }
        lv.Items.Add(new ListViewItem(LayDong()));
        ClearInput();
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (lv.SelectedItems.Count == 0) { Warn("Hãy chọn sinh viên cần sửa!"); return; }
        if (!HopLe()) return;
        var item = lv.SelectedItems[0];
        string[] dong = LayDong();
        for (int i = 0; i < dong.Length; i++)
            if (i != 1) item.SubItems[i].Text = dong[i];   
    }

    private void Xoa()
    {
        if (lv.SelectedItems.Count == 0) { Warn("Hãy chọn sinh viên cần xóa!"); return; }
        if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        lv.SelectedItems[0].Remove();
        ClearInput();
    }

    private void lv_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lv.SelectedItems.Count == 0) return;
        var it = lv.SelectedItems[0].SubItems;
        txtTen.Text = it[0].Text;
        txtMa.Text = it[1].Text;
        txtMa.ReadOnly = true;                                 
        rdoNam.Checked = it[2].Text == "Nam";
        rdoNu.Checked = !rdoNam.Checked;
        var nn = it[3].Text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var c in new[] { chkAnh, chkPhap, chkHoa }) c.Checked = nn.Contains(c.Text);
        cboDanToc.SelectedItem = it[4].Text;
    }

    private void ClearInput()
    {
        txtTen.Clear(); txtMa.Clear();
        txtMa.ReadOnly = false;
        rdoNam.Checked = true;
        chkAnh.Checked = true; chkPhap.Checked = false; chkHoa.Checked = false;
        cboDanToc.SelectedIndex = 0;
        txtTen.Focus();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (e.CloseReason != CloseReason.WindowsShutDown &&
            MessageBox.Show("Bạn có chắc muốn đóng form?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            e.Cancel = true;
        base.OnFormClosing(e);
    }
}
