using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoGenerateCertificate.pojo;
using AutoGenerateCertificate.util;
using FireBaseLib;

namespace AutoGenerateCertificate
{
    public partial class Frm_TransferList : Form
    {
        public Frm_TransferList()
        {
            InitializeComponent();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            String strblock = "BlockTransferCert";

            var fb = FireBaseDB.init(FBConfig.url);
            var task = fb.Child(strblock).OnceAsync<Block>();
            task.Wait();
            var fbdata = task.Result;
            List<TransferAdaptor> Tlist = new List<TransferAdaptor>();
            int f = 0;
            int c = 1;
            foreach (var data in fbdata)
            {
                TransferAdaptor bf = new TransferAdaptor();
                
                bf.Hash = data.Object.Hash;
                bf.Prevhash = data.Object.Prevhash;
                bf.Timestamp = data.Object.Timestamp;
                bf.Iscurrupted = data.Object.Iscurrupted;
                bf.Name = data.Object.TransferPojo.Name;
                bf.Nationality = data.Object.TransferPojo.Nationality;
                bf.Place_of_birth = data.Object.TransferPojo.Place_of_birth;
                bf.Id = data.Object.TransferPojo.Id;
                bf.Doi = data.Object.TransferPojo.Doi;
                bf.Dob = data.Object.TransferPojo.Dob;
                bf.Class_studying = data.Object.TransferPojo.Class_studying;
                bf.Reason_leaving = data.Object.TransferPojo.Reason_leaving;
                bf.Religion = data.Object.TransferPojo.Religion;

                TransferCertPojo tf = data.Object.TransferPojo;

                Block block = new util.Block(bf.Hash, bf.Timestamp,tf);
                if (block.Hash == bf.Hash)
                {
                    bf.Iscurrupted = "true";
                }
                else
                {
                    bf.Iscurrupted = "false";
                }
                Tlist.Add(bf);
                f = 1;

            }
            dataGridView1.DataSource = Tlist;


        }
    
    }
}
