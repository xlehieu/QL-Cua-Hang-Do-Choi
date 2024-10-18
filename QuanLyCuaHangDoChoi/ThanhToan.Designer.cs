using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoi
{
    partial class ThanhToan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThanhToan));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.tbTimKiem = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbTenNV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaHD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainerFullScreen = new System.Windows.Forms.SplitContainer();
            this.panelListSanPham = new System.Windows.Forms.Panel();
            this.dgvThongTin = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTienThanhToan = new System.Windows.Forms.Panel();
            this.tbGiamGia = new System.Windows.Forms.TextBox();
            this.tbTienTraKhach = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTienKhachDua = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTongTien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelThongTinHoaDon = new System.Windows.Forms.Panel();
            this.tbSearchSDT = new System.Windows.Forms.TextBox();
            this.tbSearchTenKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainerTheLoaiVaSP = new System.Windows.Forms.SplitContainer();
            this.flowLayoutTheLoai = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutSanPham = new System.Windows.Forms.FlowLayoutPanel();
            this.panelChucNang = new System.Windows.Forms.Panel();
            this.btnXoaDGV = new System.Windows.Forms.Button();
            this.btnLuuHoaDon = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFullScreen)).BeginInit();
            this.splitContainerFullScreen.Panel1.SuspendLayout();
            this.splitContainerFullScreen.Panel2.SuspendLayout();
            this.splitContainerFullScreen.SuspendLayout();
            this.panelListSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTin)).BeginInit();
            this.panelTienThanhToan.SuspendLayout();
            this.panelThongTinHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTheLoaiVaSP)).BeginInit();
            this.splitContainerTheLoaiVaSP.Panel1.SuspendLayout();
            this.splitContainerTheLoaiVaSP.Panel2.SuspendLayout();
            this.splitContainerTheLoaiVaSP.SuspendLayout();
            this.panelChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnTimKiem);
            this.panelHeader.Controls.Add(this.tbTimKiem);
            this.panelHeader.Controls.Add(this.label15);
            this.panelHeader.Controls.Add(this.tbTenNV);
            this.panelHeader.Controls.Add(this.label3);
            this.panelHeader.Controls.Add(this.tbMaHD);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1491, 72);
            this.panelHeader.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(1181, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(151, 39);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbTimKiem
            // 
            this.tbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbTimKiem.Location = new System.Drawing.Point(779, 26);
            this.tbTimKiem.Name = "tbTimKiem";
            this.tbTimKiem.Size = new System.Drawing.Size(378, 27);
            this.tbTimKiem.TabIndex = 5;
            this.tbTimKiem.TextChanged += new System.EventHandler(this.tbTimKiem_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label15.Location = new System.Drawing.Point(696, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 20);
            this.label15.TabIndex = 4;
            this.label15.Text = "Tìm kiếm";
            // 
            // tbTenNV
            // 
            this.tbTenNV.BackColor = System.Drawing.Color.White;
            this.tbTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbTenNV.Location = new System.Drawing.Point(472, 26);
            this.tbTenNV.Name = "tbTenNV";
            this.tbTenNV.ReadOnly = true;
            this.tbTenNV.Size = new System.Drawing.Size(160, 27);
            this.tbTenNV.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(333, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên thu ngân:";
            // 
            // tbMaHD
            // 
            this.tbMaHD.BackColor = System.Drawing.Color.White;
            this.tbMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbMaHD.Location = new System.Drawing.Point(134, 26);
            this.tbMaHD.Name = "tbMaHD";
            this.tbMaHD.ReadOnly = true;
            this.tbMaHD.Size = new System.Drawing.Size(184, 27);
            this.tbMaHD.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn:";
            // 
            // splitContainerFullScreen
            // 
            this.splitContainerFullScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFullScreen.Location = new System.Drawing.Point(0, 72);
            this.splitContainerFullScreen.Name = "splitContainerFullScreen";
            // 
            // splitContainerFullScreen.Panel1
            // 
            this.splitContainerFullScreen.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.splitContainerFullScreen.Panel1.Controls.Add(this.panelListSanPham);
            this.splitContainerFullScreen.Panel1.Controls.Add(this.panelTienThanhToan);
            this.splitContainerFullScreen.Panel1.Controls.Add(this.panelThongTinHoaDon);
            // 
            // splitContainerFullScreen.Panel2
            // 
            this.splitContainerFullScreen.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerFullScreen.Panel2.Controls.Add(this.splitContainerTheLoaiVaSP);
            this.splitContainerFullScreen.Panel2.Controls.Add(this.panelChucNang);
            this.splitContainerFullScreen.Size = new System.Drawing.Size(1491, 816);
            this.splitContainerFullScreen.SplitterDistance = 521;
            this.splitContainerFullScreen.TabIndex = 1;
            // 
            // panelListSanPham
            // 
            this.panelListSanPham.BackColor = System.Drawing.Color.White;
            this.panelListSanPham.Controls.Add(this.dgvThongTin);
            this.panelListSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.panelListSanPham.Location = new System.Drawing.Point(0, 91);
            this.panelListSanPham.Name = "panelListSanPham";
            this.panelListSanPham.Size = new System.Drawing.Size(521, 616);
            this.panelListSanPham.TabIndex = 8;
            // 
            // dgvThongTin
            // 
            this.dgvThongTin.AllowUserToAddRows = false;
            this.dgvThongTin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongTin.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvThongTin.ColumnHeadersHeight = 51;
            this.dgvThongTin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.SoLuong,
            this.DonGia,
            this.GiamGia,
            this.ThanhTien});
            this.dgvThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongTin.GridColor = System.Drawing.Color.Goldenrod;
            this.dgvThongTin.Location = new System.Drawing.Point(0, 0);
            this.dgvThongTin.Name = "dgvThongTin";
            this.dgvThongTin.RowHeadersVisible = false;
            this.dgvThongTin.RowHeadersWidth = 50;
            this.dgvThongTin.RowTemplate.Height = 24;
            this.dgvThongTin.Size = new System.Drawing.Size(521, 616);
            this.dgvThongTin.TabIndex = 0;
            this.dgvThongTin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongTin_CellClick);
            this.dgvThongTin.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongTin_CellEndEdit);
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "MaSP";
            this.MaSP.MinimumWidth = 92;
            this.MaSP.Name = "MaSP";
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.MinimumWidth = 140;
            this.TenSP.Name = "TenSP";
            this.TenSP.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "S.L";
            this.SoLuong.MinimumWidth = 40;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.MinimumWidth = 91;
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            // 
            // GiamGia
            // 
            this.GiamGia.DataPropertyName = "GiamGia";
            this.GiamGia.HeaderText = "Giảm giá";
            this.GiamGia.MinimumWidth = 60;
            this.GiamGia.Name = "GiamGia";
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.MinimumWidth = 92;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            // 
            // panelTienThanhToan
            // 
            this.panelTienThanhToan.Controls.Add(this.tbGiamGia);
            this.panelTienThanhToan.Controls.Add(this.tbTienTraKhach);
            this.panelTienThanhToan.Controls.Add(this.label8);
            this.panelTienThanhToan.Controls.Add(this.tbTienKhachDua);
            this.panelTienThanhToan.Controls.Add(this.label7);
            this.panelTienThanhToan.Controls.Add(this.tbTongTien);
            this.panelTienThanhToan.Controls.Add(this.label6);
            this.panelTienThanhToan.Controls.Add(this.label5);
            this.panelTienThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTienThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.panelTienThanhToan.Location = new System.Drawing.Point(0, 707);
            this.panelTienThanhToan.Name = "panelTienThanhToan";
            this.panelTienThanhToan.Size = new System.Drawing.Size(521, 109);
            this.panelTienThanhToan.TabIndex = 7;
            // 
            // tbGiamGia
            // 
            this.tbGiamGia.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbGiamGia.BackColor = System.Drawing.Color.White;
            this.tbGiamGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbGiamGia.Location = new System.Drawing.Point(372, 22);
            this.tbGiamGia.Name = "tbGiamGia";
            this.tbGiamGia.Size = new System.Drawing.Size(139, 27);
            this.tbGiamGia.TabIndex = 3;
            this.tbGiamGia.TextChanged += new System.EventHandler(this.tbGiamGia_TextChanged);
            // 
            // tbTienTraKhach
            // 
            this.tbTienTraKhach.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbTienTraKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbTienTraKhach.Location = new System.Drawing.Point(372, 70);
            this.tbTienTraKhach.Name = "tbTienTraKhach";
            this.tbTienTraKhach.ReadOnly = true;
            this.tbTienTraKhach.Size = new System.Drawing.Size(139, 27);
            this.tbTienTraKhach.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(235, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tiền trả khách:";
            // 
            // tbTienKhachDua
            // 
            this.tbTienKhachDua.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbTienKhachDua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbTienKhachDua.Location = new System.Drawing.Point(146, 70);
            this.tbTienKhachDua.Name = "tbTienKhachDua";
            this.tbTienKhachDua.Size = new System.Drawing.Size(135, 27);
            this.tbTienKhachDua.TabIndex = 4;
            this.tbTienKhachDua.TextChanged += new System.EventHandler(this.tbTienKhachDua_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(4, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Tiền khách đưa:";
            // 
            // tbTongTien
            // 
            this.tbTongTien.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbTongTien.BackColor = System.Drawing.Color.White;
            this.tbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbTongTien.Location = new System.Drawing.Point(146, 22);
            this.tbTongTien.Name = "tbTongTien";
            this.tbTongTien.ReadOnly = true;
            this.tbTongTien.Size = new System.Drawing.Size(135, 27);
            this.tbTongTien.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(274, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Giảm giá:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(48, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tổng tiền:";
            // 
            // panelThongTinHoaDon
            // 
            this.panelThongTinHoaDon.Controls.Add(this.tbSearchSDT);
            this.panelThongTinHoaDon.Controls.Add(this.tbSearchTenKH);
            this.panelThongTinHoaDon.Controls.Add(this.label2);
            this.panelThongTinHoaDon.Controls.Add(this.label4);
            this.panelThongTinHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelThongTinHoaDon.Location = new System.Drawing.Point(0, 0);
            this.panelThongTinHoaDon.Name = "panelThongTinHoaDon";
            this.panelThongTinHoaDon.Size = new System.Drawing.Size(521, 91);
            this.panelThongTinHoaDon.TabIndex = 6;
            // 
            // tbSearchSDT
            // 
            this.tbSearchSDT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbSearchSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbSearchSDT.Location = new System.Drawing.Point(176, 10);
            this.tbSearchSDT.Name = "tbSearchSDT";
            this.tbSearchSDT.Size = new System.Drawing.Size(184, 27);
            this.tbSearchSDT.TabIndex = 1;
            this.tbSearchSDT.TextChanged += new System.EventHandler(this.tbSearchSDT_TextChanged);
            // 
            // tbSearchTenKH
            // 
            this.tbSearchTenKH.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbSearchTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbSearchTenKH.Location = new System.Drawing.Point(176, 51);
            this.tbSearchTenKH.Name = "tbSearchTenKH";
            this.tbSearchTenKH.ReadOnly = true;
            this.tbSearchTenKH.Size = new System.Drawing.Size(184, 27);
            this.tbSearchTenKH.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(9, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã/SĐT khách hàng:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(4, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên khách hàng:";
            // 
            // splitContainerTheLoaiVaSP
            // 
            this.splitContainerTheLoaiVaSP.BackColor = System.Drawing.Color.White;
            this.splitContainerTheLoaiVaSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerTheLoaiVaSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTheLoaiVaSP.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTheLoaiVaSP.Name = "splitContainerTheLoaiVaSP";
            this.splitContainerTheLoaiVaSP.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTheLoaiVaSP.Panel1
            // 
            this.splitContainerTheLoaiVaSP.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.splitContainerTheLoaiVaSP.Panel1.Controls.Add(this.flowLayoutTheLoai);
            // 
            // splitContainerTheLoaiVaSP.Panel2
            // 
            this.splitContainerTheLoaiVaSP.Panel2.Controls.Add(this.flowLayoutSanPham);
            this.splitContainerTheLoaiVaSP.Size = new System.Drawing.Size(966, 755);
            this.splitContainerTheLoaiVaSP.SplitterDistance = 124;
            this.splitContainerTheLoaiVaSP.TabIndex = 1;
            // 
            // flowLayoutTheLoai
            // 
            this.flowLayoutTheLoai.AutoScroll = true;
            this.flowLayoutTheLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutTheLoai.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutTheLoai.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutTheLoai.Name = "flowLayoutTheLoai";
            this.flowLayoutTheLoai.Size = new System.Drawing.Size(964, 122);
            this.flowLayoutTheLoai.TabIndex = 0;
            // 
            // flowLayoutSanPham
            // 
            this.flowLayoutSanPham.AutoScroll = true;
            this.flowLayoutSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutSanPham.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutSanPham.Name = "flowLayoutSanPham";
            this.flowLayoutSanPham.Size = new System.Drawing.Size(964, 625);
            this.flowLayoutSanPham.TabIndex = 0;
            // 
            // panelChucNang
            // 
            this.panelChucNang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.panelChucNang.Controls.Add(this.btnXoaDGV);
            this.panelChucNang.Controls.Add(this.btnLuuHoaDon);
            this.panelChucNang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelChucNang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.panelChucNang.Location = new System.Drawing.Point(0, 755);
            this.panelChucNang.Name = "panelChucNang";
            this.panelChucNang.Size = new System.Drawing.Size(966, 61);
            this.panelChucNang.TabIndex = 2;
            // 
            // btnXoaDGV
            // 
            this.btnXoaDGV.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnXoaDGV.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDGV.Image")));
            this.btnXoaDGV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDGV.Location = new System.Drawing.Point(0, 0);
            this.btnXoaDGV.Name = "btnXoaDGV";
            this.btnXoaDGV.Size = new System.Drawing.Size(220, 61);
            this.btnXoaDGV.TabIndex = 8;
            this.btnXoaDGV.Text = "Làm mới hóa đơn";
            this.btnXoaDGV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaDGV.UseVisualStyleBackColor = true;
            this.btnXoaDGV.Click += new System.EventHandler(this.btnXoaDGV_Click);
            // 
            // btnLuuHoaDon
            // 
            this.btnLuuHoaDon.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLuuHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuHoaDon.Image")));
            this.btnLuuHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuHoaDon.Location = new System.Drawing.Point(796, 0);
            this.btnLuuHoaDon.Name = "btnLuuHoaDon";
            this.btnLuuHoaDon.Size = new System.Drawing.Size(170, 61);
            this.btnLuuHoaDon.TabIndex = 6;
            this.btnLuuHoaDon.Text = "Lưu hóa đơn";
            this.btnLuuHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuHoaDon.UseVisualStyleBackColor = true;
            this.btnLuuHoaDon.Click += new System.EventHandler(this.btnLuuHoaDon_Click);
            // 
            // ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1491, 888);
            this.Controls.Add(this.splitContainerFullScreen);
            this.Controls.Add(this.panelHeader);
            this.Name = "ThanhToan";
            this.Text = "ThanhToan";
            this.Load += new System.EventHandler(this.ThanhToan_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.splitContainerFullScreen.Panel1.ResumeLayout(false);
            this.splitContainerFullScreen.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFullScreen)).EndInit();
            this.splitContainerFullScreen.ResumeLayout(false);
            this.panelListSanPham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTin)).EndInit();
            this.panelTienThanhToan.ResumeLayout(false);
            this.panelTienThanhToan.PerformLayout();
            this.panelThongTinHoaDon.ResumeLayout(false);
            this.panelThongTinHoaDon.PerformLayout();
            this.splitContainerTheLoaiVaSP.Panel1.ResumeLayout(false);
            this.splitContainerTheLoaiVaSP.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTheLoaiVaSP)).EndInit();
            this.splitContainerTheLoaiVaSP.ResumeLayout(false);
            this.panelChucNang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.SplitContainer splitContainerFullScreen;
        private System.Windows.Forms.SplitContainer splitContainerTheLoaiVaSP;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutTheLoai;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutSanPham;
        private System.Windows.Forms.TextBox tbTenNV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMaHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearchTenKH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSearchSDT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTienThanhToan;
        private System.Windows.Forms.TextBox tbGiamGia;
        private System.Windows.Forms.TextBox tbTienTraKhach;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTienKhachDua;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTongTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelThongTinHoaDon;
        private System.Windows.Forms.Panel panelChucNang;
        private System.Windows.Forms.Panel panelListSanPham;
        private System.Windows.Forms.DataGridView dgvThongTin;
        private System.Windows.Forms.Button btnLuuHoaDon;
        private System.Windows.Forms.TextBox tbTimKiem;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXoaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
    }
}