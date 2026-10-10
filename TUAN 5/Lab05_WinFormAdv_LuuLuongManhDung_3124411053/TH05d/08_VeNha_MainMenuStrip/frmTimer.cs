using System;
using System.Drawing;
using System.Windows.Forms;

namespace App;

public class frmTimer : Form
{
    private readonly Label label1 = new Label
    {
        Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter,
        ForeColor = Color.Red, Font = new Font("Tahoma", 14, FontStyle.Bold)
    };
    
    private readonly System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer { Interval = 1000, Enabled = true };

    public frmTimer()
    {
        Text = "Demo Timer";
        ClientSize = new Size(320, 180);
        BackColor = Color.FromArgb(236, 233, 216);
        StartPosition = FormStartPosition.CenterScreen;
        Controls.Add(label1);

        timer1.Tick += timer1_Tick;
        CapNhatGio();                         
        FormClosed += (s, e) => timer1.Dispose();
    }

    private void timer1_Tick(object sender, EventArgs e) => CapNhatGio();

    
    private void CapNhatGio() => label1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
}
