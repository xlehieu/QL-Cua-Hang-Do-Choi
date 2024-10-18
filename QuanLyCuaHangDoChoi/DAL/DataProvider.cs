using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyCuaHangDoChoi
{
    class DataProvider
    {
        string strCon = @"Data Source=HIEU\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDoChoi;Integrated Security=True";
        //Buoc 1 khai bao chuoi ket noi 
        SqlConnection sqlCon = null;
        // buoc 2 mo ket noi
        public void OpenConnect()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }
        //buoc 3 buoc 4 khai bao thuc hien sql
        public DataTable ReadData(string query)
        {
            DataTable dt = new DataTable();
            OpenConnect();
            SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
            da.Fill(dt);
            CloseConnect();
            return dt;
        }

        public void ChangeData(string query, byte[] imageData=null)
        {
            OpenConnect();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            if (imageData != null)
            {
                sqlCmd.Parameters.AddWithValue("@Anh", imageData);
            }
            sqlCmd.ExecuteNonQuery();
            CloseConnect();
        }
        public byte[] SelectAnh(string query) 
        {
            OpenConnect();
            byte[] imageData = null;
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            object result = sqlCmd.ExecuteScalar();
            //tham khao chat gpt
            if (result != null && !Convert.IsDBNull(result)) 
            {
                imageData = (byte[])result;
            }
            CloseConnect();
            return imageData;
        }
        public int CountData(string query) 
        {
            int count = 0;
            OpenConnect();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            count = (int)sqlCmd.ExecuteScalar();
            return count;
        }
        public string SelectOneData(string query) 
        {
            OpenConnect();
            string data = "Không tìm thấy";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            object result = sqlCmd.ExecuteScalar();
            if (result != null) 
            {
                data = (string)result.ToString();
            }
            CloseConnect();
            return data;
        }
        // buoc 5 dong ket noi
        void CloseConnect()
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
    }
}
