namespace Bai1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;
        private Label lblTitle = null!;
        private GroupBox grpEquationType = null!;
        private RadioButton rdoLinear = null!;
        private RadioButton rdoQuadratic = null!;
        private Label lblA = null!;
        private Label lblB = null!;
        private Label lblC = null!;
        private Label lblResult = null!;
        private TextBox txtA = null!;
        private TextBox txtB = null!;
        private TextBox txtC = null!;
        private TextBox txtResult = null!;
        private Button btnSolve = null!;
        private Button btnExit = null!;

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
            grpEquationType = new GroupBox();
            rdoLinear = new RadioButton();
            rdoQuadratic = new RadioButton();
            lblA = new Label();
            lblB = new Label();
            lblC = new Label();
            lblResult = new Label();
            txtA = new TextBox();
            txtB = new TextBox();
            txtC = new TextBox();
            txtResult = new TextBox();
            btnSolve = new Button();
            btnExit = new Button();
            grpEquationType.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Times New Roman", 17F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Red;
            lblTitle.Location = new Point(20, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "GIẢI PHƯƠNG TRÌNH";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpEquationType
            // 
            grpEquationType.Controls.Add(rdoLinear);
            grpEquationType.Controls.Add(rdoQuadratic);
            grpEquationType.Font = new Font("Times New Roman", 10F);
            grpEquationType.Location = new Point(22, 60);
            grpEquationType.Name = "grpEquationType";
            grpEquationType.Size = new Size(348, 84);
            grpEquationType.TabIndex = 1;
            grpEquationType.TabStop = false;
            grpEquationType.Text = "Bạn vui lòng chọn";
            // 
            // rdoLinear
            // 
            rdoLinear.AutoSize = true;
            rdoLinear.Checked = true;
            rdoLinear.Location = new Point(18, 24);
            rdoLinear.Name = "rdoLinear";
            rdoLinear.Size = new Size(151, 19);
            rdoLinear.TabIndex = 0;
            rdoLinear.TabStop = true;
            rdoLinear.Text = "Phương trình bậc nhất";
            rdoLinear.UseVisualStyleBackColor = true;
            rdoLinear.CheckedChanged += EquationType_CheckedChanged;
            // 
            // rdoQuadratic
            // 
            rdoQuadratic.AutoSize = true;
            rdoQuadratic.Location = new Point(18, 51);
            rdoQuadratic.Name = "rdoQuadratic";
            rdoQuadratic.Size = new Size(150, 19);
            rdoQuadratic.TabIndex = 1;
            rdoQuadratic.Text = "Phương trình bậc hai";
            rdoQuadratic.UseVisualStyleBackColor = true;
            rdoQuadratic.CheckedChanged += EquationType_CheckedChanged;
            // 
            // Labels
            // 
            lblA.AutoSize = true;
            lblA.Location = new Point(25, 164);
            lblA.Name = "lblA";
            lblA.Size = new Size(42, 16);
            lblA.TabIndex = 2;
            lblA.Text = "Nhập a";
            lblB.AutoSize = true;
            lblB.Location = new Point(25, 198);
            lblB.Name = "lblB";
            lblB.Size = new Size(42, 16);
            lblB.TabIndex = 3;
            lblB.Text = "Nhập b";
            lblC.AutoSize = true;
            lblC.Enabled = false;
            lblC.Location = new Point(25, 232);
            lblC.Name = "lblC";
            lblC.Size = new Size(42, 16);
            lblC.TabIndex = 4;
            lblC.Text = "Nhập c";
            lblResult.AutoSize = true;
            lblResult.Location = new Point(25, 272);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(44, 16);
            lblResult.TabIndex = 5;
            lblResult.Text = "Kết quả";
            // 
            // Text boxes
            // 
            txtA.Location = new Point(105, 160);
            txtA.Name = "txtA";
            txtA.Size = new Size(135, 23);
            txtA.TabIndex = 6;
            txtA.TextChanged += Input_TextChanged;
            txtB.Location = new Point(105, 194);
            txtB.Name = "txtB";
            txtB.Size = new Size(135, 23);
            txtB.TabIndex = 7;
            txtB.TextChanged += Input_TextChanged;
            txtC.Enabled = false;
            txtC.Location = new Point(105, 228);
            txtC.Name = "txtC";
            txtC.Size = new Size(135, 23);
            txtC.TabIndex = 8;
            txtC.TextChanged += Input_TextChanged;
            txtResult.Location = new Point(105, 266);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(265, 78);
            txtResult.TabIndex = 9;
            // 
            // Buttons
            // 
            btnSolve.Enabled = false;
            btnSolve.Location = new Point(258, 158);
            btnSolve.Name = "btnSolve";
            btnSolve.Size = new Size(94, 40);
            btnSolve.TabIndex = 10;
            btnSolve.Text = "Giải";
            btnSolve.UseVisualStyleBackColor = true;
            btnSolve.Click += BtnSolve_Click;
            btnExit.Location = new Point(258, 204);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 40);
            btnExit.TabIndex = 11;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 365);
            Controls.Add(btnExit);
            Controls.Add(btnSolve);
            Controls.Add(txtResult);
            Controls.Add(txtC);
            Controls.Add(txtB);
            Controls.Add(txtA);
            Controls.Add(lblResult);
            Controls.Add(lblC);
            Controls.Add(lblB);
            Controls.Add(lblA);
            Controls.Add(grpEquationType);
            Controls.Add(lblTitle);
            Font = new Font("Times New Roman", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giải phương trình bậc 1-2";
            FormClosing += Form1_FormClosing;
            grpEquationType.ResumeLayout(false);
            grpEquationType.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
