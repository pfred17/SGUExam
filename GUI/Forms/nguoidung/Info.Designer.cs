using System.Drawing;
using System.Windows.Forms;

namespace GUI.Forms.nguoidung
{
    partial class Info
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            cardPanel = new Guna.UI2.WinForms.Guna2Panel();
            pbAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            separatorLine = new Guna.UI2.WinForms.Guna2Separator();
            btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            showName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            showUsename = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblEmail = new Guna.UI2.WinForms.Guna2HtmlLabel();
            showEmail = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblRole = new Guna.UI2.WinForms.Guna2HtmlLabel();
            showRole = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblGenre = new Guna.UI2.WinForms.Guna2HtmlLabel();
            showGender = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblFullName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAvatar).BeginInit();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.Transparent;
            cardPanel.BorderRadius = 20;
            cardPanel.Controls.Add(pbAvatar);
            cardPanel.Controls.Add(separatorLine);
            cardPanel.Controls.Add(btnUpdate);
            cardPanel.Controls.Add(showName);
            cardPanel.Controls.Add(showUsename);
            cardPanel.Controls.Add(lblEmail);
            cardPanel.Controls.Add(showEmail);
            cardPanel.Controls.Add(lblRole);
            cardPanel.Controls.Add(showRole);
            cardPanel.Controls.Add(lblGenre);
            cardPanel.Controls.Add(showGender);
            cardPanel.CustomizableEdges = customizableEdges4;
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.FillColor = Color.White;
            cardPanel.Location = new Point(0, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.ShadowDecoration.BorderRadius = 20;
            cardPanel.ShadowDecoration.Color = Color.Silver;
            cardPanel.ShadowDecoration.CustomizableEdges = customizableEdges5;
            cardPanel.ShadowDecoration.Depth = 10;
            cardPanel.ShadowDecoration.Enabled = true;
            cardPanel.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            cardPanel.Size = new Size(604, 528);
            cardPanel.TabIndex = 11;
            // 
            // pbAvatar
            // 
            pbAvatar.FillColor = Color.FromArgb(41, 128, 185);
            pbAvatar.ImageRotate = 0F;
            pbAvatar.Location = new Point(250, 20);
            pbAvatar.Name = "pbAvatar";
            pbAvatar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            pbAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pbAvatar.Size = new Size(100, 100);
            pbAvatar.TabIndex = 0;
            pbAvatar.TabStop = false;
            // 
            // separatorLine
            // 
            separatorLine.FillColor = Color.FromArgb(224, 224, 224);
            separatorLine.Location = new Point(50, 210);
            separatorLine.Name = "separatorLine";
            separatorLine.Size = new Size(500, 10);
            separatorLine.TabIndex = 12;
            // 
            // btnUpdate
            // 
            btnUpdate.BorderRadius = 20;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.CustomizableEdges = customizableEdges2;
            btnUpdate.FillColor = Color.FromArgb(41, 128, 185);
            btnUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.HoverState.FillColor = Color.FromArgb(52, 152, 219);
            btnUpdate.Location = new Point(144, 436);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnUpdate.Size = new Size(300, 45);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "CẬP NHẬT THÔNG TIN";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // showName
            // 
            showName.AutoSize = false;
            showName.BackColor = Color.Transparent;
            showName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            showName.ForeColor = Color.FromArgb(44, 62, 80);
            showName.Location = new Point(0, 130);
            showName.Name = "showName";
            showName.Size = new Size(600, 37);
            showName.TabIndex = 7;
            showName.Text = "Nguyễn Văn A";
            showName.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // showUsename
            // 
            showUsename.AutoSize = false;
            showUsename.BackColor = Color.Transparent;
            showUsename.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            showUsename.ForeColor = Color.Gray;
            showUsename.Location = new Point(0, 170);
            showUsename.Name = "showUsename";
            showUsename.Size = new Size(600, 25);
            showUsename.TabIndex = 6;
            showUsename.Text = "@nguyenvana";
            showUsename.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(127, 140, 141);
            lblEmail.Location = new Point(80, 240);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(52, 25);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "EMAIL";
            // 
            // showEmail
            // 
            showEmail.BackColor = Color.Transparent;
            showEmail.Font = new Font("Segoe UI", 12F);
            showEmail.ForeColor = Color.FromArgb(44, 62, 80);
            showEmail.Location = new Point(80, 265);
            showEmail.Name = "showEmail";
            showEmail.Size = new Size(144, 30);
            showEmail.TabIndex = 14;
            showEmail.Text = "abc@gmail.com";
            // 
            // lblRole
            // 
            lblRole.BackColor = Color.Transparent;
            lblRole.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(127, 140, 141);
            lblRole.Location = new Point(80, 310);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(79, 25);
            lblRole.TabIndex = 15;
            lblRole.Text = "CHỨC VỤ";
            // 
            // showRole
            // 
            showRole.BackColor = Color.Transparent;
            showRole.Font = new Font("Segoe UI", 12F);
            showRole.ForeColor = Color.FromArgb(44, 62, 80);
            showRole.Location = new Point(80, 335);
            showRole.Name = "showRole";
            showRole.Size = new Size(84, 30);
            showRole.TabIndex = 16;
            showRole.Text = "Sinh Viên";
            // 
            // lblGenre
            // 
            lblGenre.BackColor = Color.Transparent;
            lblGenre.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblGenre.ForeColor = Color.FromArgb(127, 140, 141);
            lblGenre.Location = new Point(350, 310);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(83, 25);
            lblGenre.TabIndex = 17;
            lblGenre.Text = "GIỚI TÍNH";
            // 
            // showGender
            // 
            showGender.BackColor = Color.Transparent;
            showGender.Font = new Font("Segoe UI", 12F);
            showGender.ForeColor = Color.FromArgb(44, 62, 80);
            showGender.Location = new Point(350, 335);
            showGender.Name = "showGender";
            showGender.Size = new Size(45, 30);
            showGender.TabIndex = 18;
            showGender.Text = "Nam";
            // 
            // lblUserName
            // 
            lblUserName.BackColor = Color.Transparent;
            lblUserName.Location = new Point(0, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(3, 2);
            lblUserName.TabIndex = 0;
            lblUserName.Text = null;
            // 
            // lblFullName
            // 
            lblFullName.BackColor = Color.Transparent;
            lblFullName.Location = new Point(0, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(3, 2);
            lblFullName.TabIndex = 0;
            lblFullName.Text = null;
            // 
            // Info
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 245, 250);
            ClientSize = new Size(604, 528);
            Controls.Add(cardPanel);
            MaximizeBox = false;
            Name = "Info";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin cá nhân";
            Load += Info_Load;
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAvatar).EndInit();
            ResumeLayout(false);

        }

        #endregion

        // Khai báo biến Control (Đã thêm mới và xóa bớt các biến không cần thiết)
        private Guna.UI2.WinForms.Guna2Panel cardPanel;
        private Guna.UI2.WinForms.Guna2Separator separatorLine;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;

        // Các Labels hiển thị dữ liệu
        private Guna.UI2.WinForms.Guna2HtmlLabel showUsename;
        private Guna.UI2.WinForms.Guna2HtmlLabel showName;
        private Guna.UI2.WinForms.Guna2HtmlLabel showEmail;
        private Guna.UI2.WinForms.Guna2HtmlLabel showRole;
        private Guna.UI2.WinForms.Guna2HtmlLabel showGender;

        // Các Labels tiêu đề (Header text)
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEmail;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRole;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGenre;

        // lblUserName và lblFullName đã bị loại bỏ vì được thay thế bằng hiển thị trực tiếp showName và showUsername ở header
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFullName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbAvatar;
    }
}

  