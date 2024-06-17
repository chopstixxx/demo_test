namespace Test_demo2
{
    partial class Auth_form
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            login_box = new TextBox();
            pass_box = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Auth_btn = new Button();
            Reg_btn = new Button();
            SuspendLayout();
            // 
            // login_box
            // 
            login_box.Location = new Point(11, 64);
            login_box.Name = "login_box";
            login_box.Size = new Size(154, 23);
            login_box.TabIndex = 0;
            // 
            // pass_box
            // 
            pass_box.Location = new Point(11, 108);
            pass_box.Name = "pass_box";
            pass_box.Size = new Size(154, 23);
            pass_box.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(11, 48);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 2;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(11, 90);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 3;
            label2.Text = "Пароль";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(11, 9);
            label3.Name = "label3";
            label3.Size = new Size(135, 25);
            label3.TabIndex = 4;
            label3.Text = "Авторизация";
            // 
            // Auth_btn
            // 
            Auth_btn.Location = new Point(11, 137);
            Auth_btn.Name = "Auth_btn";
            Auth_btn.Size = new Size(152, 29);
            Auth_btn.TabIndex = 5;
            Auth_btn.Text = "Войти";
            Auth_btn.UseVisualStyleBackColor = true;
            Auth_btn.Click += Auth_btn_Click;
            // 
            // Reg_btn
            // 
            Reg_btn.Location = new Point(11, 172);
            Reg_btn.Name = "Reg_btn";
            Reg_btn.Size = new Size(152, 29);
            Reg_btn.TabIndex = 6;
            Reg_btn.Text = "Регистрация";
            Reg_btn.UseVisualStyleBackColor = true;
            Reg_btn.Click += Reg_btn_Click;
            // 
            // Auth_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 192);
            ClientSize = new Size(176, 213);
            Controls.Add(Reg_btn);
            Controls.Add(Auth_btn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pass_box);
            Controls.Add(login_box);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Auth_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox login_box;
        private TextBox pass_box;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button Auth_btn;
        private Button Reg_btn;
    }
}