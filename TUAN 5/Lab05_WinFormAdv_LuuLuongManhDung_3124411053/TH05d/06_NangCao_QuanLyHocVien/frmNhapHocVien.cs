using System;
using System.Drawing;
using System.Windows.Forms;

namespace App;


public class frmNhapHocVien : Form
{
    public event Action<string, int> CapNhat;   
    private readonly TextBox txtHoTen = new TextBox { Location = new Point(100, 17), Width = 230 };
    private readonly ComboBox cboLop = new ComboBox { Location = new Point(100, 57), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };

    public frmNhapHocVien()
    {
        Text = "Nhập học viên mới";
        Font = new Font("Times New Roman", 11, FontStyle.Bold);
        ClientSize = new Size(360, 150);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false; MinimizeBox = false; ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;

        cboLop.Items.AddRange(new object[] { "Lớp A", "Lớp B" });
        cboLop.SelectedIndex = 0;
        Controls.Add(new Label { Text = "Họ và Tên", AutoSize = true, Location = new Point(15, 21) });
        Controls.Add(new Label { Text = "Lớp", AutoSize = true, Location = new Point(15, 61) });

        var btnCapNhat = new Button { Text = "Cập nhật", Location = new Point(100, 100), Size = new Size(110, 32) };
        var btnTroVe = new Button { Text = "Trở về", Location = new Point(220, 100), Size = new Size(110, 32) };
        btnCapNhat.Click += btnCapNhat_Click;
        btnTroVe.Click += (s, e) => Close();
        Controls.AddRange(new Control[] { txtHoTen, cboLop, btnCapNhat, btnTroVe });
        AcceptButton = btnCapNhat;
        CancelButton = btnTroVe;
    }

    private void btnCapNhat_Click(object sender, EventArgs e)
    {
        string ten = txtHoTen.Text.Trim();
        if (ten == "")
        {
            MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return;
        }
        CapNhat?.Invoke(ten, cboLop.SelectedIndex);
        txtHoTen.Clear();
        txtHoTen.Focus();    
    }
}
