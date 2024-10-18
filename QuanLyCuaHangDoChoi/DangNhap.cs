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
    public partial class DangNhap : Form
    {
        DataProvider conn = new DataProvider();
        private string tenNV;
        private string maNV;
        private string tenDN;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = false;
                string query = string.Format("select count(*) from TaiKhoan where TenDangNhap='{0}'and MatKhau='{1}' ", tbTenDangNhap.Text.Trim(), tbMatKhau.Text.Trim());
                if (conn.CountData(query) > 0)
                {
                    check = true;
                }
                if (check)
                {
                    MessageBox.Show("Đăng nhập thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.maNV = conn.SelectOneData(string.Format("select distinct MaNV from TaiKhoan where TenDangNhap='{0}'", tbTenDangNhap.Text));
                    this.tenNV = conn.SelectOneData(string.Format("select distinct TenNV from NhanVien where MaNV='{0}'", this.maNV));
                    this.tenDN = tbTenDangNhap.Text;
                    HeThong ht = new HeThong(this, this.maNV, this.tenNV,this.tenDN);
                    this.Hide();
                    tbTenDangNhap.Text = "";
                    tbMatKhau.Text = "";
                    ht.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Bạn muốn thoát ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch { }
        }

        private void labelQMK_Click(object sender, EventArgs e)
        {
            try
            {
                QuenMatKhau form = new QuenMatKhau();
                form.ShowDialog();
            }
            catch { }
        }
    }
}
