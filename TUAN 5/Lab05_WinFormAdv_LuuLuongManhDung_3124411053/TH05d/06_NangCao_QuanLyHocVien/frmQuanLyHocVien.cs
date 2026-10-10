using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App;

public class frmQuanLyHocVien : Form
{
    private readonly ListBox lstA = new ListBox { Dock = DockStyle.Fill, SelectionMode = SelectionMode.MultiExtended };
    private readonly ListBox lstB = new ListBox { Dock = DockStyle.Fill, SelectionMode = SelectionMode.MultiExtended };

    public frmQuanLyHocVien()
    {
        Text = "Quản lý học viên";
        Font = new Font("Times New Roman", 11, FontStyle.Bold);
        ClientSize = new Size(420, 290);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

      
        var menu = new MenuStrip { AllowMerge = false };
        var mnuCapNhat = new ToolStripMenuItem("&Cập nhật");
        mnuCapNhat.DropDownItems.Add("Nhập học viên mới", null, (s, e) => NhapHocVienMoi());
        mnuCapNhat.DropDownItems.Add("Chuyển sang lớp B", null, (s, e) => Chuyen(lstA, lstB));
        mnuCapNhat.DropDownItems.Add("Chuyển sang lớp A", null, (s, e) => Chuyen(lstB, lstA));
        mnuCapNhat.DropDownItems.Add("Xóa học viên", null, (s, e) => XoaHocVien());
        var mnuKetThuc = new ToolStripMenuItem("&Kết thúc");
        mnuKetThuc.Click += (s, e) => Close();            
        menu.Items.AddRange(new ToolStripItem[] { mnuCapNhat, mnuKetThuc });
        MainMenuStrip = menu;

       
        var gbA = new GroupBox { Text = "Lớp A", Location = new Point(20, 40), Size = new Size(180, 230) };
        var gbB = new GroupBox { Text = "Lớp B", Location = new Point(220, 40), Size = new Size(180, 230) };
        gbA.Controls.Add(lstA);
        gbB.Controls.Add(lstB);
        lstA.Items.AddRange(new object[] { "Trần Hùng", "Nguyễn Hưng", "Lâm Tứ" });
        lstB.Items.AddRange(new object[] { "Tuấn Hưng", "Hồng Ngọc", "Anh Minh", "Bảo Lâm" });

        Controls.AddRange(new Control[] { gbA, gbB, menu });
    }

    private static void NhacChon() =>
        MessageBox.Show("Vui lòng chọn học viên trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    
    private static void Chuyen(ListBox tu, ListBox den)
    {
        if (tu.SelectedIndices.Count == 0) { NhacChon(); return; }
        var idx = tu.SelectedIndices.Cast<int>().OrderBy(i => i).ToList();
        den.Items.AddRange(idx.Select(i => tu.Items[i]).ToArray());
        for (int k = idx.Count - 1; k >= 0; k--) tu.Items.RemoveAt(idx[k]); 

    private void XoaHocVien()
    {
        if (lstA.SelectedIndices.Count == 0 && lstB.SelectedIndices.Count == 0) { NhacChon(); return; }
        foreach (var lst in new[] { lstA, lstB })
            foreach (int i in lst.SelectedIndices.Cast<int>().OrderByDescending(x => x).ToList())
                lst.Items.RemoveAt(i);
    }

    private void NhapHocVienMoi()
    {
        using var f = new frmNhapHocVien();
        
        f.CapNhat += (ten, lop) => (lop == 0 ? lstA : lstB).Items.Add(ten);
        f.ShowDialog(this);
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (e.CloseReason != CloseReason.WindowsShutDown &&
            MessageBox.Show("Bạn có chắc muốn dừng chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            e.Cancel = true;
        base.OnFormClosing(e);
    }
}
