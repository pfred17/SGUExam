using Org.BouncyCastle.Asn1.Cmp;

namespace GUI.Forms.nhomhocphan
{
    partial class UC_DeThiItem
    {
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlCard = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblDurationIcon = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblEnd = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblStart = new Guna.UI2.WinForms.Guna2HtmlLabel();
            linkDeKiemTra = new LinkLabel();
            pnlIcon = new Guna.UI2.WinForms.Guna2Panel();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.Transparent;
            pnlCard.Controls.Add(lblStatus);
            pnlCard.Controls.Add(lblDurationIcon);
            pnlCard.Controls.Add(lblTime);
            pnlCard.Controls.Add(lblEnd);
            pnlCard.Controls.Add(lblStart);
            pnlCard.Controls.Add(linkDeKiemTra);
            pnlCard.Controls.Add(pnlIcon);
            pnlCard.FillColor = Color.White;
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Radius = 12;
            pnlCard.ShadowColor = Color.Black;
            pnlCard.ShadowDepth = 15;
            pnlCard.ShadowShift = 3;
            pnlCard.Size = new Size(500, 172);
            pnlCard.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.OrangeRed;
            lblStatus.Location = new Point(386, 97);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(86, 25);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Trạng thái";
            lblStatus.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // lblDurationIcon
            // 
            lblDurationIcon.BackColor = Color.Transparent;
            lblDurationIcon.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDurationIcon.ForeColor = Color.DarkGray;
            lblDurationIcon.Location = new Point(30, 130);
            lblDurationIcon.Name = "lblDurationIcon";
            lblDurationIcon.Size = new Size(3, 2);
            lblDurationIcon.TabIndex = 9;
            lblDurationIcon.Text = null;
            // 
            // lblTime
            // 
            lblTime.BackColor = Color.Transparent;
            lblTime.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblTime.ForeColor = Color.DodgerBlue;
            lblTime.Location = new Point(57, 130);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(145, 27);
            lblTime.TabIndex = 6;
            lblTime.Text = "Thời gian làm bài";
            // 
            // lblEnd
            // 
            lblEnd.BackColor = Color.Transparent;
            lblEnd.Font = new Font("Segoe UI", 11F);
            lblEnd.ForeColor = Color.Gray;
            lblEnd.Location = new Point(57, 95);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(45, 27);
            lblEnd.TabIndex = 5;
            lblEnd.Text = "đến...";
            // 
            // lblStart
            // 
            lblStart.BackColor = Color.Transparent;
            lblStart.Font = new Font("Segoe UI", 11F);
            lblStart.ForeColor = Color.Black;
            lblStart.Location = new Point(57, 65);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(93, 27);
            lblStart.TabIndex = 3;
            lblStart.Text = "Diễn ra từ...";
            // 
            // linkDeKiemTra
            // 
            linkDeKiemTra.AutoSize = true;
            linkDeKiemTra.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkDeKiemTra.LinkBehavior = LinkBehavior.HoverUnderline;
            linkDeKiemTra.LinkColor = Color.DodgerBlue;
            linkDeKiemTra.Location = new Point(25, 20);
            linkDeKiemTra.Name = "linkDeKiemTra";
            linkDeKiemTra.Size = new Size(127, 28);
            linkDeKiemTra.TabIndex = 4;
            linkDeKiemTra.TabStop = true;
            linkDeKiemTra.Text = "Đề Kiểm Tra";
            linkDeKiemTra.LinkClicked += linkDeKiemTra_LinkClicked;
            // 
            // pnlIcon
            // 
            pnlIcon.BackColor = Color.Transparent;
            pnlIcon.BorderRadius = 12;
            pnlIcon.CustomizableEdges = customizableEdges1;
            pnlIcon.FillColor = Color.DodgerBlue;
            pnlIcon.Location = new Point(0, 0);
            pnlIcon.Name = "pnlIcon";
            pnlIcon.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlIcon.Size = new Size(10, 172);
            pnlIcon.TabIndex = 7;
            // 
            // UC_DeThiItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlCard);
            Margin = new Padding(10);
            Name = "UC_DeThiItem";
            Size = new Size(500, 172);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel pnlCard;
        private Guna.UI2.WinForms.Guna2Panel pnlIcon;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatusIcon;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDurationIcon;

        private Guna.UI2.WinForms.Guna2HtmlLabel lblStart;
        private LinkLabel linkDeKiemTra;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEnd;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
    }
}