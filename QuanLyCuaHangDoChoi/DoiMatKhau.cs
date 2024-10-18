using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyCuaHangDoChoi
{
    public partial class DoiMatKhau : Form
    {
        DataProvider conn = new DataProvider();
        private string tenDangNhap;
        public DoiMatKhau(string tenDangNhap)
        {
            this.tenDangNhap = tenDangNhap;
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            bool check = false;
            string query = string.Format("select TenDangNhap,MatKhau from TaiKhoan where TenDangNhap = '{0}'and MatKhau='{1}'",this.tenDangNhap.Trim(),tbMKCu.Text.Trim());
            DataTable dt = conn.ReadData(query);
            if (dt.Rows.Count > 0)
            {
                check = true;
            }
            else 
            {
                MessageBox.Show("Mật khẩu cũ không đúng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (check) 
            {
                if (checkMK()&&IsStringValid(tbMKMoi.Text.Trim())&&IsStringValid(tbNhapLaiMK.Text.Trim()))
                {
                    string querydoimk = string.Format("update TaiKhoan set MatKhau='{0}' where TenDangNhap='{1}' ", tbMKMoi.Text.Trim(),this.tenDangNhap);
                    conn.ChangeData(querydoimk);
                    MessageBox.Show("Đổi mật khẩu thành công", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbMKCu.Text = "";
                    tbMKMoi.Text = "";
                    tbNhapLaiMK.Text = "";
                }
                else if (!checkMK() && IsStringValid(tbMKMoi.Text.Trim()) && IsStringValid(tbNhapLaiMK.Text.Trim()))
                {
                    MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu phải giống nhau","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else if (checkMK() && !IsStringValid(tbMKMoi.Text.Trim()) && !IsStringValid(tbNhapLaiMK.Text.Trim()))
                {
                    MessageBox.Show("Mật khẩu không được phép chứa kí tự đặc biệt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else 
                {
                    MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu phải giống nhau\nMật khẩu không được phép chứa kí tự đặc biệt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool checkMK() 
        {
            bool check = false;
            if (tbMKMoi.Text.Trim() == tbNhapLaiMK.Text.Trim()) 
            {
                check = true;
            }
            return check;
        }
        private bool IsStringValid(string input) 
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9_]+$");
            return regex.IsMatch(input);
        }
    }
}
