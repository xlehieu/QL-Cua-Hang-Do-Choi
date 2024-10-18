using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCuaHangDoChoi
{
    class DgvEvent
    {
        public void selectRowAfterEdit(DataGridView dgvThongTin,string ma) 
        {
            dgvThongTin.ClearSelection();
            foreach (DataGridViewRow row in dgvThongTin.Rows)
            {
                if (ma == row.Cells[0].Value.ToString()) 
                {
                    row.Selected = true;
                    dgvThongTin.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }
        public int keyDownDgv(object sender, KeyEventArgs e, DataGridView dgvThongTin) 
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                int rowIndex = dgvThongTin.CurrentRow.Index;
                if (e.KeyCode == Keys.Up)
                {
                    rowIndex--;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    rowIndex++;
                }
                return rowIndex;
            }
            return -1;
        }
    }
}
