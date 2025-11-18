using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.modules
{
    public partial class DapAnControl : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string NoiDung
        {
            get => rtbNoiDung.Text;
            set => rtbNoiDung.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool Dung
        {
            get => chkDung.Checked;
            set => chkDung.Checked = value;
        }

        public DapAnControl(string text = "", bool dung = false)
        {
            InitializeComponent();
            NoiDung = text;
            Dung = dung;

            btnXoa.Click += (s, e) => this.Parent?.Controls.Remove(this);

            var btnSua = new Button
            {
                Text = "Sửa",
                Location = new Point(350, 5),
                Size = new Size(50, 25),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            this.Controls.Add(btnSua);

            btnSua.Click += (s, e) =>
            {
                var parentForm = this.FindForm() as frmThemSuaCauHoi;
                parentForm?.StartEditDapAn(this);
            };
        }
    }
}