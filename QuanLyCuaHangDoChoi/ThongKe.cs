using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace QuanLyCuaHangDoChoi
{
    public partial class ThongKe : Form
    {
        List<ObjHoaDon> listHoaDon = new List<ObjHoaDon>();
        DataProvider conn = new DataProvider();
        private DataTable dataTableKhachHang = new DataTable();
        public ThongKe()
        {
            try
            {
                InitializeComponent();
            }
            catch { }
        }
        private void LoadButtonTheLoai()
        {
            try
            {
                Size size = new Size(120, flowLayoutTheLoai.Height - 8);
                Color foreColor = Color.FromArgb(255, 218, 61);
                Font font = new Font("Microsoft Sans Serif", 12);
                Button btnTheLoaiTatCa = new Button();
                btnTheLoaiTatCa.Name = "btnTheLoai";
                btnTheLoaiTatCa.Text = "Tất cả";
                btnTheLoaiTatCa.Size = size;
                btnTheLoaiTatCa.ForeColor = Color.FromArgb(255, 49, 49);
                btnTheLoaiTatCa.BackColor = foreColor;
                btnTheLoaiTatCa.Font = font;
                btnTheLoaiTatCa.Click += BtnTheLoai_Click;
                flowLayoutTheLoai.Controls.Add(btnTheLoaiTatCa);
                DataTable dt = conn.ReadData("select distinct TheLoai from SanPham order by TheLoai asc");
                foreach (DataRow row in dt.Rows)
                {
                    Button btnTheLoai = new Button();
                    btnTheLoai.Name = "btnTheLoai";
                    btnTheLoai.Text = row["TheLoai"].ToString();
                    btnTheLoai.Size = size;
                    btnTheLoai.ForeColor = Color.FromArgb(255, 49, 49);
                    btnTheLoai.BackColor = foreColor;
                    btnTheLoai.Font = font;
                    btnTheLoai.Click += BtnTheLoai_Click;
                    flowLayoutTheLoai.Controls.Add(btnTheLoai);
                }
            }
            catch { }
        }

        private void BtnTheLoai_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                if (button.Text == "Tất cả")
                {
                    LoadDataChart("");
                }
                else
                {
                    string textButton = button.Text;
                    LoadDataChart(textButton);
                }
            }
            catch { }
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimeTuNgay.Value = DateTime.Now.AddDays(-180);
                dateTimeDenNgay.Value = DateTime.Now;
                dgvThongTinHoaDon.RowTemplate.Height = 30;
                dgvThongTinKhachHang.RowTemplate.Height = 30;
                LoadListHoaDon();
                LoadListKH();
                LoadButtonTheLoai();
                LoadDataGridviewHoaDon();
                LoadDataChart("");
            }
            catch { }
        }
        private void LoadListKH()
        {
            try
            {
                DateTime dateTime = DateTime.Now.AddDays(-180);
                DataTable dt = conn.ReadData(string.Format("select MaKH, TenKH, GioiTinh,SoDienThoai, NgaySinh, DiaChi, TongGiaTriDonMua, NgayThem  from KhachHang where NgayThem >= '{0}' order by NgayThem desc", dateTime.ToString("yyyy - MM - dd")));
                dgvThongTinKhachHang.DataSource = dt;
                dataTableKhachHang = dt;
            }
            catch { }
        }

        //ChatGPT
        private void LoadDataChart(string theLoaiSanPham)
        {
            try
            {
                Series series = new Series("Revenue");
                series.ChartType = SeriesChartType.Pie;
                DateTime dateTime = DateTime.Now.AddDays(-30);
                List<string> listString = new List<string>();
                DataTable dt = conn.ReadData(string.Format("select top 5 CTHoaDon.MaSP,SanPham.TenSP, sum(ThanhTien) as TongTien from CTHoaDon,SanPham where CTHoaDon.MaSP = SanPham.MaSP and TheLoai Like N'%{0}%' Group by CTHoaDon.MaSP,TenSP Order by TongTien desc", theLoaiSanPham));
                foreach (DataRow row in dt.Rows)
                {
                    listString.Add(row["MaSP"].ToString());
                }
                listString = listString.Distinct().ToList();
                foreach (string checkString in listString)
                {
                    decimal tongTienTrenMoiSanPham = 0;
                    string tenSP = "";
                    foreach (DataRow row in dt.Rows)
                    {
                        if (checkString == row["MaSP"].ToString())
                        {
                            tongTienTrenMoiSanPham += decimal.Parse(row["TongTien"].ToString());
                            tenSP = row["TenSP"].ToString();
                        }
                    }
                    series.Points.AddXY(tenSP, tongTienTrenMoiSanPham);
                }
                series.Font = new Font("Microsoft Sans Serif", 13);
                series.IsValueShownAsLabel = true;
                chartRevenue.Legends[0].Font = new Font("Microsoft Sans Serif", 11);
                chartRevenue.Series.Clear();
                chartRevenue.Series.Add(series);
            }
            catch { }
        }
        private void LoadListHoaDon()
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                DateTime previousDate = currentDate.AddDays(-180).Date;
                string dateString = previousDate.ToString("yyyy-MM-dd 00:00:00");
                DataTable dt = conn.ReadData(string.Format("select MaHD,HoaDon.MaKH,TenKH,HoaDon.MaNV,TenNV,NgayMua,TongTienThanhToan,GiamTong from HoaDon,KhachHang,NhanVien where HoaDon.MaKH = KhachHang.MaKH and HoaDon.MaNV = NhanVien.MaNV and NgayMua >= '{0}'", dateString));
                foreach (DataRow row in dt.Rows)
                {
                    string maHD = row["MaHD"].ToString();
                    string maKH = row["MaKH"].ToString();
                    string tenKH = row["TenKH"].ToString();
                    string maNV = row["MaNV"].ToString();
                    string tenNV = row["TenNV"].ToString();
                    string ngayMua = row["NgayMua"].ToString().Substring(0, 19).Trim();
                    string tongTienThanhToan = row["TongTienThanhToan"].ToString();
                    string giamTong = row["GiamTong"].ToString();
                    ObjHoaDon hoaDonItem = new ObjHoaDon(maHD, maKH, tenKH, maNV, tenNV, ngayMua, tongTienThanhToan, giamTong);
                    listHoaDon.Add(hoaDonItem);
                }
            }
            catch { }
        }
        private void LoadDataGridviewHoaDon()
        {
            try
            {
                listHoaDon.Sort((x, y) => y.MaHD.CompareTo(x.MaHD));
                bool check = true;
                if (listHoaDon[0] == null)
                {
                    check = false;
                }
                if (check)
                {
                    foreach (ObjHoaDon hoaDonItem in listHoaDon)
                    {
                        dgvThongTinHoaDon.Rows.Add(hoaDonItem.MaHD, hoaDonItem.MaKH, hoaDonItem.TenKH, hoaDonItem.MaNV, hoaDonItem.TenNV, hoaDonItem.TongTienThanhToan, hoaDonItem.GiamTong, hoaDonItem.NgayMua);
                    }
                }
            }
            catch { }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime toDate = dateTimeDenNgay.Value;
                DateTime fromDate = dateTimeTuNgay.Value;
                string toDateString = toDate.ToString("yyyy-MM-dd 00:00:00");
                string fromDateString = fromDate.ToString("yyyy-MM-dd 00:00:00");
                DataTable dt = conn.ReadData(string.Format("select MaHD,HoaDon.MaKH,TenKH,HoaDon.MaNV,TenNV,NgayMua,TongTienThanhToan,GiamTong from HoaDon,KhachHang,NhanVien where HoaDon.MaKH = KhachHang.MaKH and HoaDon.MaNV = NhanVien.MaNV and NgayMua >= '{0}' and NgayMua <='{1}' order by NgayMua desc", fromDateString, toDateString));
                dgvThongTinHoaDon.DataSource = dt;
            }
            catch { }
        }

        private void dgvThongTinHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                if (rowIndex >= 0 && rowIndex < dgvThongTinHoaDon.RowCount)
                {
                    DataGridViewRow row = dgvThongTinHoaDon.Rows[rowIndex];
                    CTHoaDon ctHoaDon = new CTHoaDon(row.Cells["MaHD"].Value.ToString());
                    ctHoaDon.ShowDialog();
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fromDateString = metroDateTime1.Value.ToString("yyyy-MM-dd 00:00:00");
                string toDateString = metroDateTime2.Value.ToString("yyyy-MM-dd 00:00:00");
                DataTable dt = conn.ReadData(string.Format("select MaKH, TenKH, GioiTinh, NgaySinh,SoDienThoai, DiaChi, TongGiaTriDonMua, NgayThem  from KhachHang where NgayThem >= '{0}' and NgayThem <= '{1}' order by NgayThem desc", fromDateString, toDateString));
                dgvThongTinKhachHang.DataSource = dt;
            }
            catch {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                DataColumn column1 = new DataColumn("MaKH");
                DataColumn column2 = new DataColumn("TenKH");
                DataColumn column3 = new DataColumn("GioiTinh");
                DataColumn column4 = new DataColumn("NgaySinh");
                DataColumn column5 = new DataColumn("SoDienThoai");
                DataColumn column6 = new DataColumn("DiaChi");
                DataColumn column7 = new DataColumn("TongGiaTriDonMua");
                DataColumn column8 = new DataColumn("NgayThem");

                dataTable.Columns.Add(column1);
                dataTable.Columns.Add(column2);
                dataTable.Columns.Add(column3);
                dataTable.Columns.Add(column4);
                dataTable.Columns.Add(column5);
                dataTable.Columns.Add(column6);
                dataTable.Columns.Add(column7);
                dataTable.Columns.Add(column8);

                foreach (DataGridViewRow dtgvRow in dgvThongTinKhachHang.Rows)
                {
                    DataRow dtRow = dataTable.NewRow();

                    dtRow[0] = dtgvRow.Cells[0].Value;
                    dtRow[1] = dtgvRow.Cells[1].Value;
                    dtRow[2] = dtgvRow.Cells[2].Value;
                    dtRow[3] = dtgvRow.Cells[3].Value;
                    dtRow[4] = dtgvRow.Cells[4].Value;
                    dtRow[5] = dtgvRow.Cells[5].Value;
                    dtRow[6] = dtgvRow.Cells[6].Value;
                    dtRow[7] = dtgvRow.Cells[7].Value;

                    dataTable.Rows.Add(dtRow);
                }
                ExportFileKhachHang(dataTable, "Danh Sach Khach Hang", "DANH SÁCH KHÁCH HÀNG");
            }
            catch { }
        }
        private void ExportFileKhachHang(DataTable dataTable, string sheetName, string title)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;
                Microsoft.Office.Interop.Excel.Worksheet oSheet;

                //Tạo mới một excel workbook

                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                oExcel.Application.SheetsInNewWorkbook = 1;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
                oSheet.Name = sheetName;

                //Tao tieu de
                Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "H1");
                head.MergeCells = true;
                head.Value2 = title;
                head.Font.Bold = true;
                head.Font.Name = "Times New Roman";
                head.Font.Size = "20";
                head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //Tao tieu de cot
                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
                cl1.Value2 = "Mã khách hàng";
                cl1.ColumnWidth = 20;
                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
                cl2.Value2 = "Tên khách hàng";
                cl2.ColumnWidth = 20;
                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
                cl3.Value2 = "Giới tính";
                cl3.ColumnWidth = 10;
                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
                cl4.Value2 = "Số điện thoại";
                cl4.ColumnWidth = 20;
                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
                cl5.Value2 = "Ngày sinh";
                cl5.ColumnWidth = 20;
                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
                cl6.Value2 = "Địa chỉ";
                cl6.ColumnWidth = 40;
                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
                cl7.Value2 = "Tổng giá trị đơn mua";
                cl7.ColumnWidth = 20;
                Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
                cl8.Value2 = "Ngày thêm";
                cl8.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");
                rowHead.Font.Bold = true;

                //Ke vien
                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                //Thiet lap mau nen

                rowHead.Interior.ColorIndex = 6;

                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //Tao mang theo datatable

                object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];
                //Truyen du lieu tu datatable vao mang doi tuong

                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    DataRow dataRow = dataTable.Rows[row];
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        arr[row, col] = dataRow[col];
                    }
                }

                //thiet lap vung dien du lieu
                int rowStart = 4;
                int columnStart = 1;

                int rowEnd = rowStart + dataTable.Rows.Count - 2;
                int columnEnd = dataTable.Columns.Count;

                // Ô bắt đầu điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
                // Ô kết thúc điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

                //lấy về vùng điền dữ liệu
                Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

                //Điền dữ liệu vào vùng đã thiết lập

                range.Value2 = arr;

                //Kẻ viền
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                //Căn giữa cả bảng
                oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            catch { }
        }
        //Thống kê hóa đơn
        private void btnThongKeHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                DataColumn column1 = new DataColumn("MaHD");
                DataColumn column2 = new DataColumn("MaKH");
                DataColumn column3 = new DataColumn("TenKH");
                DataColumn column4 = new DataColumn("MaNV");
                DataColumn column5 = new DataColumn("TenNV");
                DataColumn column6 = new DataColumn("TongTienHoaDon");
                DataColumn column7 = new DataColumn("GiamTong");
                DataColumn column8 = new DataColumn("NgayMua");

                dataTable.Columns.Add(column1);
                dataTable.Columns.Add(column2);
                dataTable.Columns.Add(column3);
                dataTable.Columns.Add(column4);
                dataTable.Columns.Add(column5);
                dataTable.Columns.Add(column6);
                dataTable.Columns.Add(column7);
                dataTable.Columns.Add(column8);

                foreach (DataGridViewRow dtgvRow in dgvThongTinHoaDon.Rows)
                {
                    DataRow dtRow = dataTable.NewRow();

                    dtRow[0] = dtgvRow.Cells[0].Value;
                    dtRow[1] = dtgvRow.Cells[1].Value;
                    dtRow[2] = dtgvRow.Cells[2].Value;
                    dtRow[3] = dtgvRow.Cells[3].Value;
                    dtRow[4] = dtgvRow.Cells[4].Value;
                    dtRow[5] = dtgvRow.Cells[5].Value;
                    dtRow[6] = dtgvRow.Cells[6].Value;
                    dtRow[7] = dtgvRow.Cells[7].Value;

                    dataTable.Rows.Add(dtRow);
                }
                ExportFileHoaDon(dataTable, "Danh Sach Hoa Don", string.Format("DANH SÁCH HÓA ĐƠN TỪ {0} ĐẾN {1}", dateTimeTuNgay.Value.ToString("dd/MM/yyyy"), dateTimeDenNgay.Value.ToString("dd/MM/yyyy")));
            }
            catch { }
        }
        private void ExportFileHoaDon(DataTable dataTable, string sheetName, string title)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;
                Microsoft.Office.Interop.Excel.Worksheet oSheet;

                //Tạo mới một excel workbook

                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                oExcel.Application.SheetsInNewWorkbook = 1;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
                oSheet.Name = sheetName;

                //Tao tieu de
                Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "H1");
                head.MergeCells = true;
                head.Value2 = title;
                head.Font.Bold = true;
                head.Font.Name = "Times New Roman";
                head.Font.Size = "20";
                head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //Tao tieu de cot
                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
                cl1.Value2 = "Mã hóa đơn";
                cl1.ColumnWidth = 25;
                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
                cl2.Value2 = "Mã khách hàng";
                cl2.ColumnWidth = 25;
                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
                cl3.Value2 = "Tên khách hàng";
                cl3.ColumnWidth = 25;
                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
                cl4.Value2 = "Mã nhân viên";
                cl4.ColumnWidth = 25;
                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
                cl5.Value2 = "Tên nhân viên";
                cl5.ColumnWidth = 25;
                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
                cl6.Value2 = "Tổng tiền thanh toán hóa đơn";
                cl6.ColumnWidth = 30;
                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
                cl7.Value2 = "Giảm giá tổng hóa đơn";
                cl7.ColumnWidth = 25;
                Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
                cl8.Value2 = "Ngày mua";
                cl8.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");
                rowHead.Font.Bold = true;

                //Ke vien
                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                //Thiet lap mau nen

                rowHead.Interior.ColorIndex = 6;

                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //Tao mang theo datatable

                object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];
                //Truyen du lieu tu datatable vao mang doi tuong

                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    DataRow dataRow = dataTable.Rows[row];
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        arr[row, col] = dataRow[col];
                    }
                }

                //thiet lap vung dien du lieu
                int rowStart = 4;
                int columnStart = 1;

                int rowEnd = rowStart + dataTable.Rows.Count - 2;
                int columnEnd = dataTable.Columns.Count;

                // Ô bắt đầu điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
                // Ô kết thúc điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

                //lấy về vùng điền dữ liệu
                Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

                //Điền dữ liệu vào vùng đã thiết lập

                range.Value2 = arr;

                //Kẻ viền
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                //Căn giữa cả bảng
                oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            catch { }
        }
    }
}
