using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Firebase.Database;
using Firebase.Database.Query;
using System.Diagnostics;
using System.Windows.Forms;
using QRCoder;
using FireBaseLib;
using AutoGenerateCertificate.pojo;
using AutoGenerateCertificate.util;
namespace AutoGenerateCertificate
{
    public partial class Frm_Add_Bonafide : Form
    {

        public Frm_Add_Bonafide()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDashBoard DB = new FrmDashBoard();
            DB.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }



        private void button3_Click(object sender, EventArgs e)
        {
            
        }

      

     


        private void Internship_Completion_Load(object sender, EventArgs e)
        {

        }


        public String readableDate(String strDate)
        {
            String[] d = strDate.Split('-');
            int day = int.Parse(d[0]);
            String s = "";
            if (day % 10 == 1 && day % 100 != 11)
                s = "st";
            else if (day % 10 == 2 && day % 100 != 12)
                s = "nd";
            else if (day % 10 == 3 && day % 100 != 13)
                s = "rd";
            else
                s = "th";
            String res = day + s + " " + d[1] + " " + d[2];
            return res;
        }
        

        private void textBox5_Click(object sender, EventArgs e)
        {

        }

       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            //textBox2.Text = "";
            combobranch.Text = "";
            comboyear.Text = "";
            //textBox3.Text = "";
            combobranch.Text = "";
            //textBox4.Text = "";
            textBox5.Text = "";
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        public void Upload_Bonafide_Data()
        {
            Cursor.Current = Cursors.WaitCursor;
            FirebaseClient fb = FireBaseDB.init(FBConfig.url);
            BonafidePojo bfp = new BonafidePojo();
            bfp.Name = txtname.Text;
            bfp.Branch = combobranch.Text;
            bfp.Academic_year = comboyear.Text;
            bfp.Reason = txtreason.Text;
            bfp.Date = DateTime.Now.ToShortDateString();
           // fb.Child("BonafidePojo").Child(bfp.Academic_year).PutAsync(bfp);
            // fb.Child("").PostAsync(bfp).Wait();
            util.BlockBonafide block = new util.BlockBonafide(null, DateTime.Now.ToString(), bfp);



            try
            {
                util.BlockChainManager bc = new util.BlockChainManager(block);
                util.BlockBonafide myblock = bc.getBlock_Bonafide();

                QRCodeGenerator qr = new QRCodeGenerator();
                string link = "https://projectdoc-ver3.web.app/?key=" + myblock.Hash+ "&doc_type=bonafide";


                QRCodeData data = qr.CreateQrCode(link, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(data);
                Bitmap bt = code.GetGraphic(5);
                Bitmap btrz = new Bitmap(bt, new Size(160, 160));
                string tm = DateTime.Now.Millisecond+"";
                string qrPath = Application.StartupPath + "\\bonafideqr\\" + myblock.BonafidePojo.Name + "_" + tm + ".jpg";
                btrz.Save(qrPath);


                PrintBonafideCert(myblock,qrPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }
            Cursor.Current = Cursors.Default;
        }

        void PrintBonafideCert(util.BlockBonafide myblock,string qrPath)
        {
            int topy = 5;
            // int myx = 50;
            XPen xpen = new XPen(XColor.FromArgb(0, 0, 0));
            XBrush xbrush = new XSolidBrush(XColor.FromArgb(0, 0, 0));

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Bonafide Certificate";
            PdfPage pdfPage = pdf.AddPage();
            pdfPage.Height = 500;
            XGraphics graph = XGraphics.FromPdfPage(pdfPage, XPageDirection.Downwards);
            // Draw background
            // graph.DrawImage(XImage.FromFile(Application.StartupPath+"\\Head11.png"), 0, 0+topy);
            // graph.DrawImage(XImage.FromFile(Application.StartupPath + "\\qr\\" + textBox1.Text + ".jpg"), 400, 400 + topy);

            XFont font = new XFont("Times New Roman", 27, XFontStyle.Italic);
            //graph.DrawString("Emerging Technologies", font, XBrushes.Black, new XRect(180, 10 + topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            XFont font1 = new XFont("Times New Roman", 17, XFontStyle.Bold);
            XFont font1U = new XFont("Times New Roman", 17, XFontStyle.Underline);
            XFont font2 = new XFont("Times New Roman", 12, XFontStyle.Regular);
            XFont font_ir1 = new XFont("Times New Roman", 12, XFontStyle.BoldItalic);
            XFont font17I = new XFont("Times New Roman", 17, XFontStyle.Italic);
            //graph.DrawString("Software and Automation Solution", font1, XBrushes.Black, new XRect(180, 40 + topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawRectangle(xpen, 10, 10, pdfPage.Width - 20, pdfPage.Height - 30 - topy);

            XFont font25 = new XFont("Times New Roman", 25, XFontStyle.Regular);
            XFont font25B = new XFont("Times New Roman", 22, XFontStyle.Bold);
            XFont font25U = new XFont("Times New Roman", 25, XFontStyle.Underline);
            topy = topy + 10;
            string logoPath = Application.StartupPath + "\\img\\MET.jpg";

            graph.DrawImage(XImage.FromFile(logoPath), 15, topy);

            graph.DrawString("MET Bhujbal Knowledge City", font25B, XBrushes.Red, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy = topy + 30;
            graph.DrawString("Institue OF ENGINEERING", font25B, XBrushes.Red, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy = topy + 30;
            graph.DrawString("MET BKC Adgaon, Dist.Nashik 422003", font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

           // topy = topy + 20;
            //graph.DrawString("(Apporved by AICTE, New Delhi & Affiliated to Pune University)", font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy = topy + 20;
            graph.DrawString("Ref. No MET/IOE/SS", font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString("Date: "+myblock.BonafidePojo.Date+"            ", font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopRight);
            topy = topy + 25;
            graph.DrawString("BONAFIDE CERTFICATE", font25U, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

          
            //graph.DrawLine(xpen, 20, topy, pdfPage.Width - 50, topy);
            topy = topy + 50;
            graph.DrawString("      This is to certify that Mr./Ms. ", font17I, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(myblock.BonafidePojo.Name, font1U, XBrushes.Black, new XRect(250, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            topy = topy + 20;
            graph.DrawString("is a bonafide student of this college studying in "+myblock.BonafidePojo.Branch, font17I, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            //graph.DrawString("                      "+myblock.BonafidePojo.Branch, font1U, XBrushes.Black, new XRect(250, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            topy = topy + 20;
            graph.DrawString("Engineering degree course for the academic year "+myblock.BonafidePojo.Academic_year, font17I, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            //graph.DrawString("                     "+myblock.BonafidePojo.Academic_year, font1U, XBrushes.Black, new XRect(250, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            topy = topy + 20;
            graph.DrawString("The certificate is issued on student's request for  "+myblock.BonafidePojo.Reason , font17I, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            //graph.DrawString("                      "+myblock.BonafidePojo.Reason, font1U, XBrushes.Black, new XRect(250, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            topy = topy + 50;

            graph.DrawString("   Seal ", font2, XBrushes.Black, new XRect(20, pdfPage.Height-30-12-10, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            topy += 20;
            graph.DrawImage(XImage.FromFile(qrPath), 450, topy);


            string pdfFilename = Application.StartupPath + "\\transfer\\" + myblock.BonafidePojo.Name + ".pdf";
            pdf.Save(pdfFilename);
            Process.Start(pdfFilename);
        }


        private void button_WOC1_Click(object sender, EventArgs e)
        {
            if(txtname.Text == "")
            {
                MessageBox.Show("Please Add Student Name");
                return;
            }
            if (combobranch.Text == "" || combobranch.Text=="-Select Branch-")
            {
                MessageBox.Show("Please Select Branch");
                return;
            }
            if (comboyear.Text == "" || comboyear.Text.ToLower() == "-Select Year-".ToLower())
            {
                MessageBox.Show("Please Select Year");
                return;
            }
            if (txtreason.Text == "" || txtreason.Text.Length < 5)
            {
                MessageBox.Show("Please Specify Valid Reason");
                return;
            }
            Upload_Bonafide_Data();
        }
    }
}
