using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCuaHangDoChoi
{
    public partial class ThanhToan : Form
    {
        DataProvider conn = new DataProvider();
        private string maNV;
        private string tenNV;
        private List<ObjSanPham> listSanPham = new List<ObjSanPham>();
        private InvoiceData invoiceData = new InvoiceData();
        private bool canClick = true;
        
        public ThanhToan(string maNV,string tenNV)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            InitializeComponent();
        }
        float tongTien = 0;
        private void LoadFlowLayoutTheLoai() 
        {
            try
            {
                string query = "select distinct TheLoai from SanPham order by TheLoai asc";
                DataTable dt = conn.ReadData(query);
                foreach (DataRow row in dt.Rows)
                {
                    Button btn = new Button();
                    btn.Name = "btnTheLoai";
                    btn.BackColor = Color.FromArgb(56, 152, 253);
                    btn.Font = new Font("Micosoft Sans Serif", 10);
                    btn.ForeColor = Color.White;
                    btn.Size = new Size(100, flowLayoutTheLoai.Height - 25);
                    btn.Text = row.Field<string>("TheLoai");
                    btn.Click += btn_Click;
                    flowLayoutTheLoai.Controls.Add(btn);
                }
            }
            catch { }
        }

        void btn_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnTheLoai = (Button)sender;
                string theLoai = btnTheLoai.Text;
                if (theLoai != null)
                {
                    flowLayoutSanPham.Controls.Clear();
                    foreach (ObjSanPham sanPham in listSanPham)
                    {
                        if (theLoai == "Tất cả")
                        {
                            theLoai = "";
                        }
                        if (sanPham.TheLoai.Contains(theLoai))
                        {
                            PictureBox pictureBox = new PictureBox();
                            pictureBox.Image = sanPham.AnhSanPham;
                            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox.Size = new Size(100, 135);
                            pictureBox.Enabled = false;

                            Panel pnInLayoutSp = new Panel();
                            Size size = new Size(205, pictureBox.Height);
                            pnInLayoutSp.BorderStyle = BorderStyle.FixedSingle;
                            pnInLayoutSp.Size = size;

                            TextBox textboxMaSP = new TextBox();
                            textboxMaSP.Name = "textboxMaSP";
                            textboxMaSP.Multiline = true;
                            textboxMaSP.ReadOnly = true;
                            textboxMaSP.Size = new Size(pnInLayoutSp.Width - pictureBox.Width - 5, 50);
                            textboxMaSP.Enabled = false;
                            textboxMaSP.BorderStyle = BorderStyle.None;
                            textboxMaSP.BackColor = Color.White;


                            TextBox textboxTenSP = new TextBox();
                            textboxTenSP.Name = "textboxTenSP";
                            textboxTenSP.Multiline = true;
                            textboxTenSP.ReadOnly = true;
                            textboxTenSP.Size = new Size(pnInLayoutSp.Width - pictureBox.Width - 5, 50);
                            textboxTenSP.Enabled = false;
                            textboxTenSP.BorderStyle = BorderStyle.None;
                            textboxTenSP.BackColor = Color.White;

                            TextBox textboxGiaSP = new TextBox();
                            textboxGiaSP.Name = "textboxGiaSP";

                            textboxMaSP.Text = sanPham.MaSP;
                            textboxTenSP.Text = sanPham.TenSP;
                            textboxGiaSP.Text = sanPham.DonGiaBan.ToString();
                            textboxGiaSP.Enabled = false;
                            textboxGiaSP.Font = new Font("Microsoft Sans Serif", 5);

                            textboxMaSP.Location = new Point(pictureBox.Width + 5, 0);
                            textboxTenSP.Location = new Point(pictureBox.Width, pictureBox.Height - textboxTenSP.Height - 5);

                            pnInLayoutSp.Controls.Add(pictureBox);
                            pnInLayoutSp.Controls.Add(textboxMaSP);
                            pnInLayoutSp.Controls.Add(textboxTenSP);
                            pnInLayoutSp.Controls.Add(textboxGiaSP);

                            pnInLayoutSp.Click += new EventHandler(pnInLayoutSp_Click);
                            flowLayoutSanPham.Controls.Add(pnInLayoutSp);
                        }
                    }
                }
            }
            catch { }
        }
        private void LoadMaHD() 
        {
            try
            {
                string dateString = DateTime.Now.ToString("dd/MM/yy HH:mm:ss").Substring(0, 17);
                dateString = dateString.Replace("/", "").Replace(":", "").Replace(" ", "");
                string maHD = "HD" + dateString;
                string countMaHD = string.Format("select count(MaHD) from HoaDon where MaHD='{0}'", maHD.Trim());
                if (conn.CountData(countMaHD) <= 0)
                {
                    tbMaHD.Text = maHD;
                }
                else
                {
                    tbMaHD.Text = maHD + "0";
                }
            }
            catch { }
        }
        private void LoadDataToList()
        {
            try
            {
                string query = "select MaSP,TenSP,TheLoai,DonGiaBan from SanPham where SoLuong>0 order by TheLoai asc";
                DataTable dataTableSP = conn.ReadData(query);
                foreach (DataRow row in dataTableSP.Rows)
                {
                    string selectAnh = string.Format("select AnhSanPham from SanPham where MaSP = N'{0}'", row["MaSP"].ToString());
                    byte[] imageData = conn.SelectAnh(selectAnh);

                    MemoryStream ms = new MemoryStream(imageData);
                    Image image = Image.FromStream(ms);
                    float donGiaBan = float.Parse(row["DonGiaBan"].ToString());
                    ObjSanPham sanPham = new ObjSanPham(row["MaSP"].ToString(), row["TenSP"].ToString(), row["TheLoai"].ToString(), donGiaBan, image);
                    listSanPham.Add(sanPham);
                }
            }
            catch { }   
        }
        private void LoadDataTimKiem() 
        {
            try
            {
                flowLayoutSanPham.Controls.Clear();
                foreach (ObjSanPham sanPham in listSanPham)
                {
                    if (sanPham.MaSP.Contains(tbTimKiem.Text.ToLower()) || sanPham.TenSP.Contains(tbTimKiem.Text.ToLower()))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = sanPham.AnhSanPham;
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox.Size = new Size(100, 135);
                        pictureBox.Enabled = false;

                        Panel pnInLayoutSp = new Panel();
                        pnInLayoutSp.BorderStyle = BorderStyle.FixedSingle;
                        pnInLayoutSp.Size = new Size(205, pictureBox.Height);

                        TextBox textboxMaSP = new TextBox();
                        textboxMaSP.Name = "textboxMaSP";
                        textboxMaSP.Multiline = true;
                        textboxMaSP.ReadOnly = true;
                        textboxMaSP.Size = new Size(pnInLayoutSp.Width - pictureBox.Width - 5, 50);
                        textboxMaSP.Enabled = false;
                        textboxMaSP.BorderStyle = BorderStyle.None;
                        textboxMaSP.BackColor = Color.White;


                        TextBox textboxTenSP = new TextBox();
                        textboxTenSP.Name = "textboxTenSP";
                        textboxTenSP.Multiline = true;
                        textboxTenSP.ReadOnly = true;
                        textboxTenSP.Size = new Size(pnInLayoutSp.Width - pictureBox.Width - 5, 50);
                        textboxTenSP.Enabled = false;
                        textboxTenSP.BorderStyle = BorderStyle.None;
                        textboxTenSP.BackColor = Color.White;

                        TextBox textboxGiaSP = new TextBox();
                        textboxGiaSP.Name = "textboxGiaSP";

                        textboxMaSP.Text = sanPham.MaSP;
                        textboxTenSP.Text = sanPham.TenSP;
                        textboxGiaSP.Text = sanPham.DonGiaBan.ToString();
                        textboxGiaSP.Enabled = false;
                        textboxGiaSP.Font = new Font("Microsoft Sans Serif", 5);

                        textboxMaSP.Location = new Point(pictureBox.Width + 5, 0);
                        textboxTenSP.Location = new Point(pictureBox.Width, pictureBox.Height - textboxTenSP.Height - 5);

                        pnInLayoutSp.Controls.Add(pictureBox);
                        pnInLayoutSp.Controls.Add(textboxMaSP);
                        pnInLayoutSp.Controls.Add(textboxTenSP);
                        pnInLayoutSp.Controls.Add(textboxGiaSP);

                        pnInLayoutSp.Click += new EventHandler(pnInLayoutSp_Click);
                        flowLayoutSanPham.Controls.Add(pnInLayoutSp);
                    }
                }
            }
            catch { }
        }
        
        //Chat GPT
        //Khi click vao ô sản phẩm thì sẽ thêm vào datagridview
        private void pnInLayoutSp_Click(object sender, EventArgs e)
        {
            try
            {
                Panel panelSP = (Panel)sender;
                TextBox textboxMaSP = panelSP.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textboxMaSP");
                TextBox textboxTenSP = panelSP.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textboxTenSP");
                TextBox textboxGiaSP = panelSP.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textboxGiaSP");
                this.tongTien = 0;
                if (textboxMaSP != null && textboxTenSP != null && textboxGiaSP != null)
                {
                    // Sử dụng thông tin sản phẩm ở đây
                    bool check = false;
                    foreach (DataGridViewRow rowLoop in dgvThongTin.Rows)
                    {
                        if (dgvThongTin.RowCount > 0 && !rowLoop.IsNewRow) // IsNewRow nghĩa là cái hàng mà để chúng ta nhập liệu đó, ở đây nó kiểm tra xem có phải hàng đó hay không
                        {
                            if (rowLoop.Cells["MaSP"].Value.ToString() == textboxMaSP.Text)
                            {
                                int soLuong = Int32.Parse(rowLoop.Cells["SoLuong"].Value.ToString());
                                soLuong++;
                                rowLoop.Cells["SoLuong"].Value = soLuong.ToString();
                                float donGia = float.Parse(rowLoop.Cells["DonGia"].Value.ToString());
                                float giamGia = float.Parse(rowLoop.Cells["GiamGia"].Value.ToString());
                                float thanhTien = (donGia - (donGia * giamGia) / 100) * soLuong;
                                rowLoop.Cells["ThanhTien"].Value = thanhTien.ToString();
                                check = true;
                                break;
                            }
                        }
                    }
                    if (!check)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.Height = 50;
                        DataGridViewTextBoxCell cellMaSP = new DataGridViewTextBoxCell();
                        cellMaSP.Value = textboxMaSP.Text;

                        DataGridViewTextBoxCell cellTenSP = new DataGridViewTextBoxCell();
                        cellTenSP.Value = textboxTenSP.Text;

                        DataGridViewTextBoxCell cellSoLuong = new DataGridViewTextBoxCell();
                        cellSoLuong.Value = 1;

                        DataGridViewTextBoxCell cellDonGia = new DataGridViewTextBoxCell();
                        cellDonGia.Value = textboxGiaSP.Text;

                        DataGridViewTextBoxCell cellGiamGia = new DataGridViewTextBoxCell();
                        cellGiamGia.Value = 0;

                        DataGridViewTextBoxCell cellThanhTien = new DataGridViewTextBoxCell();
                        cellThanhTien.Value = textboxGiaSP.Text;

                        // Gán các ô (cột) vào DataGridViewRow
                        row.Cells.Add(cellMaSP);
                        row.Cells.Add(cellTenSP);
                        row.Cells.Add(cellSoLuong);
                        row.Cells.Add(cellDonGia);
                        row.Cells.Add(cellGiamGia);
                        row.Cells.Add(cellThanhTien);
                        dgvThongTin.Rows.Add(row);
                    }
                    if (dgvThongTin.RowCount < 0)
                    {
                        tbGiamGia.ReadOnly = true;
                        tbGiamGia.Text = "";
                    }
                }
                foreach (DataGridViewRow row in dgvThongTin.Rows)
                {
                    if (row.Index >= 0 && row.Index < dgvThongTin.RowCount)
                    {
                        DataGridViewCell cell = row.Cells["ThanhTien"];
                        float cellValue = float.Parse(cell.Value.ToString());
                        this.tongTien = this.tongTien + cellValue;
                    }
                }
                tbTongTien.Text = this.tongTien.ToString("N0");
            }
            catch { }
        }
        private void ThanhToan_Load(object sender, EventArgs e)
        {
            try
            {
                CreateNewButton();
                LoadDataToList();
                LoadFlowLayoutTheLoai();
                LoadMaHD();
                tbTenNV.Text = this.tenNV;
            }
            catch { }
        }
        private void tbSearchSDT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbSearchSDT.Text.Length == 10)
                {
                    string query = string.Format("select TenKH,TongGiaTriDonMua from KhachHang where MaKH= '{0}' or SoDienThoai= '{1}'", tbSearchSDT.Text.Trim(), tbSearchSDT.Text.Trim());
                    DataTable searchKH = conn.ReadData(query);
                    if (searchKH.Rows.Count > 0)
                    {
                        DataRow row = searchKH.Rows[0];
                        tbSearchTenKH.Text = row["TenKH"].ToString();
                        float tongTienDaThanhToan = float.Parse(row["TongGiaTriDonMua"].ToString());
                        if (tongTienDaThanhToan > 10000000)
                        {
                            tbGiamGia.Text = "10";
                        }
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show("Chưa có thông tin khách hàng, bạn có muốn thêm thông tin?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question))
                        {
                            KhachHang form = new KhachHang(tbSearchSDT.Text,this.maNV);
                            form.ShowDialog();
                            tbSearchTenKH.Text = conn.SelectOneData("select top 1 TenKH from KhachHang order by NgayThem desc");
                        }
                    }
                }
                else
                {
                    tbSearchTenKH.Text = "";
                    tbGiamGia.Text = "";
                }
            }
            catch { }
        }


        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDataTimKiem();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (canClick)
                {
                    LoadDataTimKiem();

                    canClick = false;

                    //Đặt thời gian chờ
                    Timer timer = new Timer();
                    timer.Interval = 3000; // 10 giây
                    timer.Tick += Timer_Tick;
                    timer.Start();
                }
                else
                {
                    MessageBox.Show("Xin vui lòng đợi");
                }
            }
            catch { }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Bật lại khả năng nhấp vào nút sau khi đã đợi đủ 10 giây
                canClick = true;
                // Dừng đếm thời gian và hủy đăng ký sự kiện
                Timer timer = (Timer)sender;
                timer.Stop();
                timer.Tick -= Timer_Tick;
                timer.Dispose();
            }
            catch { }
        }

        private void CreateNewButton()
        {
            try
            {
                Button btn = new Button();
                btn.Name = "btnTheLoai";
                btn.BackColor = Color.FromArgb(56, 152, 253);
                btn.Font = new Font("Micosoft Sans Serif", 10);
                btn.ForeColor = Color.White;
                btn.Size = new Size(100, flowLayoutTheLoai.Height - 25);
                btn.Text = "Tất cả";
                btn.Click += btn_Click;
                flowLayoutTheLoai.Controls.Add(btn);
            }
            catch { }
        }

        private void dgvThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            this.tongTien = 0;
            int rowIndex = dgvThongTin.CurrentRow.Index;
            int columnIndex = dgvThongTin.CurrentCell.ColumnIndex;
                if (columnIndex != 4)
                {
                    if (rowIndex >= 0 && rowIndex < dgvThongTin.RowCount)
                    {
                        int count = Int32.Parse(dgvThongTin.CurrentRow.Cells["SoLuong"].Value.ToString());
                        if (count > 1)
                        {
                            int soluong = --count;
                            dgvThongTin.CurrentRow.Cells["SoLuong"].Value = soluong.ToString();
                            float donGia = float.Parse(dgvThongTin.CurrentRow.Cells["DonGia"].Value.ToString());
                            float giamGia = float.Parse(dgvThongTin.CurrentRow.Cells["GiamGia"].Value.ToString());
                            float thanhTien = (donGia - (donGia * giamGia) / 100) * soluong;
                            dgvThongTin.CurrentRow.Cells["ThanhTien"].Value = thanhTien.ToString();
                            dgvThongTin.ClearSelection();
                        }
                        else
                        {
                            dgvThongTin.Rows.Remove(dgvThongTin.CurrentRow);
                        }
                    }
            }
            foreach (DataGridViewRow row in dgvThongTin.Rows)
            {
                if (row.Index >= 0 && row.Index < dgvThongTin.RowCount)
                {
                    DataGridViewCell cell = row.Cells["ThanhTien"];
                    float cellValue = float.Parse(cell.Value.ToString());
                    this.tongTien = this.tongTien + cellValue;
                }
            }
            tbTongTien.Text = this.tongTien.ToString("N0");
            if (dgvThongTin.RowCount <= 0)
            {
                tbGiamGia.ReadOnly = true;
                tbGiamGia.Text = "";
            }
            }
            catch { }

        }
        private bool CheckInfo()
        {

                if (tbMaHD.Text == "" || tbSearchSDT.Text == "" || tbTongTien.Text == "" || dgvThongTin.RowCount <= 0 || tbSearchTenKH.Text == "")
                {
                    return false;
                }
                return true;
        }
        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInfo())
                {
                    DataTable dt = conn.ReadData(string.Format("select distinct MaKH,TongGiaTriDonMua from KhachHang where SoDienThoai = '{0}'", tbSearchSDT.Text.Trim()));
                    DataRow rowData = dt.Rows[0];
                    conn.ChangeData(string.Format("insert into HoaDon(MaHD,MaKH,MaNV,NgayMua,GiamTong,TongTienThanhToan) values('{0}','{1}','{2}','{3}','{4}','{5}')"
                        , tbMaHD.Text.Trim(), rowData["MaKH"].ToString(), this.maNV, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), tbGiamGia.Text.Trim(), tbTongTien.Text.Replace(".", "").Trim()));
                    decimal tongGiaTriDonMua = decimal.Parse(rowData["TongGiaTriDonMua"].ToString());
                    tongGiaTriDonMua += decimal.Parse(tbTongTien.Text.Replace(".", "").Trim());
                    conn.ChangeData(string.Format("update KhachHang set TongGiaTriDonMua=N'{0}' where MaKH = '{1}'", tongGiaTriDonMua.ToString(), rowData["MaKH"].ToString()));
                    foreach (DataGridViewRow row in dgvThongTin.Rows)
                    {
                        string maSP = row.Cells["MaSP"].Value.ToString();
                        string soLuong = row.Cells["SoLuong"].Value.ToString();
                        string donGia = row.Cells["DonGia"].Value.ToString();
                        string giamGia = row.Cells["GiamGia"].Value.ToString();
                        string thanhTien = row.Cells["ThanhTien"].Value.ToString();
                        conn.ChangeData(string.Format("insert into CTHoaDon(MaHD,MaSP,SoLuong,DonGia,GiamGia,ThanhTien) values('{0}','{1}','{2}','{3}','{4}','{5}')"
                            , tbMaHD.Text.Trim(), maSP, soLuong, donGia, giamGia, thanhTien));
                        int soLuongKho = Int32.Parse(conn.SelectOneData(string.Format("select SoLuong from SanPham where MaSP='{0}'",maSP)));
                        conn.ChangeData(string.Format("update SanPham set SoLuong = '{0}' where MaSP = '{1}'",(soLuongKho-Int32.Parse(soLuong.Trim())).ToString(),maSP));
                    }
                    MessageBox.Show("Thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvThongTin_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvThongTin.Rows[e.RowIndex];
                this.tongTien = 0;
                if (e.RowIndex >= 0 && e.RowIndex < dgvThongTin.RowCount)
                {
                    try
                    {
                        DataGridViewCell editedCell = row.Cells[e.ColumnIndex];
                        object editedValue = editedCell.Value;
                        if (editedValue != null)
                        {
                            float giamGia = float.Parse(editedValue.ToString());
                            if (giamGia <= 100)
                            {
                                float donGia = float.Parse(row.Cells["DonGia"].Value.ToString());
                                float soluong = float.Parse(row.Cells["SoLuong"].Value.ToString());
                                float thanhTien = (donGia - (donGia * giamGia) / 100) * soluong;
                                dgvThongTin.Rows[e.RowIndex].Cells["ThanhTien"].Value = thanhTien.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Giảm giá không được vượt quá 100%");
                                dgvThongTin.CurrentRow.Cells["GiamGia"].Value = "0";
                                float donGia = float.Parse(row.Cells["DonGia"].Value.ToString());
                                float soluong = float.Parse(row.Cells["SoLuong"].Value.ToString());
                                giamGia = 0;
                                float thanhTien = (donGia - (donGia * giamGia) / 100) * soluong;
                                dgvThongTin.Rows[e.RowIndex].Cells["ThanhTien"].Value = thanhTien.ToString();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Giá trị phải là số");
                        dgvThongTin.CurrentRow.Cells["GiamGia"].Value = "0";
                        float donGia = float.Parse(row.Cells["DonGia"].Value.ToString());
                        float soluong = float.Parse(row.Cells["SoLuong"].Value.ToString());
                        float giamGia = 0;
                        float thanhTien = (donGia - (donGia * giamGia) / 100) * soluong;
                        dgvThongTin.Rows[e.RowIndex].Cells["ThanhTien"].Value = thanhTien.ToString();
                    }
                }
                foreach (DataGridViewRow rowThanhTien in dgvThongTin.Rows)
                {
                    if (rowThanhTien.Index >= 0 && rowThanhTien.Index < dgvThongTin.RowCount)
                    {
                        DataGridViewCell cellThanhTien = rowThanhTien.Cells["ThanhTien"];
                        float cellValue = float.Parse(cellThanhTien.Value.ToString());
                        this.tongTien = this.tongTien + cellValue;
                    }
                }
                tbTongTien.Text = this.tongTien.ToString("N0");
            }
            catch { }
        }

        private void tbGiamGia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float giam = float.Parse(tbGiamGia.Text);
                if (tbTongTien.Text != "" && tbGiamGia.Text != "")
                {
                    float tongTienCanTra = this.tongTien;
                    float giamGia = float.Parse(tbGiamGia.Text.Trim());
                    float tienPhaiThanhToan = tongTienCanTra - (tongTienCanTra * giamGia) / 100;
                    tbTongTien.Text = tienPhaiThanhToan.ToString("N0");
                }
                else if (tbTongTien.Text == "" && tbGiamGia.Text != "")
                {
                    tbTongTien.Text = "0";
                }
                else if (giam > 100)
                {
                    MessageBox.Show("Không thể giảm giá hơn 100%");
                }
                else
                {
                    tbTongTien.Text = this.tongTien.ToString("N0");
                }
            }
            catch { }
        }
        private void btnXoaDGV_Click(object sender, EventArgs e)
        {
            try
            {
                dgvThongTin.Rows.Clear();
                tbGiamGia.Text = "";
                tbTongTien.Text = "";
                tbTienKhachDua.Text = "";
                tbTienTraKhach.Text = "";
                tbSearchSDT.Text = "";
                tbSearchTenKH.Text = "";
            }
            catch { }
        }

        private void tbTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float tienThanhToan = float.Parse(tbTongTien.Text.Trim().Replace(".",""));
                float tienKhachDua = float.Parse(tbTienKhachDua.Text.Trim().Replace(".",""));
                tbTienTraKhach.Text = (tienKhachDua - tienThanhToan).ToString();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message,"Lỗi"); }
        }
    }
}
