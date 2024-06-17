namespace Test_demo2
{
    partial class Reg_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Reg_btn = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pass_box = new TextBox();
            login_box = new TextBox();
            SuspendLayout();
            // 
            // Reg_btn
            // 
            Reg_btn.Location = new Point(13, 135);
            Reg_btn.Name = "Reg_btn";
            Reg_btn.Size = new Size(198, 29);
            Reg_btn.TabIndex = 11;
            Reg_btn.Text = "Регистрация";
            Reg_btn.UseVisualStyleBackColor = true;
            Reg_btn.Click += Reg_btn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(49, 7);
            label3.Name = "label3";
            label3.Size = new Size(128, 25);
            label3.TabIndex = 10;
            label3.Text = "Регистрация";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(13, 88);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 9;
            label2.Text = "Пароль";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(13, 44);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 8;
            label1.Text = "Логин";
            // 
            // pass_box
            // 
            pass_box.Location = new Point(13, 106);
            pass_box.Name = "pass_box";
            pass_box.Size = new Size(200, 23);
            pass_box.TabIndex = 7;
            // 
            // login_box
            // 
            login_box.Location = new Point(13, 62);
            login_box.Name = "login_box";
            login_box.Size = new Size(200, 23);
            login_box.TabIndex = 6;
            // 
            // Reg_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 192);
            ClientSize = new Size(226, 179);
            Controls.Add(Reg_btn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pass_box);
            Controls.Add(login_box);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MinimizeBox = false;
            Name = "Reg_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Регистрация";
            FormClosing += Reg_form_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Reg_btn;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox pass_box;
        private TextBox login_box;
    }
}