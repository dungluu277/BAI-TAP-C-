using System.Globalization;

namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateEquationMode();
        }

        private void EquationType_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateEquationMode();
        }

        private void UpdateEquationMode()
        {
            var quadratic = rdoQuadratic.Checked;
            lblC.Enabled = quadratic;
            txtC.Enabled = quadratic;
            txtResult.Clear();
            UpdateSolveButton();
        }

        private void Input_TextChanged(object? sender, EventArgs e)
        {
            txtResult.Clear();
            UpdateSolveButton();
        }

        private void UpdateSolveButton()
        {
            var requiredInputsPresent = !string.IsNullOrWhiteSpace(txtA.Text)
                && !string.IsNullOrWhiteSpace(txtB.Text)
                && (!rdoQuadratic.Checked || !string.IsNullOrWhiteSpace(txtC.Text));

            btnSolve.Enabled = requiredInputsPresent;
        }

        private void BtnSolve_Click(object? sender, EventArgs e)
        {
            if (!TryReadNumber(txtA, "a", out var a)
                || !TryReadNumber(txtB, "b", out var b))
            {
                return;
            }

            if (rdoQuadratic.Checked)
            {
                if (!TryReadNumber(txtC, "c", out var c))
                {
                    return;
                }

                txtResult.Text = new PhuongTrinhBacHai(a, b, c).Giai();
            }
            else if (a == 0)
            {
                txtResult.Text = b == 0
                    ? "Phương trình có vô số nghiệm."
                    : "Phương trình vô nghiệm.";
            }
            else
            {
                txtResult.Text = $"Phương trình có nghiệm x = {Format(-b / a)}.";
            }

            btnSolve.Enabled = false;
        }

        private bool TryReadNumber(TextBox textBox, string coefficient, out double value)
        {
            if (double.TryParse(textBox.Text, NumberStyles.Float | NumberStyles.AllowThousands,
                CultureInfo.CurrentCulture, out value))
            {
                return true;
            }

            MessageBox.Show(
                $"Vui lòng nhập hệ số {coefficient} là một số hợp lệ.",
                "Dữ liệu không hợp lệ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            textBox.Focus();
            textBox.SelectAll();
            return false;
        }

        private static string Format(double value) => value.ToString("0.##", CultureInfo.CurrentCulture);

        private void BtnExit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var choice = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            e.Cancel = choice != DialogResult.Yes;
        }
    }
}
