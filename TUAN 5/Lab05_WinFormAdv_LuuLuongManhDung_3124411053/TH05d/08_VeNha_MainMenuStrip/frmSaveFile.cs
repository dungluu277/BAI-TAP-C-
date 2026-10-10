using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace App;

public class frmSaveFile : Form
{
    private readonly RichTextBox richTextBox1 = new RichTextBox { Location = new Point(12, 30), Size = new Size(466, 250) };
    private readonly TextBox textBox1 = new TextBox { Location = new Point(12, 292), Size = new Size(270, 26), ReadOnly = true };

    public frmSaveFile()
    {
        Text = "Save File Dialog";
        Font = new Font("Tahoma", 9.5f);
        ClientSize = new Size(490, 335);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        Controls.Add(new Label { Text = "Nhập đoạn text", Font = new Font(Font, FontStyle.Bold), AutoSize = true, Location = new Point(12, 9) });
        var btnMo = new Button { Text = "Mở file", Location = new Point(292, 290), Size = new Size(90, 28) };
        var btnLuu = new Button { Text = "Lưu file", Location = new Point(388, 290), Size = new Size(90, 28) };
        btnMo.Click += btnMo_Click;
        btnLuu.Click += btnLuu_Click;
        Controls.AddRange(new Control[] { richTextBox1, textBox1, btnMo, btnLuu });
    }

    private void btnLuu_Click(object sender, EventArgs e)
    {
        using var dlg = new SaveFileDialog { Filter = "Text files (*.txt)|*.txt", DefaultExt = "txt", Title = "Lưu file" };
        if (dlg.ShowDialog() != DialogResult.OK) return;
        try
        {
            File.WriteAllText(dlg.FileName, richTextBox1.Text, Encoding.UTF8); 
            textBox1.Text = dlg.FileName;
            MessageBox.Show("Đã lưu file thành công!", "Thông báo");
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            MessageBox.Show("Không thể lưu file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnMo_Click(object sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog { Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*", Title = "Mở file" };
        if (dlg.ShowDialog() != DialogResult.OK) return;
        try
        {
            textBox1.Text = dlg.FileName;                                  
            richTextBox1.Text = File.ReadAllText(dlg.FileName, Encoding.UTF8);
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            MessageBox.Show("Không thể mở file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
