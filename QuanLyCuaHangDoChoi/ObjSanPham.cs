
using System.Drawing;

namespace QuanLyCuaHangDoChoi
{
    class ObjSanPham
    {
        private string maSP;
        private string tenSP;
        private string theLoai;
        private float donGiaBan;
        private Image anhSanPham;

        public ObjSanPham(string maSP, string tenSP, string theLoai, float donGiaBan, Image image)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.theLoai = theLoai;
            this.donGiaBan = donGiaBan;
            this.anhSanPham = image;
        }

        public string MaSP
        {
            get { return maSP; }
            set { this.maSP = value; }
        }
        public string TenSP
        {
            get { return this.tenSP; }
            set { this.tenSP = value; }
        }
        public string TheLoai
        {
            get { return this.theLoai; }
            set { this.TheLoai = value; }
        }
        public float DonGiaBan
        {
            get { return this.donGiaBan; }
            set { this.donGiaBan = value; }
        }
        public Image AnhSanPham
        {
            get { return this.anhSanPham; }
            set { this.anhSanPham = value; }
        }
    }
}
