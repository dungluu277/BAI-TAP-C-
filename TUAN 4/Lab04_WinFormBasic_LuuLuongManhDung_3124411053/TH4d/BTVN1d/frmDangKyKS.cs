namespace BTVN1d
{
    public partial class frmDangKyKS : Form
    {
        // Bảng giá
        private const long GiaPhongDon = 300000;   // /ngày
        private const long GiaPhongDoi = 350000;   // /ngày
        private const long GiaPhongBa = 400000;    // /ngày
        private const long GiaTienNghi = 10000;    // mỗi loại tiện nghi
        private const long GiaKaraoke = 50000;
        private const long GiaAnSang = 15000;      // /ngày

        // Thống kê trong ngày
        private int tongLuotKhach = 0;
        private long tongTienThu = 0;

        // Đã thanh toán cho khách hiện tại hay chưa
        private bool daThanhToan = false;

        public frmDangKyKS()
        {
            InitializeComponent();
        }

        // Trạng thái ban đầu của form
        private void KhoiTaoForm()
        {
            txtTen.Clear();
            txtDiaChi.Clear();
            txtSoNgay.Clear();

            rdoDon.Checked = false;
            rdoDoi.Checked = false;
            rdoBa.Checked = false;

            chkTivi.Checked = false;
            chkInternet.Checked = false;
            chkNuocNong.Checked = false;
            chkKaraoke.Checked = false;
            chkAnSang.Checked = false;

            lblThanhTien.Text = "";

            daThanhToan = false;
            BatTatNhapLieu(true);

            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;
            btnTongKet.Enabled = tongLuotKhach > 0;   // còn khách chưa tổng kết thì vẫn cho tổng kết

            txtTen.Focus();
        }

        // Bật/tắt các ô nhập liệu (khóa lại sau khi đã thanh toán)
        private void BatTatNhapLieu(bool batLen)
        {
            txtTen.Enabled = batLen;
            txtDiaChi.Enabled = batLen;
            txtSoNgay.Enabled = batLen;
            rdoDon.Enabled = batLen;
            rdoDoi.Enabled = batLen;
            rdoBa.Enabled = batLen;
            chkTivi.Enabled = batLen;
            chkInternet.Enabled = batLen;
            chkNuocNong.Enabled = batLen;
            chkKaraoke.Enabled = batLen;
            chkAnSang.Enabled = batLen;
        }

        // Form_Load
        private void frmDangKyKS_Load(object sender, EventArgs e)
        {
            KhoiTaoForm();
            ActiveControl = txtTen;   // con trỏ đặt vào ô tên khách hàng
        }

        // Chỉ cho nhập số vào ô "Số ngày ở"
        private void txtSoNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Kiểm tra đã nhập đầy đủ thông tin chưa -> bật/tắt btnThanhToan
        private void KiemTraDuThongTin(object sender, EventArgs e)
        {
            if (daThanhToan) return;

            bool coTen = txtTen.Text.Trim() != "";
            bool coDiaChi = txtDiaChi.Text.Trim() != "";
            bool soNgayHopLe = int.TryParse(txtSoNgay.Text, out int soNgay) && soNgay > 0;
            bool coLoaiPhong = rdoDon.Checked || rdoDoi.Checked || rdoBa.Checked;

            btnThanhToan.Enabled = coTen && coDiaChi && soNgayHopLe && coLoaiPhong;
        }

        // btnThanhToan
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int soNgay = int.Parse(txtSoNgay.Text);

            long giaPhong;
            if (rdoDon.Checked) giaPhong = GiaPhongDon;
            else if (rdoDoi.Checked) giaPhong = GiaPhongDoi;
            else giaPhong = GiaPhongBa;

            long thanhTien = giaPhong * soNgay;

            // Tiện nghi: mỗi loại cộng thêm 10.000đ
            if (chkTivi.Checked) thanhTien += GiaTienNghi;
            if (chkInternet.Checked) thanhTien += GiaTienNghi;
            if (chkNuocNong.Checked) thanhTien += GiaTienNghi;

            // Dịch vụ
            if (chkKaraoke.Checked) thanhTien += GiaKaraoke;
            if (chkAnSang.Checked) thanhTien += GiaAnSang * soNgay;

            lblThanhTien.Text = thanhTien + " VNĐ";

            // Lưu lại thông tin tổng
            tongLuotKhach++;
            tongTienThu += thanhTien;

            daThanhToan = true;
            BatTatNhapLieu(false);

            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = true;
            btnTongKet.Enabled = true;
        }

        // btnNhapMoi
        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            KhoiTaoForm();
        }

        // btnTongKet
        private void btnTongKet_Click(object sender, EventArgs e)
        {
            lblSoLuot.Text = tongLuotKhach.ToString();
            lblTongTien.Text = tongTienThu + " VNĐ";

            // Khởi tạo lại giá trị
            tongLuotKhach = 0;
            tongTienThu = 0;

            btnTongKet.Enabled = false;
        }

        // btnThoat
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình không?",
                "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
