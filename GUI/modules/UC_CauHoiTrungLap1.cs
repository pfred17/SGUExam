using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Wordprocessing;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GUI.modules
{
    public partial class UC_CauHoiTrungLap1 : UserControl
    {
        private readonly UC_CauHoi _parentUC;
        public UC_CauHoiTrungLap1(UC_CauHoi parent)
        {
            InitializeComponent();
            SetupDataGridView();
            _parentUC = parent;
        }
        private void SetupDataGridView()
        {
            // Tắt style hệ thống để custom header
            dgvTrungLap.EnableHeadersVisualStyles = false;
            dgvTrungLap.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dgvTrungLap.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTrungLap.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            dgvTrungLap.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 249, 253);
            dgvTrungLap.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvTrungLap.GridColor = System.Drawing.Color.FromArgb(235, 240, 245);

            // Custom style table
            dgvTrungLap.AllowUserToAddRows = false;
            dgvTrungLap.AllowUserToOrderColumns = false;
            dgvTrungLap.AllowUserToResizeColumns = false;
            dgvTrungLap.AllowUserToResizeRows = false;
            dgvTrungLap.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvTrungLap.MultiSelect = false;
            dgvTrungLap.ReadOnly = true;
        }
    }
}
