using System;
using System.Drawing;
using System.Windows.Forms;

namespace App;

public class frmDemNguoc : Form
{
    private const int TongGiay = 30 * 60;                                   

    private readonly Label lblGio = new Label { Text = "30:00", Font = new Font("Consolas", 22, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Location = new Point(10, 10), Size = new Size(220, 50) };
    private readonly Button btn = new Button { Text = "Bắt đầu", Location = new Point(70, 66), Size = new Size(100, 34) };
    private readonly System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer { Interval = 200 };

    private TimeSpan conLai = TimeSpan.FromSeconds(TongGiay);
    private DateTime thoiDiemKetThuc;

    public frmDemNguoc()
    {
        Text = "Đồng hồ";
        ClientSize = new Size(240, 112);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Controls.AddRange(new Control[] { lblGio, btn });

        btn.Click += btn_Click;
        timer.Tick += timer_Tick;
        FormClosed += (s, e) => timer.Dispose();
    }

    private void btn_Click(object sender, EventArgs e)
    {
        if (!timer.Enabled)             
        {
            thoiDiemKetThuc = DateTime.Now + conLai;
            timer.Start();
            btn.Text = "Tạm dừng";
        }
        else                            
        {
            timer.Stop();
            conLai = thoiDiemKetThuc - DateTime.Now;
            btn.Text = "Tiếp tục";
        }
    }

    
    private void timer_Tick(object sender, EventArgs e)
    {
        TimeSpan con = thoiDiemKetThuc - DateTime.Now;
        if (con <= TimeSpan.Zero)
        {
            timer.Stop();
            HienThi(TimeSpan.Zero);
            MessageBox.Show("Hết giờ!", "Đồng hồ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conLai = TimeSpan.FromSeconds(TongGiay);
            HienThi(conLai);
            btn.Text = "Bắt đầu";
            return;
        }
        HienThi(con);
    }

    private void HienThi(TimeSpan t)
    {
        int giay = (int)Math.Ceiling(t.TotalSeconds);          
        lblGio.Text = $"{giay / 60:00}:{giay % 60:00}";
    }
}
