namespace bai3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;
        private Label lblTitle = null!;
        private Label lblA = null!;
        private Label lblB = null!;
        private Label lblGcd = null!;
        private Label lblLcm = null!;
        private TextBox txtA = null!;
        private TextBox txtB = null!;
        private TextBox txtGcd = null!;
        private TextBox txtLcm = null!;
        private Button btnCalculate = null!;
        private Button btnContinue = null!;
        private Button btnExit = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblA = new Label();
            lblB = new Label();
            lblGcd = new Label();
            lblLcm = new Label();
            txtA = new TextBox();
            txtB = new TextBox();
            txtGcd = new TextBox();
            txtLcm = new TextBox();
            btnCalculate = new Button();
            btnContinue = new Button();
            btnExit = new Button();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.Font = new Font("Times New Roman", 21F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Red;
            lblTitle.Location = new Point(18, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(504, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Ước Số Chung - Bội Số Chung";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblA
            //
            lblA.Location = new Point(38, 100);
            lblA.Name = "lblA";
            lblA.Size = new Size(190, 30);
            lblA.TabIndex = 1;
            lblA.Text = "Nhập số a:";
            lblA.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblB
            //
            lblB.Location = new Point(38, 148);
            lblB.Name = "lblB";
            lblB.Size = new Size(190, 30);
            lblB.TabIndex = 2;
            lblB.Text = "Nhập số b:";
            lblB.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblGcd
            //
            lblGcd.Location = new Point(18, 196);
            lblGcd.Name = "lblGcd";
            lblGcd.Size = new Size(255, 30);
            lblGcd.TabIndex = 3;
            lblGcd.Text = "Ước số chung lớn nhất:";
            lblGcd.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblLcm
            //
            lblLcm.Location = new Point(18, 244);
            lblLcm.Name = "lblLcm";
            lblLcm.Size = new Size(255, 30);
            lblLcm.TabIndex = 4;
            lblLcm.Text = "Bội số chung nhỏ nhất:";
            lblLcm.TextAlign = ContentAlignment.MiddleRight;
            //
            // txtA
            //
            txtA.Location = new Point(244, 100);
            txtA.Name = "txtA";
            txtA.Size = new Size(205, 30);
            txtA.TabIndex = 0;
            //
            // txtB
            //
            txtB.Location = new Point(244, 148);
            txtB.Name = "txtB";
            txtB.Size = new Size(205, 30);
            txtB.TabIndex = 1;
            //
            // txtGcd
            //
            txtGcd.Location = new Point(284, 196);
            txtGcd.Name = "txtGcd";
            txtGcd.ReadOnly = true;
            txtGcd.Size = new Size(165, 30);
            txtGcd.TabIndex = 2;
            //
            // txtLcm
            //
            txtLcm.Location = new Point(284, 244);
            txtLcm.Name = "txtLcm";
            txtLcm.ReadOnly = true;
            txtLcm.Size = new Size(165, 30);
            txtLcm.TabIndex = 3;
            //
            // btnCalculate
            //
            btnCalculate.Location = new Point(28, 310);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(145, 46);
            btnCalculate.TabIndex = 4;
            btnCalculate.Text = "Thực Hiện";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            //
            // btnContinue
            //
            btnContinue.Location = new Point(190, 310);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(145, 46);
            btnContinue.TabIndex = 5;
            btnContinue.Text = "Tiếp Tục";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;
            //
            // btnExit
            //
            btnExit.Location = new Point(352, 310);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(145, 46);
            btnExit.TabIndex = 6;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            //
            // Form1
            //
            AcceptButton = btnCalculate;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 390);
            Controls.Add(btnExit);
            Controls.Add(btnContinue);
            Controls.Add(btnCalculate);
            Controls.Add(txtLcm);
            Controls.Add(txtGcd);
            Controls.Add(txtB);
            Controls.Add(txtA);
            Controls.Add(lblLcm);
            Controls.Add(lblGcd);
            Controls.Add(lblB);
            Controls.Add(lblA);
            Controls.Add(lblTitle);
            Font = new Font("Times New Roman", 14F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ước Số - Bội Số";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}