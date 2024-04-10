namespace AutoGenerateCertificate
{
    partial class FrmSelect
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_WOC1 = new ePOSOne.btnProduct.Button_WOC();
            this.button_WOC2 = new ePOSOne.btnProduct.Button_WOC();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(847, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 32);
            this.button2.TabIndex = 34;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(882, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 32);
            this.button1.TabIndex = 33;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_WOC1
            // 
            this.button_WOC1.BorderColor = System.Drawing.Color.Silver;
            this.button_WOC1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_WOC1.FlatAppearance.BorderSize = 0;
            this.button_WOC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WOC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WOC1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button_WOC1.Location = new System.Drawing.Point(294, 105);
            this.button_WOC1.Name = "button_WOC1";
            this.button_WOC1.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.button_WOC1.OnHoverButtonColor = System.Drawing.Color.MediumSeaGreen;
            this.button_WOC1.OnHoverTextColor = System.Drawing.Color.Black;
            this.button_WOC1.Size = new System.Drawing.Size(308, 91);
            this.button_WOC1.TabIndex = 36;
            this.button_WOC1.Text = "Admin Login";
            this.button_WOC1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button_WOC1.UseVisualStyleBackColor = true;
            this.button_WOC1.Click += new System.EventHandler(this.button_WOC1_Click);
            // 
            // button_WOC2
            // 
            this.button_WOC2.BorderColor = System.Drawing.Color.Silver;
            this.button_WOC2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_WOC2.FlatAppearance.BorderSize = 0;
            this.button_WOC2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WOC2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WOC2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button_WOC2.Location = new System.Drawing.Point(294, 263);
            this.button_WOC2.Name = "button_WOC2";
            this.button_WOC2.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.button_WOC2.OnHoverButtonColor = System.Drawing.Color.MediumSeaGreen;
            this.button_WOC2.OnHoverTextColor = System.Drawing.Color.Black;
            this.button_WOC2.Size = new System.Drawing.Size(308, 91);
            this.button_WOC2.TabIndex = 36;
            this.button_WOC2.Text = "User Login";
            this.button_WOC2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button_WOC2.UseVisualStyleBackColor = true;
            this.button_WOC2.Visible = false;
            this.button_WOC2.Click += new System.EventHandler(this.button_WOC2_Click);
            // 
            // FrmSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(912, 547);
            this.Controls.Add(this.button_WOC2);
            this.Controls.Add(this.button_WOC1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSelect";
            this.Load += new System.EventHandler(this.FrmSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private ePOSOne.btnProduct.Button_WOC button_WOC1;
        private ePOSOne.btnProduct.Button_WOC button_WOC2;
    }
}