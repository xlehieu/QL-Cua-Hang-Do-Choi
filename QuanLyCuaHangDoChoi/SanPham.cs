using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyCuaHangDoChoi
{
    public partial class SanPham : Form
    {
        DataProvider conn = new DataProvider();
        DgvEvent dgvEvent = new DgvEvent();
        private string maNVThanhToan;
        public SanPham()
        {
            InitializeComponent();
        }
        public SanPham(string maNV)
        {
            InitializeComponent();
            this.maNVThanhToan = maNV;
        }

        public int  getWidth(){
            return 818;
        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                dgvThongTin.RowTemplate.Height = 30;
            }
            catch { }
        }

        private void LoadData()
        {
            string query = "select MaSP,TenSP,DonGiaNhap,DonGiaBan,TheLoai,ChatLieu,XuatXu,ThuongHieu,SoLuong from SanPham";
            dgvThongTin.DataSource = conn.ReadData(query);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("select MaSP,TenSP,DonGiaNhap,DonGiaBan,TheLoai,ChatLieu,XuatXu,ThuongHieu from SanPham where MaSP= N'{0}' or TenSP LIKE '%{0}%'", tbTimKiem.Text.Trim());
                dgvThongTin.DataSource = conn.ReadData(query);
            }
            catch { }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                LamMoi();
            }
            catch { }
        }

        private void LamMoi()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            tbMaSP.ReadOnly = false;
            tbMaSP.Text = "";
            tbTenSP.Text = "";
            tbDonGiaNhap.Text = "";
            tbDonGiaBan.Text = "";
            tbTheLoai.Text = "";
            tbChatLieu.Text = "";
            tbXuatXu.Text = "";
            tbThuongHieu.Text = "";
            pictureBox.Image = null;
            numericUpDown.Value = 0;
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

        private void dgvThongTin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int rowIndex = dgvEvent.keyDownDgv(sender, e, dgvThongTin);
                getDataFromDgv(rowIndex);
            }
            catch { }
        }
        private void getDataFromDgv(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvThongTin.RowCount - 1) 
            {
                btnThem.Enabled = false;
                if (!this.maNVThanhToan.Contains("NV"))
                {
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
                DataGridViewRow row = dgvThongTin.Rows[rowIndex];
                tbMaSP.Text = row.Cells["MaSP"].Value.ToString();
                tbTenSP.Text = row.Cells["TenSP"].Value.ToString();
                string numberString = row.Cells["DonGiaNhap"].Value.ToString();
                decimal number = decimal.Parse(numberString);
                tbDonGiaNhap.Text = number.ToString("N0");
                numberString = row.Cells["DonGiaBan"].Value.ToString();
                number = decimal.Parse(numberString);
                tbDonGiaBan.Text = number.ToString("N0");
                tbTheLoai.Text = row.Cells["TheLoai"].Value.ToString();
                tbChatLieu.Text = row.Cells["ChatLieu"].Value.ToString();
                tbXuatXu.Text = row.Cells["XuatXu"].Value.ToString();
                tbThuongHieu.Text = row.Cells["ThuongHieu"].Value.ToString();
                string query = string.Format("select AnhSanPham from SanPham where MaSP=N'{0}'",tbMaSP.Text);
                byte[] imageData = conn.SelectAnh(query);
                if (imageData != null) 
                {
                    MemoryStream ms = new MemoryStream(imageData);
                    pictureBox.Image = Image.FromStream(ms);
                }
                int parseValue;
                if (Int32.TryParse(row.Cells["SoLuong"].Value.ToString(), out parseValue))
                {
                    numericUpDown.Value = parseValue;
                }
                else { numericUpDown.Value = 0; }

            }
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                openFile.Title = "Chọn ảnh đẹp nha";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bitmap = new Bitmap(openFile.FileName);
                    pictureBox.Image = bitmap;
                }
            }
            catch { }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                    ToolStripMenuItem menuItemChange = new ToolStripMenuItem("Thay đổi ảnh");
                    ToolStripMenuItem menuTemDelete = new ToolStripMenuItem("Xóa ảnh");
                    contextMenuStrip.Items.Add(menuItemChange);
                    contextMenuStrip.Items.Add(menuTemDelete);
                    menuItemChange.Click += new EventHandler(menuItemChange_Click);
                    menuTemDelete.Click += new EventHandler(menuItemDelete_Click);
                    contextMenuStrip.Show(pictureBox, e.Location);
                }
            }
            catch { }
        }

        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            try
            {
            pictureBox.Image = null;
            }
            catch{}
        }

        private void menuItemChange_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Images file|*.jpg;*.jpeg;*.png;";
                openFile.Title = "Thay đổi ảnh";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bitmap = new Bitmap(openFile.FileName);
                    pictureBox.Image = bitmap;
                }
            }
            catch { }

        }
        private byte[] getDefaultImage()
        {
            string fileName = @"D:\C#\QuanLyCuaHangDoChoi\QuanLyCuaHangDoChoi\Image\HeThong\toys_image_default.png";
            Image image = Image.FromFile(fileName);
            byte[] imageData = null;
            if (image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                }
            }
            return imageData;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSP = tbMaSP.Text;
            string tenSP = tbTenSP.Text;
            try
            {
                string giaNhap = tbDonGiaNhap.Text;
                string giaBan = tbDonGiaBan.Text;
                giaBan.Replace(".", "").Replace(",","");
                giaNhap.Replace(".", "").Replace(",", ""); 
                DialogResult dialog = MessageBox.Show(string.Format("Bạn muốn thêm thông tin sản phẩm mới:\nMã sản phẩm: {0}\nTên sản phẩm: {1}\nĐơn giá nhập: {2}\nĐơn giá bán: {3}\nThể loại: {4}\nChất liệu: {5}\nXuất xứ: {6}\nThương hiệu: {7}\nSố lượng: {8}"
                    , tbMaSP.Text, tbTenSP.Text, giaNhap, giaBan, tbTheLoai.Text, tbChatLieu.Text, tbXuatXu.Text, tbThuongHieu.Text,numericUpDown.Value.ToString()), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    byte[] imageData = null;
                    Image image = pictureBox.Image;
                    if (image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            image.Save(ms, ImageFormat.Jpeg);
                            imageData = ms.ToArray();
                        }
                    }
                    else
                    {
                        imageData = getDefaultImage();
                    }
                    string query = string.Format("insert into SanPham(MaSP,TenSP,DonGiaNhap,DonGiaBan,TheLoai,ChatLieu,XuatXu,ThuongHieu,SoLuong,AnhSanPham) values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}','{8}',@Anh)"
                        , tbMaSP.Text.Trim(), tbTenSP.Text.Trim(), giaNhap, giaBan, tbTheLoai.Text.Trim(), tbChatLieu.Text.Trim(), tbXuatXu.Text.Trim(), tbThuongHieu.Text.Trim(),numericUpDown.Value.ToString());
                    conn.ChangeData(query, imageData);
                    LoadData();
                    dgvEvent.selectRowAfterEdit(dgvThongTin, maSP);
                    LamMoi();
                    MessageBox.Show("Thêm thông tin sản phẩm " + tenSP + " thành công", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch 
            {
                MessageBox.Show("Thêm thông tin sản phẩm "+tenSP+" thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSP = tbMaSP.Text;
            string tenSP = tbTenSP.Text;
            try
            {
                string giaNhap = tbDonGiaNhap.Text;
                string giaBan = tbDonGiaBan.Text;
                giaBan = giaBan.Replace(".", "");
                giaNhap = giaNhap.Replace(".", "");
                DialogResult dialog = MessageBox.Show(string.Format("Bạn muốn sửa thông tin sản phẩm:\nMã sản phẩm: {0}\nTên sản phẩm: {1}\nĐơn giá nhập: {2}\nĐơn giá bán: {3}\nThể loại: {4}\nChất liệu: {5}\nXuất xứ: {6}\nThương hiệu: {7}\nSố lượng: {8}"
                    , tbMaSP.Text, tbTenSP.Text, giaNhap, giaBan, tbTheLoai.Text, tbChatLieu.Text, tbXuatXu.Text, tbThuongHieu.Text, numericUpDown.Value.ToString()), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    byte[] imageData = null;
                    Image image = pictureBox.Image;
                    if (image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            image.Save(ms, ImageFormat.Jpeg);
                            imageData = ms.ToArray();
                        }
                    }
                    else
                    {
                        imageData = getDefaultImage();
                    }
                    string query = string.Format("update SanPham set TenSP=N'{0}',DonGiaNhap = N'{1}', DonGiaBan=N'{2}',TheLoai = N'{3}',ChatLieu=N'{4}',XuatXu=N'{5}',ThuongHieu=N'{6}',SoLuong='{7}',AnhSanPham=@Anh where MaSP = N'{8}' "
                        , tbTenSP.Text.Trim(), giaNhap, giaBan, tbTheLoai.Text.Trim(), tbChatLieu.Text.Trim(), tbXuatXu.Text.Trim(), tbThuongHieu.Text.Trim(),numericUpDown.Value.ToString() ,tbMaSP.Text.Trim());
                    conn.ChangeData(query, imageData);
                    LoadData();
                    dgvEvent.selectRowAfterEdit(dgvThongTin, maSP);
                    LamMoi();
                    MessageBox.Show("Sửa thông tin sản phẩm " + tenSP + " thành công", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch 
            {
                MessageBox.Show("Sửa thông tin sản phẩm "+tenSP+ "thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSP = tbMaSP.Text;
            string tenSP = tbTenSP.Text;
            try
            {
                DialogResult dialog = MessageBox.Show(string.Format("Bạn muốn xóa thông tin sản phẩm:\nMã sản phẩm: {0}\nTên sản phẩm: {1}\nĐơn giá nhập: {2}\nĐơn giá bán: {3}\nThể loại: {4}\nChất liệu: {5}\nXuất xứ: {6}\nThương hiệu: {7}"
                    , tbMaSP.Text, tbTenSP.Text, tbDonGiaNhap.Text, tbDonGiaBan.Text, tbTheLoai.Text, tbChatLieu.Text, tbXuatXu.Text, tbThuongHieu.Text), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    string query = string.Format("delete from SanPham where MaSP =N'{0}' ", tbMaSP.Text);
                    conn.ChangeData(query);
                    LoadData();
                    LamMoi();
                    MessageBox.Show("Xóa thông tin sản phẩm " + tenSP + " thành công", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch 
            {
                MessageBox.Show("Xóa thông tin sản phẩm "+tenSP+" thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportFile(DataTable dataTable, string sheetName, string title)
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
            cl1.Value2 = "Mã sản phẩm";
            cl1.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tên sản phẩm";
            cl2.ColumnWidth = 40;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Đơn giá nhập";
            cl3.ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Đơn giá bán";
            cl4.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Thể loại";
            cl5.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Chất liệu";
            cl6.ColumnWidth = 30;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Xuất xứ";
            cl7.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Thương hiệu";
            cl8.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");
            rowHead.Font.Bold = true;

            //Ke vien
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            //Thiet lap mau nen

            rowHead.Interior.ColorIndex = 4;

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

        private void btnXuat_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            DataColumn column1 = new DataColumn("MaSanPham");
            DataColumn column2 = new DataColumn("TenSanPham");
            DataColumn column3 = new DataColumn("DonGiaNhap");
            DataColumn column4 = new DataColumn("DonGiaBan");
            DataColumn column5 = new DataColumn("TheLoai");
            DataColumn column6 = new DataColumn("ChatLieu");
            DataColumn column7 = new DataColumn("XuatXu");
            DataColumn column8 = new DataColumn("ThuongHieu");

            dataTable.Columns.Add(column1);
            dataTable.Columns.Add(column2);
            dataTable.Columns.Add(column3);
            dataTable.Columns.Add(column4);
            dataTable.Columns.Add(column5);
            dataTable.Columns.Add(column6);
            dataTable.Columns.Add(column7);
            dataTable.Columns.Add(column8);

            foreach (DataGridViewRow dtgvRow in dgvThongTin.Rows)
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
            ExportFile(dataTable, "Danh Sach San Pham", "DANH SÁCH SẢN PHẨM");
        }
    }
}
