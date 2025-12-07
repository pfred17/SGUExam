namespace GUI.forms.hocphan
{
    partial class frmChiTietDiem
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
            dgvBangDiem = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBangDiem).BeginInit();
            SuspendLayout();
            // 
            // dgvBangDiem
            // 
            dgvBangDiem.AllowUserToAddRows = false;
            dgvBangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBangDiem.BackgroundColor = Color.White;
            dgvBangDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBangDiem.Dock = DockStyle.Fill;
            dgvBangDiem.Location = new Point(0, 0);
            dgvBangDiem.Name = "dgvBangDiem";
            dgvBangDiem.ReadOnly = true;
            dgvBangDiem.RowHeadersWidth = 62;
            dgvBangDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBangDiem.Size = new Size(1098, 674);
            dgvBangDiem.TabIndex = 0;
            dgvBangDiem.CellContentClick += dataGridView1_CellContentClick;
            // 
            // frmChiTietDiem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1098, 674);
            Controls.Add(dgvBangDiem);
            Name = "frmChiTietDiem";
            Text = "frmChiTietDiem";
            ((System.ComponentModel.ISupportInitialize)dgvBangDiem).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvBangDiem;
    }
}