using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App;

public class frmDanhBa : Form
{
    private readonly TreeView trv = new TreeView { Location = new Point(10, 10), Size = new Size(230, 460), HideSelection = false };
    private readonly TextBox txtFirst = new TextBox { Location = new Point(110, 28), Width = 230 };
    private readonly TextBox txtLast = new TextBox { Location = new Point(110, 72), Width = 230 };

    public frmDanhBa()
    {
        Text = "frmBTVN2 – Danh bạ";
        Font = new Font("Times New Roman", 11);
        ClientSize = new Size(640, 480);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        for (char c = 'A'; c <= 'Z'; c++)
            trv.Nodes.Add(c.ToString(), c.ToString()); 

        var gb = new GroupBox { Location = new Point(260, 10), Size = new Size(370, 170) };
        gb.Controls.Add(new Label { Text = "First Name", AutoSize = true, Location = new Point(15, 32) });
        gb.Controls.Add(new Label { Text = "Last Name", AutoSize = true, Location = new Point(15, 76) });
        var btnAdd = new Button { Text = "Add", Location = new Point(250, 118), Size = new Size(90, 32) };
        btnAdd.Click += btnAdd_Click;
        gb.Controls.AddRange(new Control[] { txtFirst, txtLast, btnAdd });

        var btnExit = new Button { Text = "Exit", Location = new Point(540, 195), Size = new Size(90, 32) };
        btnExit.Click += (s, e) => Close();

        Controls.AddRange(new Control[] { trv, gb, btnExit });
        AcceptButton = btnAdd;
    }

 
    private static char ChuCaiDau(string s)
    {
        s = s.Trim();
        if (s.Length == 0) return '\0';
        char c = char.ToUpperInvariant(s[0]);
        if (c == 'Đ') return 'D';
        char goc = c.ToString().Normalize(NormalizationForm.FormD)[0];
        return goc >= 'A' && goc <= 'Z' ? goc : '\0';
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        string first = txtFirst.Text.Trim(), last = txtLast.Text.Trim();
        if (first == "" || last == "")
        {
            MessageBox.Show("Vui lòng nhập đầy đủ First Name và Last Name!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            (first == "" ? txtFirst : txtLast).Focus();
            return;
        }
        char chu = ChuCaiDau(first);
        if (chu == '\0')
        {
            MessageBox.Show("First Name phải bắt đầu bằng một chữ cái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtFirst.Focus();
            return;
        }

        TreeNode cha = trv.Nodes[chu.ToString()];
        var moi = new TreeNode($"{first}, {last}");
        int vitri = cha.Nodes.Cast<TreeNode>().TakeWhile(n => string.Compare(n.Text, moi.Text, StringComparison.CurrentCultureIgnoreCase) <= 0).Count();
        cha.Nodes.Insert(vitri, moi);
        cha.Expand();
        trv.SelectedNode = moi;

        txtFirst.Clear(); txtLast.Clear();
        txtFirst.Focus();
    }
}
