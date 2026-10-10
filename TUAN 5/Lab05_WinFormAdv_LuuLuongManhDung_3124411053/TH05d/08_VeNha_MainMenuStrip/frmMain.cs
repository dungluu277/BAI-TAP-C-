using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace App;
public class frmMain : Form
{
    private readonly Dictionary<Type, Form> daMo = new Dictionary<Type, Form>();

    public frmMain()
    {
        Text = "BTVN_Tuan6";
        Font = new Font("Tahoma", 10);
        IsMdiContainer = true;
        ClientSize = new Size(1000, 680);
        StartPosition = FormStartPosition.CenterScreen;

        var menu = new MenuStrip();
        menu.Items.Add(Nhom("&Bài mẫu",
            Muc<frmTimer>("Bài 1 – Đồng hồ (Timer)"),
            Muc<frmListView>("Bài 2 – ListView Thêm/Xóa/Sửa"),
            Muc<frmSaveFile>("Bài 3 – Lưu / Mở file")));
        menu.Items.Add(Nhom("Bài tập &tại lớp",
            Muc<frmBaitap1>("Bài 1 – Sinh viên (ListView)"),
            Muc<frmQuanLyTaiKhoan>("Bài 2 – Quản lý tài khoản")));
        menu.Items.Add(Nhom("Bài tập &nâng cao",
            Muc<frmQuanLyHocVien>("Bài 1 – Quản lý học viên")));
        menu.Items.Add(Nhom("Bài tập về &nhà",
            Muc<frmDemNguoc>("Bài 1 – Đếm ngược thời gian")));
        var mnuThoat = new ToolStripMenuItem("&Thoát");
        mnuThoat.Click += (s, e) => Close();
        menu.Items.Add(mnuThoat);

        MainMenuStrip = menu;
        Controls.Add(menu);
    }

    private static ToolStripMenuItem Nhom(string text, params ToolStripItem[] items)
    {
        var m = new ToolStripMenuItem(text);
        m.DropDownItems.AddRange(items);
        return m;
    }

    private ToolStripMenuItem Muc<T>(string text) where T : Form, new()
    {
        var m = new ToolStripMenuItem(text);
        m.Click += (s, e) => MoForm<T>();
        return m;
    }

    private void MoForm<T>() where T : Form, new()
    {
        if (daMo.TryGetValue(typeof(T), out Form f) && !f.IsDisposed) { f.Activate(); return; }
        f = new T { MdiParent = this };
        daMo[typeof(T)] = f;
        f.Show();
    }
}
