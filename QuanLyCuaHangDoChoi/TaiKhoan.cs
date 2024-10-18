using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDoChoi
{
    public partial class TaiKhoan : Form
    {
        private string maNV;
        private string tenDN;
        public TaiKhoan(string maNV,string tenDN)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.tenDN = tenDN;
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm) 
        {
            if (currentFormChild != null) 
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel.Controls.Add(childForm);
            panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void createAccountMenuItem_Click(object sender, EventArgs e)
        {
            if (!maNV.Contains("NV"))
            {
                TaoTaiKhoan ttk = new TaoTaiKhoan();
                OpenChildForm(ttk);
            }
            else
            {
                MessageBox.Show("Bạn không được phép sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void changePasswordMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau(tenDN);
            OpenChildForm(dmk);
        }
    }
}
