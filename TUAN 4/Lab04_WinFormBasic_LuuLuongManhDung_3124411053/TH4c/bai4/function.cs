namespace Bai4
{
    public partial class Form1 : Form
    {
        private readonly List<int> numbers = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInput.Text.Trim(), out int number))
            {
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInput.SelectAll();
                txtInput.Focus();
                return;
            }

            numbers.Add(number);
            txtSequence.Text = string.Join(" ", numbers);
            txtInput.Clear();
            txtInput.Focus();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            txtTotal.Text = numbers.Sum(number => (long)number).ToString();
            txtEven.Text = numbers.Where(number => number % 2 == 0).Sum(number => (long)number).ToString();
            txtOdd.Text = numbers.Where(number => number % 2 != 0).Sum(number => (long)number).ToString();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            txtInput.Clear();
            txtSequence.Clear();
            txtTotal.Clear();
            txtEven.Clear();
            txtOdd.Clear();
            txtInput.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
