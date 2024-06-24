namespace WindowsFormsApp1
{
    partial class pesan_wa
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
            this.Mst_grid_View = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtidpesan = new System.Windows.Forms.TextBox();
            this.txtpesan = new System.Windows.Forms.TextBox();
            this.txtnohp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnbalas = new System.Windows.Forms.Button();
            this.btnkeluar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Mst_grid_View)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mst_grid_View
            // 
            this.Mst_grid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Mst_grid_View.Location = new System.Drawing.Point(12, 12);
            this.Mst_grid_View.Name = "Mst_grid_View";
            this.Mst_grid_View.Size = new System.Drawing.Size(519, 217);
            this.Mst_grid_View.TabIndex = 0;
            this.Mst_grid_View.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.Mst_grid_View.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Mst_grid_View_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtidpesan);
            this.groupBox1.Controls.Add(this.txtpesan);
            this.groupBox1.Controls.Add(this.txtnohp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 151);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtidpesan
            // 
            this.txtidpesan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidpesan.Location = new System.Drawing.Point(209, 16);
            this.txtidpesan.Name = "txtidpesan";
            this.txtidpesan.Size = new System.Drawing.Size(155, 20);
            this.txtidpesan.TabIndex = 8;
            this.txtidpesan.Visible = false;
            // 
            // txtpesan
            // 
            this.txtpesan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpesan.Location = new System.Drawing.Point(49, 38);
            this.txtpesan.Multiline = true;
            this.txtpesan.Name = "txtpesan";
            this.txtpesan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtpesan.Size = new System.Drawing.Size(329, 102);
            this.txtpesan.TabIndex = 7;
            // 
            // txtnohp
            // 
            this.txtnohp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnohp.Location = new System.Drawing.Point(48, 16);
            this.txtnohp.Name = "txtnohp";
            this.txtnohp.Size = new System.Drawing.Size(155, 20);
            this.txtnohp.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pesan";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(36, 14);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "No HP";
            // 
            // btnbalas
            // 
            this.btnbalas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbalas.Location = new System.Drawing.Point(62, 392);
            this.btnbalas.Name = "btnbalas";
            this.btnbalas.Size = new System.Drawing.Size(75, 23);
            this.btnbalas.TabIndex = 2;
            this.btnbalas.Text = "Balas";
            this.btnbalas.UseVisualStyleBackColor = true;
            this.btnbalas.Click += new System.EventHandler(this.btnbalas_Click);
            // 
            // btnkeluar
            // 
            this.btnkeluar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnkeluar.Location = new System.Drawing.Point(143, 392);
            this.btnkeluar.Name = "btnkeluar";
            this.btnkeluar.Size = new System.Drawing.Size(75, 23);
            this.btnkeluar.TabIndex = 3;
            this.btnkeluar.Text = "Keluar";
            this.btnkeluar.UseVisualStyleBackColor = true;
            this.btnkeluar.Visible = false;
            // 
            // pesan_wa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(544, 421);
            this.Controls.Add(this.btnkeluar);
            this.Controls.Add(this.btnbalas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Mst_grid_View);
            this.Name = "pesan_wa";
            this.Text = "pesan_wa";
            this.Load += new System.EventHandler(this.pesan_wa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Mst_grid_View)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Mst_grid_View;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtpesan;
        private System.Windows.Forms.TextBox txtnohp;
        private System.Windows.Forms.Button btnbalas;
        private System.Windows.Forms.Button btnkeluar;
        private System.Windows.Forms.TextBox txtidpesan;
    }
}