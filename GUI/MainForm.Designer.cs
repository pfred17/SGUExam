namespace GUI
{
    partial class MainForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelSidebar = new Guna.UI2.WinForms.Guna2Panel();
            panelMain = new Guna.UI2.WinForms.Guna2Panel();
            panelHeader = new Panel();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.White;
            panelSidebar.BorderThickness = 1;
            panelSidebar.CustomBorderThickness = new Padding(1);
            panelSidebar.CustomizableEdges = customizableEdges1;
            panelSidebar.Location = new Point(0, 74);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panelSidebar.Size = new Size(250, 730);
            panelSidebar.TabIndex = 0;
            // 
            // panelMain
            // 
            panelMain.CustomizableEdges = customizableEdges3;
            panelMain.Location = new Point(247, 74);
            panelMain.Name = "panelMain";
            panelMain.ShadowDecoration.CustomizableEdges = customizableEdges4;
            panelMain.Size = new Size(1120, 730);
            panelMain.TabIndex = 1;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(6, 101, 208);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1370, 74);
            panelHeader.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(1370, 803);
            Controls.Add(panelHeader);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelSidebar;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Panel panelHeader;
    }
}