namespace bai5
{
    public partial class Form1 : Form
    {
        private static readonly string[] Digits =
        {
            "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín"
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtNumber.Text, out int number) || number < 1 || number > 999)
            {
                MessageBox.Show("Vui lòng nhập số nguyên từ 1 đến 999.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumber.Focus();
                txtNumber.SelectAll();
                return;
            }

            txtResult.Text = ReadNumber(number);
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            txtNumber.Clear();
            txtResult.Clear();
            txtNumber.Focus();
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private static string ReadNumber(int number)
        {
            int hundreds = number / 100;
            int tens = number / 10 % 10;
            int units = number % 10;
            var words = new System.Collections.Generic.List<string>();

            if (hundreds > 0)
            {
                words.Add(Digits[hundreds]);
                words.Add("Trăm");
            }

            if (tens > 1)
            {
                words.Add(Digits[tens]);
                words.Add("Mươi");
            }
            else if (tens == 1)
            {
                words.Add("Mười");
            }
            else if (hundreds > 0 && units > 0)
            {
                words.Add("Lẻ");
            }

            if (units > 0)
            {
                string unitWord = units switch
                {
                    1 when tens > 1 => "Mốt",
                    4 when tens > 1 => "Tư",
                    5 when tens > 0 => "Lăm",
                    _ => Digits[units]
                };
                words.Add(unitWord);
            }

            return string.Join(" ", words);
        }
    }
}
