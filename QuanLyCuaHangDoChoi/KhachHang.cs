using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;

namespace QuanLyCuaHangDoChoi
{
    public partial class KhachHang : Form
    {
        DataProvider conn = new DataProvider();
        DgvEvent dgvEvent = new DgvEvent();
        private string tenKHCanTim;
        private string maNVThanhToan;
        public KhachHang()
        {
            InitializeComponent();
        }
        public KhachHang(string maNV)
        {
            InitializeComponent();
            this.maNVThanhToan = maNV;
        }
        public KhachHang(string sodienthoai,string maNV)
        {
            InitializeComponent();
            tbSDT.Text = sodienthoai;
            this.maNVThanhToan = maNV;
        }
        public int getWidth() 
        {
            return 818;
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            dgvThongTin.RowTemplate.Height = 30;
                LoadTime();
                LoadMaKH();
                LoadData();
        }
        public string getTenKhachHang()
        {
            return tenKHCanTim;
        }
        private void LoadData() 
        {
            try
            {
                DateTime dateTime = DateTime.Now.AddDays(-120);
                string query = string.Format("select MaKH,TenKH,GioiTinh,SoDienThoai,NgaySinh,DiaChi,TongGiaTriDonMua from KhachHang where NgayThem >= '{0}' order by NgayThem desc, MaKH desc", dateTime.ToString("yyyy-MM-dd"));
                DataTable dtKH = conn.ReadData(query);
                dgvThongTin.DataSource = dtKH;
            }
            catch { }
        }
        private void LoadMaKH() 
        {
            try
            {
                string dateString = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
                dateString = dateString.Substring(0, 17).Replace("/", "").Replace(" ", "").Replace(":", "");
                tbMaKH.Text = "KH" + dateString;
            }
            catch { }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("select MaKH,TenKH,GioiTinh,NgaySinh,DiaChi,TongGiaTriDonMua from KhachHang where MaKH = '{1}' or TenKH = '{0}' or SoDienThoai = '{2}' ", tbTimKiem.Text.Trim(), tbTimKiem.Text.Trim(), tbTimKiem.Text.Trim());
                dgvThongTin.DataSource = conn.ReadData(query);
            }
            catch { }
        }

        private void checkBoxNam_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxNu.Checked) 
                {
                    checkBoxNu.Checked = false;
                }
            }
            catch { }
        }

        private void checkBoxNu_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxNam.Checked) 
                {
                    checkBoxNam.Checked = false;
                }
            }
            catch { }
        }
        private string getGioiTinh()
        {
            if (checkBoxNam.Checked)
            {
                return "Nam";
            }
            else if (checkBoxNu.Checked)
            {
                return "Nữ";
            }
            else
            {
                return "Chưa xác định";
            }
        }

        private void LoadTime() 
        {
            dateTimePicker.Value = DateTime.Now;
        }

        private void LamMoi() 
        {
            LoadMaKH();
            tbTenKH.Text = "";
            checkBoxNam.Checked = false;
            checkBoxNu.Checked = false;
            LoadTime();
            tbDiaChi.Text = "";
            tbSDT.Text = "";
            tbTongGiaTri.Text = "0";
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                LamMoi();
            }
            catch { }
        }
        private bool CheckCount() 
        {
            string query = string.Format("select count(MaKH) from KhachHang where MaKH = '{0}'",tbMaKH.Text.Trim());
            int checkCount = conn.CountData(query);
            if (checkCount > 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenKH = tbTenKH.Text;
            string maKH = tbMaKH.Text;
            try
            {
                DialogResult dialog = MessageBox.Show(string.Format("Bạn muốn thêm thông tin khách hàng mới:\nMã khách hàng: {0}\nTên khách hàng: {1}\nGiới tính: {2}\nNgày sinh: {3}\nĐịa chỉ: {4}"
                    ,tbMaKH.Text,tbTenKH.Text,getGioiTinh(),dateTimePicker.Value.ToString("yyyy-MM-dd"),tbDiaChi.Text),"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (CheckCount())
                    {
                        string query = string.Format("insert into KhachHang(MaKH,TenKH,GioiTinh,NgaySinh,DiaChi,TongGiaTriDonMua,NgayThem,SoDienThoai) values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}','{7}')"
                            , tbMaKH.Text.Trim(), tbTenKH.Text.Trim(), getGioiTinh().Trim(), dateTimePicker.Value.ToString("yyyy-MM-dd"), tbDiaChi.Text.Trim(), tbTongGiaTri.Text.Trim(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),tbSDT.Text.Trim());
                        conn.ChangeData(query);
                        LoadData();
                        LamMoi();
                        dgvEvent.selectRowAfterEdit(dgvThongTin, maKH);
                        MessageBox.Show("Thêm thông tin khách hàng " + tenKH + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Thêm thông tin khách hàng " + tenKH + " thất bại", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenKH = tbTenKH.Text;
            string maKH = tbMaKH.Text;
            try
            {
                DialogResult dialog = MessageBox.Show(string.Format("Bạn muốn sửa thông tin khách hàng:\nMã khách hàng: {0}\nTên khách hàng: {1}\nGiới tính: {2}\n Số điện thoại: {3}\nNgày sinh: {4}\nĐịa chỉ: {5}"
                    , tbMaKH.Text, tbTenKH.Text, getGioiTinh(),tbSDT.Text, dateTimePicker.Value.ToString("yyyy-MM-dd"), tbDiaChi.Text), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                        string query = string.Format("update KhachHang set TenKH=N'{0}',GioiTinh=N'{1}',NgaySinh=N'{2}',DiaChi=N'{3}',SoDienThoai=N'{4}' where MaKH=N'{5}'"
                            , tbTenKH.Text.Trim(), getGioiTinh().Trim(), dateTimePicker.Value.ToString("yyyy-MM-dd"), tbDiaChi.Text.Trim(),tbSDT.Text.Trim(), tbMaKH.Text.Trim());
                        conn.ChangeData(query);
                        LoadData();
                        LamMoi();
                        dgvEvent.selectRowAfterEdit(dgvThongTin, maKH);
                        MessageBox.Show("Sửa thông tin khách hàng " + tenKH + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Sửa thông tin khách hàng " + tenKH + " thất bại", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenKH = tbTenKH.Text;
            try
            {
                DialogResult dialog = MessageBox.Show(string.Format("Bạn muốn xóa thông tin khách hàng:\nMã khách hàng: {0}\nTên khách hàng: {1}\nGiới tính: {2}\nSố điện thoại: {3}\nNgày sinh: {4}\nĐịa chỉ: {5}"
                    , tbMaKH.Text, tbTenKH.Text, getGioiTinh(),tbSDT.Text, dateTimePicker.Value.ToString("yyyy-MM-dd"), tbDiaChi.Text), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    string query = string.Format("delete from KhachHang where MaKH=N'{0}'"
                        ,tbMaKH.Text.Trim());
                    conn.ChangeData(query);
                    LoadData();
                    LamMoi();
                    MessageBox.Show("Xóa thông tin khách hàng " + tenKH + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Xóa thông tin khách hàng " + tenKH + " thất bại", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void dgvThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                getDataFromDgv(rowIndex);
            }
            catch { }
        }
        private void getDataFromDgv(int rowIndex) 
        {
            try
            {
                if (rowIndex >= 0 && rowIndex < dgvThongTin.RowCount - 1)
                {
                    btnThem.Enabled = false;
                    if (!this.maNVThanhToan.Contains("NV"))
                    {
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                    }
                    checkBoxNam.Checked = false;
                    checkBoxNu.Checked = false;
                    DataGridViewRow row = dgvThongTin.Rows[rowIndex];
                    tbMaKH.Text = row.Cells["MaKH"].Value.ToString();
                    tbTenKH.Text = row.Cells["TenKH"].Value.ToString();
                    string gender = row.Cells["GioiTinh"].Value.ToString();
                    tbSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                    if (gender == checkBoxNam.Text)
                    {
                        checkBoxNam.Checked = true;
                    }
                    else if (gender == checkBoxNu.Text)
                    {
                        checkBoxNu.Checked = true;
                    }
                    string dateString = row.Cells["NgaySinh"].Value.ToString().Substring(0, 10);
                    DateTime dateTime = DateTime.ParseExact(dateString, "d/M/yyyy", CultureInfo.InvariantCulture);
                    dateTimePicker.Value = dateTime;
                    tbDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                }
            }
            catch { }
        }

        private void dgvThongTin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int rowIndex = dgvEvent.keyDownDgv(sender, e, dgvThongTin);
                getDataFromDgv(rowIndex);
            }
            catch { }
        }

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("select MaKH,TenKH,GioiTinh,NgaySinh,DiaChi,TongGiaTriDonMua from KhachHang where MaKH Like N'%{1}%' or TenKH Like N'%{0}%' or SoDienThoai Like '%{2}%' ", tbTimKiem.Text.Trim(), tbTimKiem.Text.Trim(),tbTimKiem.Text.Trim());
                dgvThongTin.DataSource = conn.ReadData(query);
            }
            catch { }
        }

        private void btnSearhAll_Click(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("Select MaKH,TenKH,GioiTinh,SoDienThoai,NgaySinh,DiaChi,TongGiaTriDonMua from KhachHang order by NgayThem desc");
                DataTable dataTable = conn.ReadData(query);
                dgvThongTin.DataSource = dataTable;
            }
            catch { }
        }

        private void tbTenKH_TextChanged(object sender, EventArgs e)
        {
            tenKHCanTim = tbTenKH.Text.Trim();
        }
    }
}
