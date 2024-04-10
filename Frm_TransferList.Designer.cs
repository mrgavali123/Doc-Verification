namespace AutoGenerateCertificate
{
    partial class Frm_TransferList
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
            this.button_WOC1 = new ePOSOne.btnProduct.Button_WOC();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_WOC1
            // 
            this.button_WOC1.BorderColor = System.Drawing.Color.Silver;
            this.button_WOC1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button_WOC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WOC1.Location = new System.Drawing.Point(512, 12);
            this.button_WOC1.Name = "button_WOC1";
            this.button_WOC1.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.button_WOC1.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.button_WOC1.OnHoverTextColor = System.Drawing.Color.Gray;
            this.button_WOC1.Size = new System.Drawing.Size(146, 45);
            this.button_WOC1.TabIndex = 2;
            this.button_WOC1.Text = "Show Data";
            this.button_WOC1.TextColor = System.Drawing.Color.White;
            this.button_WOC1.UseVisualStyleBackColor = true;
            this.button_WOC1.Click += new System.EventHandler(this.button_WOC1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-20, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1331, 684);
            this.dataGridView1.TabIndex = 3;
            // 
            // Frm_TransferList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1547, 739);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_WOC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_TransferList";
            this.Text = "Frm_TransferList";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ePOSOne.btnProduct.Button_WOC button_WOC1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}