namespace BaiTap4C
{
    public partial class Form1 : Form
    {
        private string lastValidInputA = string.Empty;
        private string lastValidInputB = string.Empty;

        public Form1()
        {
            InitializeComponent();
            inputa.KeyPress += NumericTextBox_KeyPress;
            inputb.KeyPress += NumericTextBox_KeyPress;
            inputa.TextChanged += NumericTextBox_TextChanged;
            inputb.TextChanged += NumericTextBox_TextChanged;
            FormClosing += Form1_FormClosing;
        }

        private bool IsPotentialNumber(string text)
        {
            var separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            var index = text.StartsWith('-') ? 1 : 0;
            var hasSeparator = false;

            for (; index < text.Length; index++)
            {
                if (text[index] >= '0' && text[index] <= '9')
                {
                    continue;
                }

                if (!hasSeparator && separator.Length == 1 && text[index] == separator[0])
                {
                    hasSeparator = true;
                    continue;
                }

                return false;
            }

            return true;
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || sender is not TextBox textBox)
            {
                return;
            }

            var proposedText = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength)
                .Insert(textBox.SelectionStart, e.KeyChar.ToString());

            if (!IsPotentialNumber(proposedText))
            {
                e.Handled = true;
                MessageBox.Show("Chưa nhập số hợp lý.", "Dữ liệu không hợp lý",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void NumericTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is not TextBox textBox)
            {
                return;
            }

            var previousText = textBox == inputa ? lastValidInputA : lastValidInputB;
            if (IsPotentialNumber(textBox.Text))
            {
                if (textBox == inputa)
                {
                    lastValidInputA = textBox.Text;
                }
                else
                {
                    lastValidInputB = textBox.Text;
                }

                return;
            }

            textBox.Text = previousText;
            textBox.SelectionStart = textBox.TextLength;
            MessageBox.Show("Chưa nhập số hợp lý", "Dữ liệu không hợp lý",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var answer = MessageBox.Show("Bạn có chắc chắn muốn đóng chương trình?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = answer != DialogResult.Yes;
        }

        private bool TryGetInputs(out double a, out double b)
        {
            var isValid = true;

            errorProvider1.SetError(inputa, string.Empty);
            errorProvider1.SetError(inputb, string.Empty);

            if (!double.TryParse(inputa.Text, out a))
            {
                errorProvider1.SetError(inputa, "Vui lòng nhập số hợp lý cho a.");
                isValid = false;
            }

            if (!double.TryParse(inputb.Text, out b))
            {
                errorProvider1.SetError(inputb, "Vui lòng nhập số hợp lý cho b.");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("dữ liệu nhập phải là số hợp lý.", "Dữ liệu không hợp lý",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private void button1_plus(object sender, EventArgs e)
        {
            if (TryGetInputs(out var a, out var b))
            {
                result.Text = (a + b).ToString();
            }
        }
        private void button2_minus(object sender, EventArgs e)
        {
            if (TryGetInputs(out var a, out var b))
            {
                result.Text = (a - b).ToString();
            }
        }

        private void button3_multiply(object sender, EventArgs e)
        {
            if (TryGetInputs(out var a, out var b))
            {
                result.Text = (a * b).ToString();
            }
        }
        private void button4_divide(object sender, EventArgs e)
        {
            if (!TryGetInputs(out var a, out var b))
            {
                return;
            }

            if (b == 0)
            {
                errorProvider1.SetError(inputb, "Không thể chia cho 0.");
                return;
            }

            result.Text = (a / b).ToString();
        }

    }
}
