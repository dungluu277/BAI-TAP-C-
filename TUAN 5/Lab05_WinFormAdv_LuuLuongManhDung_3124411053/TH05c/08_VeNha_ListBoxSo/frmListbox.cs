using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App;

public class frmListbox : Form
{
    private readonly TextBox txtN = new TextBox { Location = new Point(12, 28), Width = 164 };
    private readonly ListBox lst = new ListBox { Location = new Point(12, 104), Size = new Size(164, 210), SelectionMode = SelectionMode.MultiExtended };

    public frmListbox()
    {
        Text = "frmListbox";
        Font = new Font("Tahoma", 10);
        ClientSize = new Size(520, 462);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        Controls.Add(new Label { Text = "LISTBOX", Font = new Font("Tahoma", 20, FontStyle.Bold), ForeColor = Color.DarkOrange, TextAlign = ContentAlignment.MiddleCenter, Location = new Point(12, 10), Size = new Size(496, 50) });

        var gbLeft = new GroupBox { Text = "Listbox", Location = new Point(12, 70), Size = new Size(190, 330) };
        var btnNhap = new Button { Text = "&Nhập", Location = new Point(12, 62), Size = new Size(164, 34) };
        btnNhap.Click += btnNhap_Click;
        gbLeft.Controls.AddRange(new Control[] { txtN, btnNhap, lst });

        var gbRight = new GroupBox { Text = "Xử lý Listbox", Location = new Point(212, 70), Size = new Size(296, 330) };
        string[] ten = { "Tổng các phần tử trong List", "Xóa Phần tử đầu và cuối", "Xóa Phần tử đang chọn", "Tăng mỗi phần tử lên 2",
                         "Thay bằng bình phương", "Chọn số chẵn", "Chọn số lẻ" };
        Action[] viec = { Tong, XoaDauCuoi, XoaDangChon, () => BienDoi(v => checked(v + 2)), () => BienDoi(v => checked(v * v)),
                          () => ChonTheo(v => v % 2 == 0), () => ChonTheo(v => v % 2 != 0) };
        for (int i = 0; i < ten.Length; i++)
        {
            var b = new Button { Text = ten[i], Location = new Point(12, 26 + i * 43), Size = new Size(272, 34) };
            Action a = viec[i];
            b.Click += (s, e) => a();
            gbRight.Controls.Add(b);
        }

        var btnKetThuc = new Button { Text = "&KẾT THÚC", Location = new Point(12, 410), Size = new Size(496, 40) };
        btnKetThuc.Click += (s, e) => Close();

        Controls.AddRange(new Control[] { gbLeft, gbRight, btnKetThuc });
        AcceptButton = btnNhap;
    }

    private long[] Values() => lst.Items.Cast<long>().ToArray();

    private void btnNhap_Click(object sender, EventArgs e)
    {
        if (!long.TryParse(txtN.Text.Trim(), out long n) || n < 0 || n > int.MaxValue)
        {
            MessageBox.Show("Vui lòng nhập số tự nhiên N (0 ≤ N ≤ 2147483647)!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtN.SelectAll(); txtN.Focus();
            return;
        }
        lst.Items.Add(n);
        txtN.Clear();
        txtN.Focus();
    }

    private void Tong() => MessageBox.Show("Tổng các phần tử: " + Values().Sum(), "Kết quả");

    private void XoaDauCuoi()
    {
        if (lst.Items.Count == 0) return;
        lst.Items.RemoveAt(lst.Items.Count - 1);                 
        if (lst.Items.Count > 0) lst.Items.RemoveAt(0);
    }

    private void XoaDangChon()
    {
        if (lst.SelectedIndices.Count == 0) { MessageBox.Show("Hãy chọn phần tử cần xóa!"); return; }
        foreach (int i in lst.SelectedIndices.Cast<int>().OrderByDescending(x => x).ToList())
            lst.Items.RemoveAt(i);
    }

    private void BienDoi(Func<long, long> f)
    {
        long[] moi;
        try { moi = Values().Select(f).ToArray(); }
        catch (OverflowException) { MessageBox.Show("Kết quả quá lớn, không thể tính!", "Tràn số", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

        var chon = lst.SelectedIndices.Cast<int>().ToList();
        lst.BeginUpdate();
        for (int i = 0; i < moi.Length; i++) lst.Items[i] = moi[i];
        foreach (int i in chon) lst.SetSelected(i, true);        
        lst.EndUpdate();
    }

    private void ChonTheo(Func<long, bool> dieuKien)
    {
        lst.BeginUpdate();
        lst.ClearSelected();
        for (int i = 0; i < lst.Items.Count; i++)
            if (dieuKien((long)lst.Items[i])) lst.SetSelected(i, true);
        lst.EndUpdate();
    }
}
