using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDoChoi
{
    public partial class TaoTaiKhoan : Form
    {
        DataProvider conn = new DataProvider();
        public TaoTaiKhoan()
        {
            InitializeComponent();
        }
        private bool IsStringValid(string input) 
        {
            try
            {
                Regex regex = new Regex(@"^[a-zA-Z0-9_]+$");
                return regex.IsMatch(input);
            }
            catch { return false; }
        }
        private bool CheckTheSamePassword() 
        {
            if (tbMK.Text.Trim() == tbNhapLaiMK.Text.Trim()) 
            {
                return true;
            }
            return false;
        }
        private bool CheckUserName() 
        {
            string query = string.Format("select count(*) from TaiKhoan where TenDangNhap='{0}'",tbTenDN.Text.Trim());
            int count = conn.CountData(query);
            if (count > 0) 
            {
                return false;
            }
            return true;
        }
        private bool checkRong() 
        {
            if (tbTenDN.Text == "" || tbNhapLaiMK.Text == "" || tbMK.Text == "" || cbMaNV.Text == "") 
            {
                return false;
            }
            return true;
        }
        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkRong())
                {
                    if (CheckUserName())
                    {
                        if (CheckTheSamePassword() && IsStringValid(tbMK.Text.Trim()) && IsStringValid(tbTenDN.Text.Trim()))
                        {
                            string query = string.Format("insert into TaiKhoan(MaNV,TenDangNhap,MatKhau) values('{0}','{1}','{2}')",cbMaNV.Text.Trim(),tbTenDN.Text.Trim(), tbMK.Text.Trim());
                            conn.ChangeData(query);
                            MessageBox.Show("Tạo tài khoản thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (CheckTheSamePassword() && (!IsStringValid(tbMK.Text.Trim()) || !IsStringValid(tbTenDN.Text.Trim())))
                        {
                            MessageBox.Show("Tài khoản và mật khẩu không được có ký tự đặc biệt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (!CheckTheSamePassword() && IsStringValid(tbMK.Text.Trim()) && IsStringValid(tbTenDN.Text.Trim()))
                        {
                            MessageBox.Show("Mật khẩu và nhập lại mật khẩu phải giống nhau", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại\nXin vui lòng thử lại");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
            }
            catch 
            {
                MessageBox.Show("Có lỗi trong quá trình tạo tài khoản");
            }
        }

        private void TaoTaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("select MaNV from NhanVien where MaNV NOT IN (Select MaNV from TaiKhoan) order by MaNV asc");
                DataTable dt = conn.ReadData(query);
                foreach (DataRow row in dt.Rows)
                {
                    string maNV = row["MaNV"].ToString().Trim();
                    cbMaNV.Items.Add(maNV);
                }
            }
            catch { }
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbMaNV.SelectedIndex >= 0)
                {
                    string maNV = cbMaNV.SelectedItem.ToString().Trim();
                    string query = string.Format("select TenNV from NhanVien where  MaNV='{0}'", maNV);
                    lbTenNV.Text = "Họ và tên: " + conn.SelectOneData(query);
                    string query2 = string.Format("select ChucVu from NhanVien where MaNV='{0}'", maNV);
                    lbViTri.Text = "Vị trí: " + conn.SelectOneData(query2);
                }
                else
                {
                    lbTenNV.Text = lbViTri.Text = "";
                }
            }
            catch { }
        }
    }
}
