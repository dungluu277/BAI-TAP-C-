using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App;

public class frmListView : Form
{
    private readonly TextBox txtmssv = new TextBox { Location = new Point(100, 52), Width = 440 };
    private readonly TextBox txthoten = new TextBox { Location = new Point(100, 88), Width = 440 };
    private readonly ListView lstv1 = new ListView
    {
        Location = new Point(12, 130), Size = new Size(528, 270), View = View.Details,
        FullRowSelect = true, GridLines = true, MultiSelect = true, HideSelection = false
    };

    public frmListView()
    {
        Text = "ListView";
        Font = new Font("Times New Roman", 11);
        ClientSize = new Size(556, 416);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        lstv1.Columns.Add("MÃ SỐ SV", 150);
        lstv1.Columns.Add("HỌ VÀ TÊN", 360);
        Controls.Add(new Label { Text = "Mã SV", AutoSize = true, Location = new Point(40, 56) });
        Controls.Add(new Label { Text = "Họ tên", AutoSize = true, Location = new Point(40, 92) });

        AddButton("Thêm", 12, btnthem_Click);
        AddButton("Xóa", 122, btnxoa_Click);
        AddButton("Sửa", 232, btnsua_Click);
        Controls.AddRange(new Control[] { txtmssv, txthoten, lstv1 });

        
        lstv1.SelectedIndexChanged += (s, e) =>
        {
            if (lstv1.SelectedItems.Count == 0) return;
            txtmssv.Text = lstv1.SelectedItems[0].Text;
            txthoten.Text = lstv1.SelectedItems[0].SubItems[1].Text;
        };
    }

    private void AddButton(string text, int x, EventHandler click)
    {
        var b = new Button { Text = text, Location = new Point(x, 10), Size = new Size(100, 32) };
        b.Click += click;
        Controls.Add(b);
    }

    private static void Warn(string m) => MessageBox.Show(m, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    
    private bool HopLe(ListViewItem boQua)
    {
        if (txtmssv.Text.Trim() == "") { Warn("Vui lòng nhập Mã SV!"); txtmssv.Focus(); return false; }
        if (txthoten.Text.Trim() == "") { Warn("Vui lòng nhập Họ tên!"); txthoten.Focus(); return false; }
        bool trung = lstv1.Items.Cast<ListViewItem>()
            .Any(i => i != boQua && string.Equals(i.Text, txtmssv.Text.Trim(), StringComparison.OrdinalIgnoreCase));
        if (trung) { Warn("Mã số sinh viên đã tồn tại!"); txtmssv.SelectAll(); txtmssv.Focus(); return false; }
        return true;
    }

    private void btnthem_Click(object sender, EventArgs e)
    {
        if (!HopLe(null)) return;
       
        lstv1.Items.Add(new ListViewItem(new[] { txtmssv.Text.Trim(), txthoten.Text.Trim() }));
        txtmssv.Clear(); txthoten.Clear();
        txtmssv.Focus();
    }

    private void btnxoa_Click(object sender, EventArgs e)
    {
        if (lstv1.SelectedItems.Count == 0) { Warn("Hãy chọn dòng cần xóa!"); return; }
        if (MessageBox.Show("Bạn có chắc muốn xóa các dòng đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
       
        foreach (var item in lstv1.SelectedItems.Cast<ListViewItem>().ToList())
            item.Remove();
    }

    private void btnsua_Click(object sender, EventArgs e)
    {
        if (lstv1.SelectedItems.Count == 0) { Warn("Hãy chọn dòng cần sửa!"); return; }
        var item = lstv1.SelectedItems[0];
        if (!HopLe(item)) return;
        item.SubItems[0].Text = txtmssv.Text.Trim();
        item.SubItems[1].Text = txthoten.Text.Trim();
    }
}
