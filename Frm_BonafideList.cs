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
using Firebase.Database;
using Firebase.Database.Query;
using FireBaseLib;
using AutoGenerateCertificate.pojo;
using AutoGenerateCertificate.util;

namespace AutoGenerateCertificate
{
    public partial class Frm_BonafideList : Form
    {
        public Frm_BonafideList()
        {
            InitializeComponent();
        }
        FirebaseClient fb;
        List<BonafidePojo> StudList = new List<BonafidePojo>();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {

            String strblock = "BlockBonafideCert";

            var fb = FireBaseDB.init(FBConfig.url);
            var task = fb.Child(strblock).OnceAsync<BlockBonafide>();
            task.Wait();
            var fbdata = task.Result;
            List<BonafideAdaptor> bflist = new List<BonafideAdaptor>();
            int f = 0;
            int c = 1;
            foreach (var data in fbdata)
            {
                BonafideAdaptor bf = new BonafideAdaptor();
                BonafidePojo bonafidePojo = new BonafidePojo();
                bf.Hash = data.Object.Hash;
                bf.Prevhash = data.Object.Prevhash;
                bf.Timestamp = data.Object.Timestamp;
                bf.Iscurrupted = data.Object.Iscurrupted;
                bf.Name=data.Object.BonafidePojo.Name;
                bf.Date = data.Object.BonafidePojo.Date;
                bf.Academic_year = data.Object.BonafidePojo.Academic_year;
                bf.Branch = data.Object.BonafidePojo.Branch;
                bf.Reason = data.Object.BonafidePojo.Reason;
                bonafidePojo = data.Object.BonafidePojo;

                BlockBonafide block = new util.BlockBonafide(bf.Hash, bf.Timestamp, bonafidePojo);
                if(block.Hash==bf.Hash)
                {
                    bf.Iscurrupted = "true";
                }
                else
                {
                    bf.Iscurrupted = "false";
                }
                bflist.Add(bf);
                f = 1;

            }
            dataGridView1.DataSource = bflist;


        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {

        }
        /*
private void button_WOC2_Click(object sender, EventArgs e)
{
   loadData();
}

public async void loadData()
{
   var firebase = new FirebaseClient(FBConfig.url);
   try
   {
       firebase.Child("BonafidePojo");
       // string dt = dateTimePicker1.Text;
       var fbdata = await firebase.Child("BonafidePojo").Child(comboBox1.Text).OnceAsync<BonafidePojo>();
       List<BonafidePojo> AddPojos = new List<BonafidePojo>();
       foreach (var data in fbdata)
       {
           BonafidePojo bfp = new BonafidePojo();
           bfp.Name = data.Object.Name;
           bfp.Academic_year = data.Object.Academic_year;
           //bfp.Present = "Verified";
           //Rg.Date = data.Object.Date;
           if (comboBox1.Text == bfp.Branch)
           {
               AddPojos.Add(bfp);

               dataGridView1.DataSource = AddPojos;
           }
           else {
               MessageBox.Show("No such Data");
           }

       }
   } catch (Exception ex)
   {
       MessageBox.Show("Error:" + ex);
   }
}
*/

    }
}
