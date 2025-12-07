using Guna.UI2.WinForms;
using System.Drawing.Drawing2D;

namespace GUI
{
    partial class FormLogin
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnBackgroundLogin = new Guna2Panel();
            SuspendLayout();
            // 
            // pnBackgroundLogin
            // 
            pnBackgroundLogin.BackColor = Color.WhiteSmoke;
            pnBackgroundLogin.BackgroundImage = Properties.Resources.background_login;
            pnBackgroundLogin.BackgroundImageLayout = ImageLayout.Stretch;
            pnBackgroundLogin.BorderColor = Color.Transparent;
            pnBackgroundLogin.CustomizableEdges = customizableEdges1;
            pnBackgroundLogin.Dock = DockStyle.Fill;
            pnBackgroundLogin.FillColor = Color.Transparent;
            pnBackgroundLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnBackgroundLogin.Location = new Point(0, 0);
            pnBackgroundLogin.Name = "pnBackgroundLogin";
            pnBackgroundLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnBackgroundLogin.Size = new Size(982, 553);
            pnBackgroundLogin.TabIndex = 0;
            pnBackgroundLogin.Paint += pnBackgroundLogin_Paint;
            // 
            // FormLogin
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(pnBackgroundLogin);
            MaximizeBox = false;
            Name = "FormLogin";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnBackgroundLogin;
    }
}