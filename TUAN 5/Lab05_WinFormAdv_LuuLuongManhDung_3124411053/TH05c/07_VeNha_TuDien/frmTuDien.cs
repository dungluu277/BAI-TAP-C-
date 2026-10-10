using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App;

public class frmTuDien : Form
{
    private static readonly string[] DuLieu =
    {
        "student|sinh viên, học sinh", "teacher|giáo viên", "worker|công nhân", "hat|cái mũ", "head|cái đầu",
        "mouse|con chuột", "cat|con mèo", "dog|con chó", "snake|con rắn", "lamb|con cừu non", "frog|con ếch",
        "sheep|con cừu", "book|quyển sách", "table|cái bàn", "chair|cái ghế", "computer|máy tính",
        "school|trường học", "house|ngôi nhà", "water|nước", "fire|lửa", "sun|mặt trời", "moon|mặt trăng",
        "star|ngôi sao", "tree|cái cây", "flower|bông hoa", "car|xe hơi", "bike|xe đạp", "apple|quả táo",
        "rice|gạo, cơm", "friend|bạn bè", "love|tình yêu, yêu", "happy|vui vẻ, hạnh phúc"
    };

    public frmTuDien()
    {
        Text = "TỪ ĐIỂN ANH VIỆT - VIỆT ANH";
        Font = new Font("Tahoma", 10);
        ClientSize = new Size(580, 480);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        var anhViet = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var vietAnh = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var dong in DuLieu)
        {
            var p = dong.Split('|');
            anhViet[p[0]] = p[1];
            foreach (string nghia in p[1].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
                vietAnh[nghia] = vietAnh.TryGetValue(nghia, out var cu) ? cu + ", " + p[0] : p[0];
        }

        var tab = new TabControl { Location = new Point(10, 10), Size = new Size(560, 415) };
        var tabAV = new TabPage("ANH - VIỆT");
        var tabVA = new TabPage("VIỆT - ANH");
        tab.TabPages.AddRange(new[] { tabAV, tabVA });
        new TrangTuDien(tabAV, "Tiếng Anh", "Tiếng Việt", anhViet);
        new TrangTuDien(tabVA, "Tiếng Việt", "Tiếng Anh", vietAnh);
        Controls.Add(tab);

        var btnThoat = new Button { Text = "Th&oát", Location = new Point(470, 435), Size = new Size(100, 32) };
        btnThoat.Click += (s, e) => Close();
        Controls.Add(btnThoat);
    }
    private class TrangTuDien
    {
        private readonly Dictionary<string, string> tu;
        private readonly ComboBox cboTu = new ComboBox { Location = new Point(15, 40), Width = 240 };
        private readonly ListBox lstTu = new ListBox { Location = new Point(15, 72), Size = new Size(240, 290) };
        private readonly TextBox txtNghia = new TextBox { Location = new Point(280, 40), Size = new Size(255, 322), Multiline = true, ReadOnly = true, BackColor = Color.White };

        public TrangTuDien(TabPage page, string tieuDeTrai, string tieuDePhai, Dictionary<string, string> data)
        {
            tu = data;
            string[] ds = tu.Keys.OrderBy(k => k, StringComparer.CurrentCultureIgnoreCase).ToArray();
            cboTu.Items.AddRange(ds);
            lstTu.Items.AddRange(ds);
            cboTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;     
            cboTu.AutoCompleteSource = AutoCompleteSource.ListItems;

            page.Controls.Add(new Label { Text = tieuDeTrai, AutoSize = true, Location = new Point(15, 15) });
            page.Controls.Add(new Label { Text = tieuDePhai, AutoSize = true, Location = new Point(280, 15) });
            page.Controls.AddRange(new Control[] { cboTu, lstTu, txtNghia });
            cboTu.TextChanged += (s, e) =>
            {
                string t = cboTu.Text.Trim();
                lstTu.SelectedIndex = t == "" ? -1 : lstTu.FindString(t);
            };

            cboTu.KeyDown += (s, e) =>
            {
                if (e.KeyCode != Keys.Enter) return;
                e.SuppressKeyPress = true;
                TraTu(cboTu.Text);
            };
           
            lstTu.MouseDoubleClick += (s, e) =>
            {
                int i = lstTu.IndexFromPoint(e.Location);
                if (i < 0) return;
                cboTu.Text = (string)lstTu.Items[i];
                TraTu(cboTu.Text);
            };
        }

        private void TraTu(string tuCanTra)
        {
            tuCanTra = tuCanTra.Trim();
            txtNghia.Text = tu.TryGetValue(tuCanTra, out var nghia) ? nghia : $"Không tìm thấy từ \"{tuCanTra}\"";
        }
    }
}
