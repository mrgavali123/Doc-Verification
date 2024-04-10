using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Firebase.Database;
using Firebase.Database.Query;
using System.Diagnostics;
using QRCoder;
using FireBaseLib;
namespace AutoGenerateCertificate
{
    public partial class Transfer_info : Form
    {
        public Transfer_info()
        {
            InitializeComponent();
        }

        private void Transfer_info_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Fields cannot be empty");
                return;
            }
            
            try
            {
              
                if (textBox1.Text == "" && textBox2.Text == "")
                {

                    MessageBox.Show("Please Fill your full name and mothers name");

                }
                else
                {
                    Transfer_Pojo();
                    MessageBox.Show("Data Saved Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";


        }

        public void Transfer_Pojo()
        {
            Cursor.Current = Cursors.WaitCursor;
            FirebaseClient fb = FireBaseDB.init(FBConfig.url);
            TransferCertPojo fp = new TransferCertPojo();
            fp.Name = textBox1.Text;
            fp.Mothers_name = textBox2.Text;
            fp.Progress = comboBox1.Text;
            fp.Religion = textBox3.Text;
            fp.Caste = textBox4.Text;
            fp.Nationality = textBox5.Text;
            fp.Dob = dateTimePicker1.Text;
            fp.Date_in_words = textBox6.Text;
            fp.Place_of_birth = textBox7.Text;
            fp.Last_collage_attended = textBox8.Text;
            fp.Class_studying = textBox9.Text;
            fp.Remark = textBox11.Text;
            fp.Reason_leaving = textBox10.Text;
            fp.Doi = DateTime.Now.ToShortDateString();
         
            util.Block block = new util.Block(null, DateTime.Now.ToString(), fp);
            


            try
            {
                util.BlockChainManager bc = new util.BlockChainManager(block);
                util.Block myblock = bc.getBlock();

                QRCodeGenerator qr = new QRCodeGenerator();
                string link = "https://projectcg-docver1.web.app/?key=" + myblock.Hash + "&doc_type=transfer";

                QRCodeData data = qr.CreateQrCode(link, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(data);
                Bitmap bt = code.GetGraphic(5);
                Bitmap btrz = new Bitmap(bt,new Size(160,160));
                btrz.Save(Application.StartupPath+"\\qr\\" + myblock.TransferPojo.Name + ".jpg");


                PrintTransferCert(myblock);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:"+ex);
            }
            Cursor.Current = Cursors.Default;
        }
        void PrintTransferCert(util.Block myblock)
        {
            int topy = 5;
           // int myx = 50;
            XPen xpen = new XPen(XColor.FromArgb(0, 0, 0));
            XBrush xbrush = new XSolidBrush(XColor.FromArgb(0, 0, 0));

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Transfer Certificate";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage, XPageDirection.Downwards);
            string backgroundImagePath = Application.StartupPath + "\\img\\Pinkshade.png";
            XImage backgroundImage = XImage.FromFile(backgroundImagePath);

            // Draw the background image
            graph.DrawImage(backgroundImage, 0, 0, pdfPage.Width, pdfPage.Height);

            // Draw background
            // graph.DrawImage(XImage.FromFile(Application.StartupPath+"\\Head11.png"), 0, 0+topy);
            // graph.DrawImage(XImage.FromFile(Application.StartupPath + "\\qr\\" + textBox1.Text + ".jpg"), 400, 400 + topy);

            XFont font = new XFont("Times New Roman", 27, XFontStyle.Italic);
            //graph.DrawString("Emerging Technologies", font, XBrushes.Black, new XRect(180, 10 + topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            XFont font1 = new XFont("Times New Roman", 17, XFontStyle.Bold);
            XFont font2 = new XFont("Times New Roman", 12, XFontStyle.Regular);
            XFont font_ir1 = new XFont("Times New Roman", 12, XFontStyle.BoldItalic);

            //graph.DrawString("Software and Automation Solution", font1, XBrushes.Black, new XRect(180, 40 + topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            string logoPath = Application.StartupPath + "\\img\\MET.jpg";
            
            graph.DrawImage(XImage.FromFile(logoPath), 10, 5);

            XFont font25 = new XFont("Times New Roman", 25, XFontStyle.Regular);
            XFont font25B = new XFont("Times New Roman", 25, XFontStyle.Bold);
            /*
            string watermarkImagePath = Application.StartupPath + "\\img\\MET2.png";
            XImage watermarkImage = XImage.FromFile(watermarkImagePath);
            double centerX = (pdfPage.Width.Point - watermarkImage.PixelWidth * 1.5) / 2;
            double centerY = (pdfPage.Height.Point - watermarkImage.PixelHeight * 1.5) / 2;
            double opacity = 0.1; // Adjust the opacity value (0.0 to 1.0)
            double greyTone = 0.5; // Adjust the grey tone value (0.0 to 1.0)
            XColor watermarkColor = XColor.FromArgb((int)(255 * greyTone), (int)(255 * greyTone), (int)(255 * greyTone));
            graph.DrawImage(watermarkImage, centerX, centerY, watermarkImage.PixelWidth * 1.5, watermarkImage.PixelHeight * 1.5);
           // graph.Opacity = opacity;
            graph.DrawImage(watermarkImage, centerX, centerY, watermarkImage.PixelWidth * 1.5, watermarkImage.PixelHeight * 1.5);
            */
            topy = topy + 0;
            graph.DrawString("MET Bhujbal Knowledge City", font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy = topy + 10;
            graph.DrawString("COLLEGE OF ENGINEERING", font25B, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy = topy + 30;
            graph.DrawString("MET BKC Adgaon, Nashik 422003", font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            topy = topy + 10;
            graph.DrawString("Transfer Certificate", font25B, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy = topy + 30;
            graph.DrawString("T.C.No:", font1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString("              "+myblock.TransferPojo.Id, font1, XBrushes.Maroon, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString("        " + "                              General Register No.:" , font1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            topy += 25;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            graph.DrawString("No. change in any entry in this certificate shall be made except by the authority issuing it and any", font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            topy += 20;
            graph.DrawString("infringement of this requirement is liable to involve the imposition of penalty such as thar of rustication.", font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            topy = topy + 20;
            //graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            //topy += 10;
            //DrawGraph(new Rectangle(0, 0, 100, 50), "student", "");

            graph.DrawRectangle(xpen, 10, topy, pdfPage.Width - 20, pdfPage.Height - 100-topy);
            graph.DrawLine(xpen, (pdfPage.Width/2)-50, topy, (pdfPage.Width / 2)-50, pdfPage.Height - 100);

            topy += 20;
            graph.DrawString("1) Name of Student", font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(textBox1.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;

            graph.DrawString("2) Mother's Name", font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(textBox2.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;
            graph.DrawString("3) Religion", font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(textBox3.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;
            // graph.DrawString("3) Religion    "+textBox3.Text, font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString("4) Caste/Sub Caste", font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(textBox4.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            //graph.DrawString("   4) Caste/Sub Caste    "+textBox4.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;
            graph.DrawString("5) Nationality", font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(textBox5.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;//graph.DrawString("5) Nationality    " + textBox5.Text, font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString("6) Place of Birth", font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(textBox7.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            //graph.DrawString(" 6) Place of Birth    " + textBox7.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;

            graph.DrawString("7) Date of Birth   " ,font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(dateTimePicker1.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy += 10;
            graph.DrawString("    " + textBox6.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;

            graph.DrawString("8) Last college Attended  " , font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(textBox8.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;

            graph.DrawString("9) Date of admission to this college  ", font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(dateTimePicker2.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;
            graph.DrawString("10) Progress  ", font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(comboBox1.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            //graph.DrawString("10) Progress    " + comboBox1.Text, font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            //graph.DrawString("11) Conduct    " + " ", font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;

            graph.DrawString("11) Month & Year of Completion of Course", font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(dateTimePicker3.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;

            graph.DrawString("12) Class in which studying", font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(textBox9.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;

            graph.DrawString("13) Reason of this Leaving College" , font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(textBox10.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            topy += 20;
            graph.DrawLine(xpen, 10, topy, pdfPage.Width - 10, topy);
            topy += 20;

            graph.DrawString("14) Remarks      " , font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(textBox11.Text, font2, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            topy += 20;
            graph.DrawImage(XImage.FromFile(Application.StartupPath + "\\qr\\" + textBox1.Text + ".jpg"), 450, topy);
            topy = (int)(pdfPage.Height - 100) + 10;

            graph.DrawString("Certified that the above information is in accordance with the institute records.", font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            topy = topy+ 50;

            graph.DrawString("Date of Issue       Prepared By      Principal", font_ir1, XBrushes.Black, new XRect(20, topy, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            //topy += 30;
           // graph.DrawLine(xpen, 10, topy, pdfPage.Width-10, topy);

            string pdfFilename = Application.StartupPath + "\\transfer\\" + textBox1.Text + ".pdf";
            pdf.Save(pdfFilename);
            Process.Start(pdfFilename);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String dt = dateTimePicker1.Text;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
