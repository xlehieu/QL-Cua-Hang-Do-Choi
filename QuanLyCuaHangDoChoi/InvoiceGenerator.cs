using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace QuanLyCuaHangDoChoi
{
    class InvoiceGenerator
    {

        public void GeneratorInvoice(string filePath, InvoiceData invoiceData)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            document.Add(new Paragraph("Hóa đơn"));
            document.Add(new Paragraph($"Ngày :{invoiceData.Date.ToString()}"));
            document.Add(new Paragraph($"Số hóa đơn:{invoiceData.InvoiceNumber}"));

            document.Close();
        }


    }
    public class InvoiceData
    {
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
    }

}
