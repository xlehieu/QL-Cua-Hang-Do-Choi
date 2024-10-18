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
    public partial class QuenMatKhau : Form
    {
        DataProvider conn = new DataProvider();

        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            try
            {
                string matkhaumoi = tbMKM.Text;
                string nhaplaimk = tbNLMK.Text;
                if (checkTenDN())
                {
                    if (checkMK())
                    {
                        try
                        {
                            string query = string.Format("update TaiKhoan set MatKhau = {0}", tbMKM.Text);
                            conn.ChangeData(query);
                            MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Đã có lỗi trong quá trinh đổi mật khẩu", "Lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu phải trùng nhau\nvà phải có ít nhất 1 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc CCCD sai", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
        }
        private bool checkTenDN()
        {
            bool check = false;
            string query = string.Format("select count(*) from TaiKhoan,NhanVien where NhanVien.MaNV = TaiKhoan.MaNV and TenDangNhap = '{0}' and CCCD= '{1}' ",tbTenDangNhap.Text,tbCCCD.Text.Trim());
            if (conn.CountData(query)>0) {
                check = true;
            }
            return check;
        } 
        private bool checkMK()
        {
            bool check = false;
            if(tbMKM.Text==tbNLMK.Text&&tbMKM.Text.Length>0)
            {
                check = true;
            }
            return check;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Bạn muốn thoát ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch { }
        }
    }
}
