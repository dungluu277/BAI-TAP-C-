using System.Text;
using System.Text.RegularExpressions;

namespace bai2new
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            components ??= new System.ComponentModel.Container();
            errorProvider1 = new ErrorProvider(components) { ContainerControl = this };

            Iname.Tag = "*";
            Iname.AccessibleName = "Tên đăng nhập";
            Iemail.Tag = "*";
            Iemail.AccessibleName = "Địa chỉ email";
            Ipass.Tag = "*";
            Ipass.AccessibleName = "Mật khẩu";
            IConfPass.AccessibleName = "Xác nhận mật khẩu";

            Iemail.Leave += txtEmail_Leave;
            signin.Click += btnDangKy_Click;
            IConfPass.KeyDown += txtXacNhanMatKhau_KeyDown;
            this.FormClosing += Form1_FormClosing;
        }
        // Lấy tất cả TextBox, kể cả trong Panel hoặc GroupBox.
        private IEnumerable<TextBox> LayTextBox(Control cha)
        {
            foreach (Control control in cha.Controls)
            {
                if (control is TextBox textbox)
                    yield return textbox;

                foreach (TextBox con in LayTextBox(control))
                    yield return con;
            }
        }

        // Lấy tên dễ hiểu để hiển thị thông báo.
        private string TenTruong(TextBox textbox)
        {
            return string.IsNullOrWhiteSpace(textbox.AccessibleName)
                ? textbox.Name
                : textbox.AccessibleName;
        }

        // Kiểm tra email theo mẫu cơ bản: ten@tenmien.duoi
        private bool EmailHopLe(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        // Kiểm tra khi người dùng rời ô email.
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = Iemail.Text.Trim();

            if (email == "")
            {
                errorProvider1.SetError(Iemail,
                    Convert.ToString(Iemail.Tag) == "*"
                        ? "Vui lòng nhập địa chỉ email."
                        : "");
            }
            else
            {
                errorProvider1.SetError(Iemail,
                    EmailHopLe(email) ? "" : "Email không đúng định dạng.");
            }
        }

        // Kiểm tra dữ liệu và hiển thị thông tin đăng ký.
        private void DangKy()
        {
            errorProvider1.Clear();
            TextBox oLoiDauTien = null;

            // Kiểm tra các ô được đánh dấu bắt buộc.
            foreach (TextBox textbox in LayTextBox(this))
            {
                if (Convert.ToString(textbox.Tag) == "*" &&
                    string.IsNullOrWhiteSpace(textbox.Text))
                {
                    errorProvider1.SetError(
                        textbox, "Vui lòng nhập " + TenTruong(textbox) + ".");

                    if (oLoiDauTien == null)
                        oLoiDauTien = textbox;
                }
            }

            // Kiểm tra lại email khi đăng ký.
            string email = Iemail.Text.Trim();

            if (email != "" && !EmailHopLe(email))
            {
                errorProvider1.SetError(Iemail, "Email không đúng định dạng.");

                if (oLoiDauTien == null)
                    oLoiDauTien = Iemail;
            }

            // Kiểm tra xác nhận mật khẩu.
            if (Ipass.Text != IConfPass.Text)
            {
                errorProvider1.SetError(
                    IConfPass, "Mật khẩu xác nhận không khớp.");

                if (oLoiDauTien == null)
                    oLoiDauTien = IConfPass;
            }

            // Có lỗi thì dừng đăng ký.
            if (oLoiDauTien != null)
            {
                MessageBox.Show(
                    "Vui lòng kiểm tra các ô có biểu tượng lỗi.",
                    "Dữ liệu chưa hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                oLoiDauTien.Focus();
                return;
            }

            // Hiển thị nội dung tất cả TextBox theo yêu cầu bài.
            StringBuilder thongTin = new StringBuilder();

            foreach (TextBox textbox in LayTextBox(this))
            {
                thongTin.AppendLine(
                    TenTruong(textbox) + ": " + textbox.Text);
            }

            MessageBox.Show(
                thongTin.ToString(),
                "Thông tin đăng ký",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Nhấn nút Đăng ký.
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DangKy();
        }

        // Nhấn Enter trong ô Xác nhận mật khẩu.
        private void txtXacNhanMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                DangKy();
            }
        }

        // Hỏi xác nhận trước khi đóng Form.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc muốn đóng Form không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            e.Cancel = (ketQua == DialogResult.No);
        }

    }

}
