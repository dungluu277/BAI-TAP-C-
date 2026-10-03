namespace BTVN1
{
    public partial class Form1 : Form
    {
        private decimal soTruoc = 0;      // toán hạng thứ nhất
        private string phepTinh = "";     // phép tính đang chờ: + - * /
        private bool nhapSoMoi = true;    // true: lần bấm số tiếp theo sẽ thay thế nội dung hiện tại
        private const int DoDaiToiDa = 15;

        public Form1()
        {
            InitializeComponent();
        }

        // Bấm các nút số 0-9
        private void btnSo_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (nhapSoMoi || txtKetQua.Text == "0")
            {
                txtKetQua.Text = btn.Text;
                nhapSoMoi = false;
            }
            else if (txtKetQua.Text.Length < DoDaiToiDa)
            {
                txtKetQua.Text += btn.Text;
            }
        }

        // Bấm các nút + - * /
        private void btnPhepTinh_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Nếu đã có phép tính chờ và người dùng vừa nhập số thì tính luôn (vd: 1 + 2 + ...)
            if (phepTinh != "" && !nhapSoMoi)
            {
                if (!TinhKetQua()) return;
            }
            else
            {
                soTruoc = decimal.Parse(txtKetQua.Text);
            }

            phepTinh = btn.Text;
            nhapSoMoi = true;
        }

        // Bấm nút =
        private void btnBang_Click(object sender, EventArgs e)
        {
            if (phepTinh == "") return;

            if (TinhKetQua())
            {
                phepTinh = "";
                nhapSoMoi = true;
            }
        }

        // Bấm nút C: xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            soTruoc = 0;
            phepTinh = "";
            nhapSoMoi = true;
            txtKetQua.Text = "0";
        }

        // Thực hiện phép tính soTruoc [phepTinh] số đang hiển thị, hiển thị kết quả
        private bool TinhKetQua()
        {
            decimal soSau = decimal.Parse(txtKetQua.Text);
            decimal kq = 0;

            try
            {
                switch (phepTinh)
                {
                    case "+": kq = soTruoc + soSau; break;
                    case "-": kq = soTruoc - soSau; break;
                    case "*": kq = soTruoc * soSau; break;
                    case "/":
                        if (soSau == 0)
                        {
                            MessageBox.Show("Không thể chia cho 0!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnXoa_Click(null, null);
                            return false;
                        }
                        kq = soTruoc / soSau;
                        break;
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("Kết quả quá lớn!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnXoa_Click(null, null);
                return false;
            }

            soTruoc = kq;
            txtKetQua.Text = kq.ToString("0.##########");
            return true;
        }
    }
}
