using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDoChoi
{
    public partial class HeThong : Form
    {
        DangNhap dn = new DangNhap();
        private string maNV;
        private string tenNV;
        private string tenDN;
        public HeThong(DangNhap dn, string maNV,string tenNV,string tenDN)
        {
            this.dn = dn;
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.tenDN = tenDN;
            InitializeComponent();
        }
        public HeThong()
        {
            InitializeComponent();
        }
        private Size size;

        private Form currentFormChild;
        private void OpenChildForm(Form childForm) 
        {
            try
            {
                if (currentFormChild != null)
                {
                    currentFormChild.Close();
                }
                currentFormChild = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                pnBody.Controls.Add(childForm);
                pnBody.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            catch { }
        }
        private void changeSize(int width) 
        {
            try
            {
                this.Size = new Size(width, 820);
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            }
            catch { }
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                if (!maNV.Contains("NV"))
                {
                    NhanVien nv = new NhanVien();
                    OpenChildForm(nv);
                    labelTitle.Text = btnNhanVien.Text;
                    changeSize(1050);
                    changeBackgroundButton(btnNhanVien);
                    this.AutoScroll = false;
                }
                else
                {
                    MessageBox.Show("Bạn không được phép sử dụng tác vụ này","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch { }
        }
        private void changeBackgroundButton(Button button) 
        {
            try
            {
                setColorDefaultButton();
                button.BackColor = Color.FromArgb(255, 218, 61);
            }
            catch { }
        }
        private void setColorDefaultButton() 
        {
            try
            {
                Color color = Color.FromArgb(160, 223, 255);
                btnNhanVien.BackColor = color;
                btnKhachHang.BackColor = color;
                btnSanPham.BackColor = color;
                btnTaiKhoan.BackColor = color;
                btnBanHang.BackColor = color;
                btnThongKe.BackColor = color;
            }
            catch { }
        }
        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentFormChild != null)
                {
                    currentFormChild.Close();
                }
                labelTitle.Text = "HOME";
                this.Size = size;
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                setColorDefaultButton();
                this.AutoScroll = false;
            }
            catch { }
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang kh = new KhachHang(this.maNV);
                OpenChildForm(kh);
                labelTitle.Text = btnKhachHang.Text;
                changeSize(1050);
                changeBackgroundButton(btnKhachHang);
                this.AutoScroll = false;
            }
            catch { }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                SanPham sp = new SanPham(this.maNV);
                OpenChildForm(sp);
                labelTitle.Text = btnSanPham.Text;
                changeSize(1050);
                changeBackgroundButton(btnSanPham);
                this.AutoScroll = false;
            }
            catch { }
        }

        private void HeThong_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                dn.Show();
            }
            catch { }
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan tk = new TaiKhoan(maNV, tenDN);
                OpenChildForm(tk);
                labelTitle.Text = btnTaiKhoan.Text;
                changeSize(1050);
                changeBackgroundButton(btnTaiKhoan);
                this.AutoScroll = false;
            }
            catch { }
        }

        private void HeThong_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                size = this.Size;
                labelTitle.Text = "HOME";
            }
            catch { }
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            try
            {
                ThanhToan thanhToan = new ThanhToan(this.maNV, this.tenNV);
                OpenChildForm(thanhToan);
                labelTitle.Text = btnBanHang.Text;
                changeSize(Screen.PrimaryScreen.WorkingArea.Width);
                changeBackgroundButton(btnBanHang);
                this.AutoScroll = false;
            }
            catch { }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.maNV.Contains("NV"))
                {
                    ThongKe thongKe = new ThongKe();
                    OpenChildForm(thongKe);
                    labelTitle.Text = btnThongKe.Text;
                    changeSize(Screen.PrimaryScreen.WorkingArea.Width);
                    changeBackgroundButton(btnThongKe);
                    this.pnBody.AutoScroll = true;
                }
                else
                {
                    MessageBox.Show("Bạn không được phép sử dụng tác vụ này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }
    }
}
