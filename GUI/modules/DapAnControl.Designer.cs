namespace GUI.modules
{
    partial class DapAnControl
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            rtbNoiDung = new RichTextBox();
            chkDung = new CheckBox();
            btnXoa = new Button();
            SuspendLayout();
            // 
            // rtbNoiDung
            // 
            rtbNoiDung.Location = new Point(3, 3);
            rtbNoiDung.Name = "rtbNoiDung";
            rtbNoiDung.Size = new Size(340, 67);
            rtbNoiDung.TabIndex = 2;
            rtbNoiDung.Text = "";
            // 
            // chkDung
            // 
            chkDung.AutoSize = true;
            chkDung.Location = new Point(348, 5);
            chkDung.Name = "chkDung";
            chkDung.Size = new Size(142, 29);
            chkDung.TabIndex = 1;
            chkDung.Text = "Đáp án đúng";
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(348, 40);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(30, 30);
            btnXoa.TabIndex = 0;
            btnXoa.Text = "X";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // DapAnControl
            // 
            Controls.Add(btnXoa);
            Controls.Add(chkDung);
            Controls.Add(rtbNoiDung);
            Name = "DapAnControl";
            Size = new Size(529, 215);
            ResumeLayout(false);
            PerformLayout();
        }

        private RichTextBox rtbNoiDung;
        private CheckBox chkDung;
        private Button btnXoa;
    }
}