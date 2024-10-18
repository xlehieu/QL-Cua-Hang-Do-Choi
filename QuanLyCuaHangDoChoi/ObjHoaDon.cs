using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoi
{
    class ObjHoaDon
    {
        private string maHD;
        private string maKH;
        private string tenKH;
        private string maNV;
        private string tenNV;
        private string ngayMua;
        private string tongTienThanhToan;
        private string giamTong;

        public ObjHoaDon(string maHD, string maKH,string tenKH,string maNV,string tenNV, string ngayMua, string tongTienThanhToan, string giamTong)
        {
            this.maHD = maHD;
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.ngayMua = ngayMua;
            this.tongTienThanhToan = tongTienThanhToan;
            this.giamTong = giamTong;
        }

        public string MaHD
        {
            get { return this.maHD; }
            set { this.maHD = value; }
        }
        public string MaKH
        {
            get { return this.maKH; }
            set { this.maKH = value; }
        }
        public string TenKH
        {
            get { return this.tenKH; }
            set { this.tenKH = value; }
        }
        public string MaNV
        {
            get { return this.maNV; }
            set { this.maNV = value; }
        }
        public string TenNV
        {
            get { return this.tenNV; }
            set { this.tenNV = value; }
        }
        public string NgayMua
        {
            get { return this.ngayMua; }
            set { this.ngayMua = value; }
        }
        public string TongTienThanhToan
        {
            get { return this.tongTienThanhToan; }
            set { this.tongTienThanhToan = value; }
        }
        public string GiamTong
        {
            get { return this.giamTong; }
            set { this.giamTong = value; }
        }
    }
}
