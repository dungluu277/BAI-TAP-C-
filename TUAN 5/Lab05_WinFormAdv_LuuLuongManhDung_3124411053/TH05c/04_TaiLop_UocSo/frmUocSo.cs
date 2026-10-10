using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App;

public class frmUocSo : Form
{
    private readonly TextBox txtSo = new TextBox { Location = new Point(14, 28), Width = 110 };
    private readonly ComboBox cboSo = new ComboBox { Location = new Point(14, 76), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ListBox lstUocSo = new ListBox { Location = new Point(14, 26), Size = new Size(240, 100) };

    public frmUocSo()
    {
        Text = "Combobox – Ước số";
        Font = new Font("Tahoma", 10);
        ClientSize = new Size(560, 330);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        var gbNhap = new GroupBox { Text = "Nhập Số", Location = new Point(12, 8), Size = new Size(250, 130) };
        var btnCapNhat = new Button { Text = "&Cập nhật", Location = new Point(134, 26), Size = new Size(100, 28) };
        btnCapNhat.Click += btnCapNhat_Click;
        gbNhap.Controls.AddRange(new Control[] { txtSo, btnCapNhat, cboSo });

        var gbUoc = new GroupBox { Text = "Danh sách các ước số", Location = new Point(280, 8), Size = new Size(268, 140) };
        gbUoc.Controls.Add(lstUocSo);

        AddButton("&Tổng các ước số", 280, 160, (s, e) => ShowResult("Tổng các ước số", l => l.Sum(x => (long)x).ToString()));
        AddButton("&Số lượng các ước số chẵn", 280, 202, (s, e) => ShowResult("Số lượng các ước số chẵn", l => l.Count(x => x % 2 == 0).ToString()));
        AddButton("Số lượng các ước số &nguyên tố", 280, 244, (s, e) => ShowResult("Số lượng các ước số nguyên tố", l => l.Count(LaNguyenTo).ToString()));
        AddButton("Th&oát", 12, 244, (s, e) => Close(), 100);

        Controls.AddRange(new Control[] { gbNhap, gbUoc });
        AcceptButton = btnCapNhat; 
        cboSo.SelectedIndexChanged += cboSo_SelectedIndexChanged;
    }

    private void AddButton(string text, int x, int y, EventHandler click, int w = 268)
    {
        var b = new Button { Text = text, Location = new Point(x, y), Size = new Size(w, 34) };
        b.Click += click;
        Controls.Add(b);
    }

    private void btnCapNhat_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtSo.Text.Trim(), out int n) || n <= 0)
        {
            MessageBox.Show("Vui lòng nhập một số nguyên dương!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSo.SelectAll(); txtSo.Focus();
            return;
        }
        if (cboSo.Items.Contains(n))
            MessageBox.Show($"Số {n} đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        else
            cboSo.Items.Add(n);

        txtSo.Clear();
        txtSo.Focus();
    }

    private void cboSo_SelectedIndexChanged(object sender, EventArgs e)
    {
        lstUocSo.Items.Clear();
        if (cboSo.SelectedItem is int n)
            lstUocSo.Items.AddRange(UocSo(n).Cast<object>().ToArray());
    }
    private static List<int> UocSo(int n)
    {
        var list = new List<int>();
        for (int i = 1; (long)i * i <= n; i++)
            if (n % i == 0)
            {
                list.Add(i);
                if (i != n / i) list.Add(n / i);
            }
        list.Sort();
        return list;
    }

    private static bool LaNguyenTo(int n)
    {
        if (n < 2) return false;
        for (int i = 2; (long)i * i <= n; i++)
            if (n % i == 0) return false;
        return true;
    }
    private void ShowResult(string title, Func<IEnumerable<int>, string> calc)
    {
        if (lstUocSo.Items.Count == 0)
        {
            MessageBox.Show("Hãy chọn một số trong ComboBox trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        MessageBox.Show($"{title} của {cboSo.SelectedItem}: {calc(lstUocSo.Items.Cast<int>())}", "Kết quả");
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (e.CloseReason != CloseReason.WindowsShutDown &&
            MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            e.Cancel = true;
        base.OnFormClosing(e);
    }
}
