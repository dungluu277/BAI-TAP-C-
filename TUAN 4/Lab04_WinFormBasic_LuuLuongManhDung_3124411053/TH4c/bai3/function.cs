namespace bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            txtGcd.Clear();
            txtLcm.Clear();

            if (!long.TryParse(txtA.Text.Trim(), out long a))
            {
                ShowInputError(txtA, "Vui lòng nhập số nguyên hợp lệ cho a.");
                return;
            }

            if (!long.TryParse(txtB.Text.Trim(), out long b))
            {
                ShowInputError(txtB, "Vui lòng nhập số nguyên hợp lệ cho b.");
                return;
            }

            if (a <= 0)
            {
                ShowInputError(txtA, "Số a phải là số nguyên dương.");
                return;
            }

            if (b <= 0)
            {
                ShowInputError(txtB, "Số b phải là số nguyên dương.");
                return;
            }

            long gcd = GreatestCommonDivisor(a, b);

            try
            {
                long lcm = checked(a / gcd * b);
                txtGcd.Text = gcd.ToString();
                txtLcm.Text = lcm.ToString();
            }
            catch (OverflowException)
            {
                MessageBox.Show("BCNN vượt quá phạm vi số nguyên 64-bit.", "Lỗi tính toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ShowInputError(TextBox textBox, string message)
        {
            MessageBox.Show(message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox.Focus();
            textBox.SelectAll();
        }

        private static long GreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                (a, b) = (b, a % b);
            }

            return a;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtGcd.Clear();
            txtLcm.Clear();
            txtA.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
