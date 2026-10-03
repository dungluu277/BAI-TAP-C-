namespace bai5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblPrompt;
        private TextBox txtNumber;
        private Button btnConvert;
        private Button btnClear;
        private Button btnExit;
        private TextBox txtResult;

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
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblPrompt = new Label();
            txtNumber = new TextBox();
            btnConvert = new Button();
            btnClear = new Button();
            btnExit = new Button();
            txtResult = new TextBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Red;
            lblTitle.Location = new Point(20, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(420, 42);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đọc Số Thành Chữ";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(35, 83);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(182, 20);
            lblPrompt.TabIndex = 1;
            lblPrompt.Text = "Nhập dãy số (từ 1 đến 999):";
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(235, 80);
            txtNumber.MaxLength = 3;
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(190, 27);
            txtNumber.TabIndex = 2;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(35, 125);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(120, 36);
            btnConvert.TabIndex = 3;
            btnConvert.Text = "Thực hiện";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(175, 125);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 36);
            btnClear.TabIndex = 4;
            btnClear.Text = "Xóa";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(315, 125);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(110, 36);
            btnExit.TabIndex = 5;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // txtResult
            // 
            txtResult.BackColor = Color.Linen;
            txtResult.ForeColor = Color.Blue;
            txtResult.Location = new Point(35, 177);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(390, 27);
            txtResult.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 231);
            Controls.Add(txtResult);
            Controls.Add(btnExit);
            Controls.Add(btnClear);
            Controls.Add(btnConvert);
            Controls.Add(txtNumber);
            Controls.Add(lblPrompt);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tam Gía - Đọc Chữ Số";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
