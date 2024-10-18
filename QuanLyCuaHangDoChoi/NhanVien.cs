using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDoChoi
{
    public partial class NhanVien : Form
    {
        DataProvider conn = new DataProvider();
        DgvEvent dgvEvent = new DgvEvent();
        public int getWidth()
        {
            return 818;
        }
        public int getHeight() 
        {
            return 715;
        }
        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                LoadTime();
                dgvThongTin.RowTemplate.Height = 30;
            }
            catch { }
        }

        private void LoadData()
        {
            try
            {
                string query = "select MaNV,TenNV,SoDienThoai,GioiTinh,NgaySinh,DiaChi,CCCD,ChucVu from NhanVien";
                dgvThongTin.DataSource = conn.ReadData(query);
            }
            catch { }
        }
        private void LoadTime()
        {
            try
            {
                dateTimePicker.Value = DateTime.Now;
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
            pictureBox.Image = null;
            tbMaNV.Text = "";
            tbTenNV.Text = "";
            tbSDT.Text = "";
            checkBoxNam.Checked = false;
            checkBoxNu.Checked = false;
            LoadTime();
            tbDiaChi.Text = "";
            tbCCCD.Text = "";
            tbChucVu.Text = "";
            tbMaNV.ReadOnly = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            pictureBox.Image = null;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
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
                    ToolStripMenuItem menuItemThem = new ToolStripMenuItem("Thêm");
                    ToolStripMenuItem menuItemXoa = new ToolStripMenuItem("Xóa");
                    contextMenuStrip.Items.Add(menuItemThem);
                    contextMenuStrip.Items.Add(menuItemXoa);
                    menuItemThem.Click += new EventHandler(menuItemThem_Click);
                    menuItemXoa.Click += new EventHandler(menuItemXoa_Click);
                    contextMenuStrip.Show(pictureBox, e.Location);
                }
            }
            catch { }
        }

        private void menuItemXoa_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox.Image = null;
            }
            catch { }
        }

        private void menuItemThem_Click(object sender, EventArgs e)
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
        private byte[] getDefaultImage() 
        {
            string fileName = @"D:\C#\QuanLyCuaHangDoChoi\QuanLyCuaHangDoChoi\Image\HeThong\default-image.png";
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
            if (rowIndex >= 0 && rowIndex < dgvThongTin.RowCount - 1)
            {
                tbMaNV.ReadOnly = true;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                DataGridViewRow row = dgvThongTin.Rows[rowIndex];
                tbMaNV.Text = row.Cells["MaNV"].Value.ToString();
                tbTenNV.Text = row.Cells["TenNV"].Value.ToString();
                tbSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                string gender = row.Cells["GioiTinh"].Value.ToString();
                checkBoxNam.Checked = false;
                checkBoxNu.Checked = false;
                if (gender == "Nam")
                {
                    checkBoxNam.Checked = true;
                }
                else if (gender == "Nữ")
                {
                    checkBoxNu.Checked = true;
                }
                string birthDay = row.Cells["NgaySinh"].Value.ToString().Substring(0, 10);
                DateTime dateTime = DateTime.ParseExact(birthDay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePicker.Value = dateTime;
                tbDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                tbCCCD.Text = row.Cells["CCCD"].Value.ToString();
                tbChucVu.Text = row.Cells["ChucVu"].Value.ToString();
                string query = string.Format("select AnhChanDung from NhanVien where MaNV = N'{0}'", tbMaNV.Text);
                byte[] imageData = conn.SelectAnh(query);
                if (imageData != null)
                {
                    MemoryStream ms = new MemoryStream(imageData);
                    pictureBox.Image = Image.FromStream(ms);
                }
                else
                {
                    pictureBox.Image = null;
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenNV = tbTenNV.Text;
            try
            {
                DialogResult dialog = MessageBox.Show(string.Format("Bạn muốn thêm thông tin nhân viên:\nMã nhân viên: {0}\nTên nhân viên: {1}\nSố điện thoại: {2}\nGiới tính: {3}\nNgày sinh: {4}" +
                    "\nĐịa chỉ: {5}\nCCCD: {6}\nChức vụ: {7}", tbMaNV.Text, tbTenNV.Text, tbSDT.Text, getGioiTinh(), dateTimePicker.Value.ToString("yyyy-MM-dd"), tbDiaChi.Text, tbCCCD.Text, tbChucVu.Text), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    byte[] imageData = null;
                    Image image = pictureBox.Image;
                    if (image != null)
                    {
                        //tham khao chat gpt
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
                    string query = string.Format("insert into NhanVien(MaNV,TenNV,SoDienThoai,GioiTinh,NgaySinh,DiaChi,CCCD,ChucVu,AnhChanDung) values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',@Anh)"
                        , tbMaNV.Text.Trim(), tbTenNV.Text.Trim(), tbSDT.Text.Trim(), getGioiTinh().Trim(), dateTimePicker.Value.ToString("yyyy-MM-dd"), tbDiaChi.Text.Trim(), tbCCCD.Text.Trim(), tbChucVu.Text.Trim());
                    conn.ChangeData(query, imageData);
                    LoadData();
                    dgvEvent.selectRowAfterEdit(dgvThongTin, tbMaNV.Text);
                    LamMoi();
                    MessageBox.Show("Thêm thông tin nhân viên " + tenNV + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch 
            {
                MessageBox.Show("Thêm thông tin nhân viên " + tenNV + " thất bại", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("select MaNV,TenNV,SoDienThoai,GioiTinh,NgaySinh,DiaChi,CCCD,ChucVu from NhanVien where TenNV = N'{0}' or MaNV = N'{1}'", tbTimKiem.Text.Trim(),tbTimKiem.Text.Trim());
                dgvThongTin.DataSource = conn.ReadData(query);
            }
            catch { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenNV = tbTenNV.Text;
            try
            {
                DialogResult dialog = MessageBox.Show(string.Format("Bạn muốn sửa thông tin nhân viên:\nMã nhân viên: {0}\nTên nhân viên: {1}\nSố điện thoại: {2}\nGiới tính: {3}\nNgày sinh: {4}" +
                    "\nĐịa chỉ: {5}\nCCCD: {6}\nChức vụ: {7}", tbMaNV.Text, tbTenNV.Text, tbSDT.Text, getGioiTinh(), dateTimePicker.Value.ToString("yyyy-MM-dd"), tbDiaChi.Text, tbCCCD.Text, tbChucVu.Text), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    string query = string.Format("update NhanVien set TenNV=N'{0}',SoDienThoai= N'{1}',GioiTinh=N'{2}', NgaySinh=N'{3}',DiaChi=N'{4}',CCCD=N'{5}',ChucVu=N'{6}',AnhChanDung=@Anh where MaNV=N'{7}'"
                        , tbTenNV.Text.Trim(), tbSDT.Text.Trim(), getGioiTinh().Trim(), dateTimePicker.Value.ToString("yyyy-MM-dd"), tbDiaChi.Text.Trim(), tbCCCD.Text.Trim(), tbChucVu.Text.Trim(), tbMaNV.Text.Trim());
                    conn.ChangeData(query, imageData);
                    LoadData();
                    dgvEvent.selectRowAfterEdit(dgvThongTin, tbMaNV.Text);
                    LamMoi();
                    MessageBox.Show("Sửa nhân viên " + tenNV + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Sửa thông tin nhân viên " + tenNV + " thất bại", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenNV = tbTenNV.Text;
            try
            {
                DialogResult dialog = MessageBox.Show(string.Format("Bạn muốn xóa thông tin nhân viên:\nMã nhân viên: {0}\nTên nhân viên: {1}\nSố điện thoại: {2}\nGiới tính: {3}\nNgày sinh: {4}" +
                    "\nĐịa chỉ: {5}\nCCCD: {6}\nChức vụ: {7}", tbMaNV.Text, tbTenNV.Text, tbSDT.Text, getGioiTinh(), dateTimePicker.Value.ToString("yyyy-MM-dd"), tbDiaChi.Text, tbCCCD.Text, tbChucVu.Text), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    string query = string.Format("delete from NhanVien where MaNV=N'{0}' ", tbMaNV.Text.Trim());
                    conn.ChangeData(query);
                    LoadData();
                    LamMoi();
                    MessageBox.Show("Xóa nhân viên " + tenNV + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Xóa thông tin nhân viên " + tenNV + " thất bại", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
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
                string query = string.Format("select MaNV,TenNV,SoDienThoai,GioiTinh,NgaySinh,DiaChi,CCCD,ChucVu from NhanVien where TenNV Like N'%{0}%' or MaNV Like N'%{1}%'", tbTimKiem.Text.Trim(),tbTimKiem.Text.Trim());
                dgvThongTin.DataSource = conn.ReadData(query);
            }
            catch { }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            DataColumn column1 = new DataColumn("MaNhanVien");
            DataColumn column2 = new DataColumn("TenNhanVien");
            DataColumn column3 = new DataColumn("SoDienThoai");
            DataColumn column4 = new DataColumn("GioiTinh");
            DataColumn column5 = new DataColumn("NgaySinh");
            DataColumn column6 = new DataColumn("DiaChi");
            DataColumn column7 = new DataColumn("CCCD");
            DataColumn column8 = new DataColumn("ChucVu");

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
            ExportFile(dataTable, "Danh Sach Nhan Vien", "DANH SÁCH NHÂN VIÊN");
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
            cl1.Value2 = "Mã nhân viên";
            cl1.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tên nhân viên";
            cl2.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Số điện thoại";
            cl3.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Giới tính";
            cl4.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Ngày sinh";
            cl5.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Địa chỉ";
            cl6.ColumnWidth = 40;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "CCCD";
            cl7.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Vị trí";
            cl8.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");
            rowHead.Font.Bold = true;

            //Ke vien
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            //Thiet lap mau nen

            rowHead.Interior.ColorIndex = 8;

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
    }
}
