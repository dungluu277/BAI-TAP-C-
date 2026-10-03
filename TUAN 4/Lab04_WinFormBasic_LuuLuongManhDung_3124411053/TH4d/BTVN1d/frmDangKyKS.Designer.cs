namespace BTVN1d
{
    partial class frmDangKyKS
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblSoNgay = new System.Windows.Forms.Label();
            this.txtSoNgay = new System.Windows.Forms.TextBox();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.rdoDon = new System.Windows.Forms.RadioButton();
            this.rdoDoi = new System.Windows.Forms.RadioButton();
            this.rdoBa = new System.Windows.Forms.RadioButton();
            this.lblTienNghi = new System.Windows.Forms.Label();
            this.chkTivi = new System.Windows.Forms.CheckBox();
            this.chkInternet = new System.Windows.Forms.CheckBox();
            this.chkNuocNong = new System.Windows.Forms.CheckBox();
            this.lblDichVu = new System.Windows.Forms.Label();
            this.chkKaraoke = new System.Windows.Forms.CheckBox();
            this.chkAnSang = new System.Windows.Forms.CheckBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnNhapMoi = new System.Windows.Forms.Button();
            this.lblThanhTienCap = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.btnTongKet = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblSoLuotCap = new System.Windows.Forms.Label();
            this.lblSoLuot = new System.Windows.Forms.Label();
            this.lblTongTienCap = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.gbTongKet = new System.Windows.Forms.GroupBox();
            this.gbTongKet.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = false;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(780, 30);
            this.lblTieuDe.Text = "KHÁCH SẠN THANH THANH - TRẢ PHÒNG";
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(30, 78);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(70, 20);
            this.lblTen.Text = "Họ và tên:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(105, 75);
            this.txtTen.Name = "txtTen";
            this.txtTen.TabIndex = 0;
            this.txtTen.Size = new System.Drawing.Size(260, 23);
            this.txtTen.TextChanged += new System.EventHandler(this.KiemTraDuThongTin);
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(42, 115);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(60, 20);
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(105, 112);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.TabIndex = 1;
            this.txtDiaChi.Size = new System.Drawing.Size(360, 23);
            this.txtDiaChi.TextChanged += new System.EventHandler(this.KiemTraDuThongTin);
            // 
            // lblSoNgay
            // 
            this.lblSoNgay.AutoSize = true;
            this.lblSoNgay.Location = new System.Drawing.Point(30, 158);
            this.lblSoNgay.Name = "lblSoNgay";
            this.lblSoNgay.Size = new System.Drawing.Size(70, 20);
            this.lblSoNgay.Text = "Số ngày ở:";
            // 
            // txtSoNgay
            // 
            this.txtSoNgay.Location = new System.Drawing.Point(105, 155);
            this.txtSoNgay.Name = "txtSoNgay";
            this.txtSoNgay.TabIndex = 2;
            this.txtSoNgay.Size = new System.Drawing.Size(100, 23);
            this.txtSoNgay.MaxLength = 4;
            this.txtSoNgay.TextChanged += new System.EventHandler(this.KiemTraDuThongTin);
            this.txtSoNgay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoNgay_KeyPress);
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.AutoSize = true;
            this.lblLoaiPhong.Location = new System.Drawing.Point(30, 205);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(80, 20);
            this.lblLoaiPhong.Text = "Loại phòng";
            // 
            // rdoDon
            // 
            this.rdoDon.AutoSize = true;
            this.rdoDon.Location = new System.Drawing.Point(30, 232);
            this.rdoDon.Name = "rdoDon";
            this.rdoDon.TabIndex = 3;
            this.rdoDon.UseVisualStyleBackColor = true;
            this.rdoDon.Text = "Phòng đơn";
            this.rdoDon.CheckedChanged += new System.EventHandler(this.KiemTraDuThongTin);
            // 
            // rdoDoi
            // 
            this.rdoDoi.AutoSize = true;
            this.rdoDoi.Location = new System.Drawing.Point(30, 262);
            this.rdoDoi.Name = "rdoDoi";
            this.rdoDoi.TabIndex = 4;
            this.rdoDoi.UseVisualStyleBackColor = true;
            this.rdoDoi.Text = "Phòng đôi";
            this.rdoDoi.CheckedChanged += new System.EventHandler(this.KiemTraDuThongTin);
            // 
            // rdoBa
            // 
            this.rdoBa.AutoSize = true;
            this.rdoBa.Location = new System.Drawing.Point(30, 292);
            this.rdoBa.Name = "rdoBa";
            this.rdoBa.TabIndex = 5;
            this.rdoBa.UseVisualStyleBackColor = true;
            this.rdoBa.Text = "Phòng ba";
            this.rdoBa.CheckedChanged += new System.EventHandler(this.KiemTraDuThongTin);
            // 
            // lblTienNghi
            // 
            this.lblTienNghi.AutoSize = true;
            this.lblTienNghi.Location = new System.Drawing.Point(185, 205);
            this.lblTienNghi.Name = "lblTienNghi";
            this.lblTienNghi.Size = new System.Drawing.Size(80, 20);
            this.lblTienNghi.Text = "Tiện nghi";
            // 
            // chkTivi
            // 
            this.chkTivi.AutoSize = true;
            this.chkTivi.Location = new System.Drawing.Point(185, 232);
            this.chkTivi.Name = "chkTivi";
            this.chkTivi.TabIndex = 6;
            this.chkTivi.UseVisualStyleBackColor = true;
            this.chkTivi.Text = "Tivi";
            // 
            // chkInternet
            // 
            this.chkInternet.AutoSize = true;
            this.chkInternet.Location = new System.Drawing.Point(185, 262);
            this.chkInternet.Name = "chkInternet";
            this.chkInternet.TabIndex = 7;
            this.chkInternet.UseVisualStyleBackColor = true;
            this.chkInternet.Text = "Internet";
            // 
            // chkNuocNong
            // 
            this.chkNuocNong.AutoSize = true;
            this.chkNuocNong.Location = new System.Drawing.Point(185, 292);
            this.chkNuocNong.Name = "chkNuocNong";
            this.chkNuocNong.TabIndex = 8;
            this.chkNuocNong.UseVisualStyleBackColor = true;
            this.chkNuocNong.Text = "Máy nước nóng";
            // 
            // lblDichVu
            // 
            this.lblDichVu.AutoSize = true;
            this.lblDichVu.Location = new System.Drawing.Point(340, 205);
            this.lblDichVu.Name = "lblDichVu";
            this.lblDichVu.Size = new System.Drawing.Size(80, 20);
            this.lblDichVu.Text = "Dịch vụ";
            // 
            // chkKaraoke
            // 
            this.chkKaraoke.AutoSize = true;
            this.chkKaraoke.Location = new System.Drawing.Point(340, 245);
            this.chkKaraoke.Name = "chkKaraoke";
            this.chkKaraoke.TabIndex = 9;
            this.chkKaraoke.UseVisualStyleBackColor = true;
            this.chkKaraoke.Text = "Karaoke";
            // 
            // chkAnSang
            // 
            this.chkAnSang.AutoSize = true;
            this.chkAnSang.Location = new System.Drawing.Point(340, 277);
            this.chkAnSang.Name = "chkAnSang";
            this.chkAnSang.TabIndex = 10;
            this.chkAnSang.UseVisualStyleBackColor = true;
            this.chkAnSang.Text = "Ăn sáng";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(520, 75);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.TabIndex = 11;
            this.btnThanhToan.Size = new System.Drawing.Size(100, 30);
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Text = "&Thanh toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnNhapMoi
            // 
            this.btnNhapMoi.Location = new System.Drawing.Point(640, 75);
            this.btnNhapMoi.Name = "btnNhapMoi";
            this.btnNhapMoi.TabIndex = 12;
            this.btnNhapMoi.Size = new System.Drawing.Size(100, 30);
            this.btnNhapMoi.UseVisualStyleBackColor = true;
            this.btnNhapMoi.Text = "&Nhập mới";
            this.btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click);
            // 
            // lblThanhTienCap
            // 
            this.lblThanhTienCap.AutoSize = true;
            this.lblThanhTienCap.Location = new System.Drawing.Point(520, 128);
            this.lblThanhTienCap.Name = "lblThanhTienCap";
            this.lblThanhTienCap.Size = new System.Drawing.Size(70, 20);
            this.lblThanhTienCap.Text = "Thành tiền:";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = false;
            this.lblThanhTien.Location = new System.Drawing.Point(595, 123);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(160, 26);
            this.lblThanhTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThanhTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTongKet
            // 
            this.btnTongKet.Location = new System.Drawing.Point(520, 170);
            this.btnTongKet.Name = "btnTongKet";
            this.btnTongKet.TabIndex = 13;
            this.btnTongKet.Size = new System.Drawing.Size(100, 30);
            this.btnTongKet.UseVisualStyleBackColor = true;
            this.btnTongKet.Text = "Tổng &Kết";
            this.btnTongKet.Click += new System.EventHandler(this.btnTongKet_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(520, 330);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Size = new System.Drawing.Size(100, 30);
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Text = "Th&oát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblSoLuotCap
            // 
            this.lblSoLuotCap.AutoSize = true;
            this.lblSoLuotCap.Location = new System.Drawing.Point(10, 28);
            this.lblSoLuotCap.Name = "lblSoLuotCap";
            this.lblSoLuotCap.Size = new System.Drawing.Size(95, 20);
            this.lblSoLuotCap.Text = "Số lượt người:";
            // 
            // lblSoLuot
            // 
            this.lblSoLuot.AutoSize = false;
            this.lblSoLuot.Location = new System.Drawing.Point(110, 24);
            this.lblSoLuot.Name = "lblSoLuot";
            this.lblSoLuot.Size = new System.Drawing.Size(120, 26);
            this.lblSoLuot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoLuot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTongTienCap
            // 
            this.lblTongTienCap.AutoSize = true;
            this.lblTongTienCap.Location = new System.Drawing.Point(10, 66);
            this.lblTongTienCap.Name = "lblTongTienCap";
            this.lblTongTienCap.Size = new System.Drawing.Size(95, 20);
            this.lblTongTienCap.Text = "Tổng số tiền:";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = false;
            this.lblTongTien.Location = new System.Drawing.Point(110, 62);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(120, 26);
            this.lblTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbTongKet
            // 
            this.gbTongKet.Location = new System.Drawing.Point(520, 215);
            this.gbTongKet.Name = "gbTongKet";
            this.gbTongKet.Size = new System.Drawing.Size(240, 100);
            this.gbTongKet.Text = "Thông tin tổng kết";
            this.gbTongKet.Controls.Add(this.lblSoLuotCap);
            this.gbTongKet.Controls.Add(this.lblSoLuot);
            this.gbTongKet.Controls.Add(this.lblTongTienCap);
            this.gbTongKet.Controls.Add(this.lblTongTien);
            // 
            // frmDangKyKS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 390);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblSoNgay);
            this.Controls.Add(this.txtSoNgay);
            this.Controls.Add(this.lblLoaiPhong);
            this.Controls.Add(this.rdoDon);
            this.Controls.Add(this.rdoDoi);
            this.Controls.Add(this.rdoBa);
            this.Controls.Add(this.lblTienNghi);
            this.Controls.Add(this.chkTivi);
            this.Controls.Add(this.chkInternet);
            this.Controls.Add(this.chkNuocNong);
            this.Controls.Add(this.lblDichVu);
            this.Controls.Add(this.chkKaraoke);
            this.Controls.Add(this.chkAnSang);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnNhapMoi);
            this.Controls.Add(this.lblThanhTienCap);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.btnTongKet);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.gbTongKet);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDangKyKS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDangKyKS";
            this.Load += new System.EventHandler(this.frmDangKyKS_Load);
            this.gbTongKet.ResumeLayout(false);
            this.gbTongKet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblTen;
        private TextBox txtTen;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Label lblSoNgay;
        private TextBox txtSoNgay;
        private Label lblLoaiPhong;
        private RadioButton rdoDon;
        private RadioButton rdoDoi;
        private RadioButton rdoBa;
        private Label lblTienNghi;
        private CheckBox chkTivi;
        private CheckBox chkInternet;
        private CheckBox chkNuocNong;
        private Label lblDichVu;
        private CheckBox chkKaraoke;
        private CheckBox chkAnSang;
        private Button btnThanhToan;
        private Button btnNhapMoi;
        private Label lblThanhTienCap;
        private Label lblThanhTien;
        private Button btnTongKet;
        private Button btnThoat;
        private Label lblSoLuotCap;
        private Label lblSoLuot;
        private Label lblTongTienCap;
        private Label lblTongTien;
        private GroupBox gbTongKet;
    }
}
