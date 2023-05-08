using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Http;
using System.Diagnostics;


namespace _14
{
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection("SERVER=localhost ;DATABASE=t001 ;UID=root; PASSWORD=;");
        string q = "Select * from p001";
        DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            //string q = "Select * from data";
            MySqlCommand md = new MySqlCommand(q, con);
            MySqlDataReader reader = md.ExecuteReader();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();
            //คำสั่งใช้งาน js background
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();//Function worker
            //webBrowser1.Navigate("C:\\Users\\ASUS\\Desktop\\JSON\\scc.js", null);
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "node";
            process.StartInfo.Arguments = "C:\\Users\\ASUS\\Desktop\\JSON\\scc.js";//local file script 
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();
            process.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = table.DefaultView;
            dv.RowFilter = String.Format("name like '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dv.ToTable();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted_2(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            

        }

        private void Upadate_Click(object sender, EventArgs e)
        {
         /*   BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();//Function worker*/


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand(q, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds) ;
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }



    }
}
