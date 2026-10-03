namespace BaiTap4C
{
    partial class Form1
    {
       
        private System.ComponentModel.IContainer components = null;

        
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            errorProvider1 = new ErrorProvider(components);
            Tinputa = new Label();
            Tinputb = new Label();
            Tresult = new Label();
            inputa = new TextBox();
            result = new TextBox();
            inputb = new TextBox();
            plus = new Button();
            minus = new Button();
            multiply = new Button();
            divide = new Button();
            SuspendLayout();
            // 
            // Tinputa
            // 
            Tinputa.AutoSize = true;
            Tinputa.Location = new Point(58, 43);
            Tinputa.Name = "Tinputa";
            Tinputa.Size = new Size(24, 15);
            Tinputa.TabIndex = 0;
            Tinputa.Text = "a =";
            // 
            // Tinputb
            // 
            Tinputb.AutoSize = true;
            Tinputb.Location = new Point(219, 43);
            Tinputb.Name = "Tinputb";
            Tinputb.Size = new Size(25, 15);
            Tinputb.TabIndex = 1;
            Tinputb.Text = "b =";
            // 
            // Tresult
            // 
            Tresult.AutoSize = true;
            Tresult.Location = new Point(58, 87);
            Tresult.Name = "Tresult";
            Tresult.Size = new Size(47, 15);
            Tresult.TabIndex = 2;
            Tresult.Text = "Kết quả";
            // 
            // inputa
            // 
            inputa.Location = new Point(111, 35);
            inputa.Name = "inputa";
            inputa.Size = new Size(68, 23);
            inputa.TabIndex = 3;
            // 
            // result
            // 
            result.Location = new Point(111, 84);
            result.Name = "result";
            result.Size = new Size(252, 23);
            result.TabIndex = 5;
            // 
            // inputb
            // 
            inputb.Location = new Point(295, 35);
            inputb.Name = "inputb";
            inputb.Size = new Size(68, 23);
            inputb.TabIndex = 6;
            // 
            // plus
            // 
            plus.Location = new Point(68, 123);
            plus.Name = "plus";
            plus.Size = new Size(60, 35);
            plus.TabIndex = 7;
            plus.Text = "+";
            plus.UseVisualStyleBackColor = true;
            plus.Click += button1_plus;
            // 
            // minus
            // 
            minus.Location = new Point(147, 123);
            minus.Name = "minus";
            minus.Size = new Size(60, 35);
            minus.TabIndex = 8;
            minus.Text = "-";
            minus.UseVisualStyleBackColor = true;
            minus.Click += button2_minus;
            // 
            // multiply
            // 
            multiply.Location = new Point(228, 123);
            multiply.Name = "multiply";
            multiply.Size = new Size(60, 35);
            multiply.TabIndex = 9;
            multiply.Text = "x";
            multiply.UseVisualStyleBackColor = true;
            multiply.Click += button3_multiply;
            // 
            // divide
            // 
            divide.Location = new Point(303, 123);
            divide.Name = "divide";
            divide.Size = new Size(60, 35);
            divide.TabIndex = 10;
            divide.Text = "/";
            divide.UseVisualStyleBackColor = true;
            divide.Click += button4_divide;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 184);
            Controls.Add(divide);
            Controls.Add(multiply);
            Controls.Add(minus);
            Controls.Add(plus);
            Controls.Add(inputb);
            Controls.Add(result);
            Controls.Add(inputa);
            Controls.Add(Tresult);
            Controls.Add(Tinputb);
            Controls.Add(Tinputa);
            Name = "Form1";
            Text = "Cộng trừ nhân chia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Tinputa;
        private Label Tinputb;
        private Label Tresult;
        private TextBox inputa;
        private TextBox result;
        private TextBox inputb;
        private Button plus;
        private Button minus;
        private Button multiply;
        private Button divide;
        private ErrorProvider errorProvider1;
    }
}
