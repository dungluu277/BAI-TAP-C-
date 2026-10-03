namespace bai2new
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            Tdangky = new Label();
            name = new Label();
            email = new Label();
            pass = new Label();
            ConfPass = new Label();
            Iname = new TextBox();
            IConfPass = new TextBox();
            Ipass = new TextBox();
            Iemail = new TextBox();
            signin = new Button();
            SuspendLayout();
            // 
            // Tdangky
            // 
            Tdangky.Anchor = AnchorStyles.Top;
            Tdangky.AutoSize = true;
            Tdangky.Font = new Font("Segoe UI", 20F);
            Tdangky.ImageAlign = ContentAlignment.TopCenter;
            Tdangky.Location = new Point(208, 9);
            Tdangky.Name = "Tdangky";
            Tdangky.Size = new Size(289, 46);
            Tdangky.TabIndex = 0;
            Tdangky.Text = "Đăng ký tài khoản";
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(68, 77);
            name.Name = "name";
            name.Size = new Size(127, 20);
            name.TabIndex = 1;
            name.Text = "Tên đăng nhập (*)";
            // 
            // email
            // 
            email.AutoSize = true;
            email.Location = new Point(68, 111);
            email.Name = "email";
            email.Size = new Size(116, 20);
            email.TabIndex = 2;
            email.Text = "Địa chỉ email (*)";
            // 
            // pass
            // 
            pass.AutoSize = true;
            pass.Location = new Point(68, 149);
            pass.Name = "pass";
            pass.Size = new Size(90, 20);
            pass.TabIndex = 3;
            pass.Text = "Mật khẩu (*)";
            // 
            // ConfPass
            // 
            ConfPass.AutoSize = true;
            ConfPass.Location = new Point(68, 184);
            ConfPass.Name = "ConfPass";
            ConfPass.Size = new Size(134, 20);
            ConfPass.TabIndex = 4;
            ConfPass.Text = "Xác nhận mật khẩu";
            // 
            // Iname
            // 
            Iname.Location = new Point(208, 74);
            Iname.Name = "Iname";
            Iname.Size = new Size(337, 27);
            Iname.TabIndex = 5;
            Iname.UseSystemPasswordChar = true;
            // 
            // IConfPass
            // 
            IConfPass.Location = new Point(208, 177);
            IConfPass.Name = "IConfPass";
            IConfPass.Size = new Size(337, 27);
            IConfPass.TabIndex = 6;
            // 
            // Ipass
            // 
            Ipass.Location = new Point(208, 142);
            Ipass.Name = "Ipass";
            Ipass.Size = new Size(337, 27);
            Ipass.TabIndex = 7;
            // 
            // Iemail
            // 
            Iemail.Location = new Point(208, 108);
            Iemail.Name = "Iemail";
            Iemail.Size = new Size(337, 27);
            Iemail.TabIndex = 8;
            // 
            // signin
            // 
            signin.Location = new Point(285, 229);
            signin.Name = "signin";
            signin.Size = new Size(94, 29);
            signin.TabIndex = 9;
            signin.Text = "Đăng ký";
            signin.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            ClientSize = new Size(689, 304);
            Controls.Add(signin);
            Controls.Add(Iemail);
            Controls.Add(Ipass);
            Controls.Add(IConfPass);
            Controls.Add(Iname);
            Controls.Add(ConfPass);
            Controls.Add(pass);
            Controls.Add(email);
            Controls.Add(name);
            Controls.Add(Tdangky);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();

        }



        private Label Tdangkytk;
        private Label Tdangky;
        private Label name;
        private Label email;
        private Label pass;
        private Label ConfPass;
        private TextBox Iname;
        private TextBox IConfPass;
        private TextBox Ipass;
        private TextBox Iemail;
        private Button signin;
        private ErrorProvider errorProvider1;
    }
}
