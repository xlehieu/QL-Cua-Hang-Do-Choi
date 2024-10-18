using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace QuanLyCuaHangDoChoi
{
    public partial class CTHoaDon : MetroFramework.Forms.MetroForm
    {
        DataProvider conn = new DataProvider();
        private string maHD;
        public CTHoaDon(string maHD)
        {
            this.maHD = maHD;
            InitializeComponent();
        }

        private void CTHoaDon_Load(object sender, EventArgs e)
        {
            lbMaHD.Text = this.maHD;
            DataTable dt = conn.ReadData(string.Format("select CTHoaDon.MaSP, SanPham.TenSP,CTHoaDon.SoLuong, DonGia, ThanhTien from CTHoaDon,SanPham where CTHoaDon.MaSP = SanPham.MaSP and MaHD = '{0}'",this.maHD));
            foreach (DataRow row in dt.Rows)
            {
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                string soLuong = row["SoLuong"].ToString();
                string donGia = row["DonGia"].ToString();
                string thanhTien = row["ThanhTien"].ToString();
                dgvThongTin.Rows.Add(maSP,tenSP,soLuong,donGia,thanhTien);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
