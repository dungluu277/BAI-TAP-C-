namespace Bai4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblInput;
        private Label lblSequence;
        private Label lblTotal;
        private Label lblEven;
        private Label lblOdd;
        private TextBox txtInput;
        private TextBox txtSequence;
        private TextBox txtTotal;
        private TextBox txtEven;
        private TextBox txtOdd;
        private Button btnNhap;
        private Button btnCalculate;
        private Button btnContinue;
        private Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblInput = new Label();
            lblSequence = new Label();
            lblTotal = new Label();
            lblEven = new Label();
            lblOdd = new Label();
            txtInput = new TextBox();
            txtSequence = new TextBox();
            txtTotal = new TextBox();
            txtEven = new TextBox();
            txtOdd = new TextBox();
            btnNhap = new Button();
            btnCalculate = new Button();
            btnContinue = new Button();
            btnExit = new Button();
            SuspendLayout();

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Red;
            lblTitle.Location = new Point(24, 18);
            lblTitle.Text = "Nhập Dãy Số và Tính Tổng";

            lblInput.AutoSize = true;
            lblInput.Location = new Point(38, 80);
            lblInput.Text = "Nhập số:";

            txtInput.Location = new Point(132, 76);
            txtInput.Size = new Size(90, 23);

            btnNhap.Location = new Point(242, 74);
            btnNhap.Size = new Size(88, 28);
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;

            lblSequence.AutoSize = true;
            lblSequence.Location = new Point(38, 119);
            lblSequence.Text = "Dãy vừa nhập:";

            txtSequence.Location = new Point(132, 115);
            txtSequence.ReadOnly = true;
            txtSequence.Size = new Size(198, 23);

            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(38, 158);
            lblTotal.Text = "Tổng các phần tử:";

            txtTotal.Location = new Point(168, 154);
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(72, 23);

            lblEven.AutoSize = true;
            lblEven.Location = new Point(38, 197);
            lblEven.Text = "Tổng Chẵn:";

            txtEven.Location = new Point(112, 193);
            txtEven.ReadOnly = true;
            txtEven.Size = new Size(64, 23);

            lblOdd.AutoSize = true;
            lblOdd.Location = new Point(190, 197);
            lblOdd.Text = "Tổng Lẻ:";

            txtOdd.Location = new Point(252, 193);
            txtOdd.ReadOnly = true;
            txtOdd.Size = new Size(78, 23);

            btnCalculate.Location = new Point(38, 238);
            btnCalculate.Size = new Size(96, 30);
            btnCalculate.Text = "Tính Tổng";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;

            btnContinue.Location = new Point(145, 238);
            btnContinue.Size = new Size(88, 30);
            btnContinue.Text = "Tiếp Tục";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;

            btnExit.Location = new Point(242, 238);
            btnExit.Size = new Size(88, 30);
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 300);
            Controls.Add(lblTitle);
            Controls.Add(lblInput);
            Controls.Add(txtInput);
            Controls.Add(btnNhap);
            Controls.Add(lblSequence);
            Controls.Add(txtSequence);
            Controls.Add(lblTotal);
            Controls.Add(txtTotal);
            Controls.Add(lblEven);
            Controls.Add(txtEven);
            Controls.Add(lblOdd);
            Controls.Add(txtOdd);
            Controls.Add(btnCalculate);
            Controls.Add(btnContinue);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dãy số và Tính Tổng";
            ResumeLayout(false);
            PerformLayout();
        }

    }
}
