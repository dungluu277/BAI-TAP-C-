using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace App;

public class frmChuoi : Form
{
    private static readonly string[] HO = { "Lê", "Nguyễn", "Lý", "Trần", "Lâm", "Hồ", "Lai", "Huỳnh", "La" };
    private static readonly string[] TENLOT = { "Quang", "Thành", "Ngọc", "Anh", "Xuân", "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng" };
    private static readonly string[] TEN = { "Hà", "Danh", "Sơn", "Mai", "Thắng", "Kỳ", "Thành", "Lâm", "Tâm", "Phụng", "Thắm" };

    private readonly Random rnd = new Random();
    private readonly ListBox lst = new ListBox { Location = new Point(20, 70), Size = new Size(200, 350), SelectionMode = SelectionMode.MultiExtended };

    public frmChuoi()
    {
        Text = "frmChuoi";
        Font = new Font("Tahoma", 10);
        ClientSize = new Size(640, 440);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Controls.Add(lst);

        var btnNgauNhien = new Button { Text = "Nhập tên ngẫu nhiên", Location = new Point(20, 15), Size = new Size(200, 40) };
        btnNgauNhien.Click += (s, e) => lst.Items.AddRange(
            Enumerable.Range(0, 50).Select(_ => (object)$"{Pick(HO)} {Pick(TENLOT)} {Pick(TEN)}").ToArray());
        Controls.Add(btnNgauNhien);

        AddButton("Xóa Phần tử đang chọn", 0, XoaDangChon);
        AddButton("Xóa phần tử có tên là Sơn", 1, () => XoaNeu(s => string.Equals(TuCuoi(s), "Sơn", StringComparison.OrdinalIgnoreCase)));
        AddButton("Xóa Phần tử có họ là Lê", 2, () => XoaNeu(s => string.Equals(TuDau(s), "Lê", StringComparison.OrdinalIgnoreCase)));
        AddButton("Chuyển PT đang chọn thành chữ HOA", 3, () => DoiDangChon(s => s.ToUpper()));
        AddButton("Chuyển PT đang chọn thành chữ thường", 4, () => DoiDangChon(s => s.ToLower()));
        AddButton("Chuyển PT đang chọn thành viết Hoa đầu mỗi từ", 5,
            () => DoiDangChon(s => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower())));
        AddButton("Xóa tất cả các Phần tử", 6, () => lst.Items.Clear());

        lst.MouseDoubleClick += lst_MouseDoubleClick;
    }

    private string Pick(string[] a) => a[rnd.Next(a.Length)];

    private void AddButton(string text, int row, Action action)
    {
        var b = new Button { Text = text, Location = new Point(240, 70 + row * 50), Size = new Size(380, 42) };
        b.Click += (s, e) => action();
        Controls.Add(b);
    }
    private static string TuDau(string s) => s.Split(' ', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? "";
    private static string TuCuoi(string s) => s.Split(' ', StringSplitOptions.RemoveEmptyEntries).LastOrDefault() ?? "";

private void XoaDangChon()
    {
        if (lst.SelectedIndices.Count == 0)
        {
            MessageBox.Show("Hãy chọn phần tử cần xóa!");
            return;
        }

        foreach (int i in lst.SelectedIndices.Cast<int>().OrderByDescending(x => x).ToList())
        {
            lst.Items.RemoveAt(i);
        }
    }

    private void XoaNeu(Func<string, bool> dieuKien)
    {
        lst.BeginUpdate();
        for (int i = lst.Items.Count - 1; i >= 0; i--)
            if (dieuKien((string)lst.Items[i])) lst.Items.RemoveAt(i);
        lst.EndUpdate();
    }

    private void DoiDangChon(Func<string, string> chuyenDoi)
    {
        var chon = lst.SelectedIndices.Cast<int>().ToList();
        if (chon.Count == 0) { MessageBox.Show("Hãy chọn phần tử cần chuyển!"); return; }
        lst.BeginUpdate();
        foreach (int i in chon) lst.Items[i] = chuyenDoi((string)lst.Items[i]);
        foreach (int i in chon) lst.SetSelected(i, true); 
        lst.EndUpdate();
    }
    private void lst_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        int i = lst.IndexFromPoint(e.Location);
        if (i < 0) return;
        string moi = InputBox("Nhập tên mới:", "Sửa tên", (string)lst.Items[i]);
        if (!string.IsNullOrWhiteSpace(moi)) lst.Items[i] = moi.Trim();
    }

    private string InputBox(string prompt, string title, string defaultValue)
    {
        using var f = new Form
        {
            Text = title, FormBorderStyle = FormBorderStyle.FixedDialog, StartPosition = FormStartPosition.CenterParent,
            MaximizeBox = false, MinimizeBox = false, ShowInTaskbar = false, ClientSize = new Size(360, 120)
        };
        var lbl = new Label { Text = prompt, AutoSize = true, Location = new Point(12, 12) };
        var txt = new TextBox { Text = defaultValue, Location = new Point(12, 38), Width = 336 };
        var ok = new Button { Text = "OK", Location = new Point(180, 76), Width = 80, DialogResult = DialogResult.OK };
        var huy = new Button { Text = "Hủy", Location = new Point(268, 76), Width = 80, DialogResult = DialogResult.Cancel };
        f.Controls.AddRange(new Control[] { lbl, txt, ok, huy });
        f.AcceptButton = ok;
        f.CancelButton = huy;
        return f.ShowDialog(this) == DialogResult.OK ? txt.Text : null;
    }
}
