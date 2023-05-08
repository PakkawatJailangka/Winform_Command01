using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
namespace _09
{
    public partial class Form1 : Form
    {
        String imglocation = "";
        //string insert = "INSERT INTO data (name,price,num,image) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "',@pic)";
        MySqlConnection con = new MySqlConnection("SERVER=localhost ;DATABASE=test003 ;UID=root; PASSWORD=;");
        string q = "Select * from data";
        DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
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



        }

        /* private void button1_Click(object sender, EventArgs e)
           {
               string querry = "SELECT * FROM data";
               MySqlCommand cmd = new MySqlCommand(querry, con);
               con.Open();
               MySqlDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   MessageBox.Show("id" + reader.GetString("Name") + ("price"));
               }
               //con.Close();    
           }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Search01_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Search01_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Search01_TextChanged(object sender, EventArgs e)
        {

        }

        private void Search01_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            DataView dv = table.DefaultView;
            dv.RowFilter = String.Format("name like '%{0}%'", Search01.Text);
            dataGridView1.DataSource = dv.ToTable();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void b_insert_Click(object sender, EventArgs e)
        {
            //แปลงรูปให้เป็น Byte อาเรย์
            /* MemoryStream stream = new MemoryStream();
             pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
             byte[] pic = stream.ToArray();
             MemoryStream st = new MemoryStream();
             pictureBox1.Image.Save(st, pictureBox1.Image.RawFormat);
             Byte[] img = st.ToArray();
             ///Qurey for call data
             string insert = "INSERT INTO data (name,price,num,image) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "',@pic)";
             MySqlCommand cm = new MySqlCommand(insert, con);
             cm.Parameters.AddWithValue("@pic", pic);
             con.Open();
             cm.ExecuteNonQuery();
             con.Close();
             MessageBox.Show("Finshed");*/
            if (pictureBox1.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();
                /* MemoryStream st = new MemoryStream();
                 pictureBox1.Image.Save(st, pictureBox1.Image.RawFormat);
                 Byte[] img = st.ToArray();*/
                string insert = "INSERT INTO data (name,price,num,image) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "',@pic)";
                MySqlCommand cm = new MySqlCommand(insert, con);
                cm.Parameters.AddWithValue("@pic", pic);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Finished");
            }
            else
            {
                string insert = "INSERT INTO data (name,price,num) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                MySqlCommand cm = new MySqlCommand(insert, con);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Finished");
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            pictureBox1.Image = null;
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Up_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imglocation = ofd.FileName.ToString();
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string del = "DELETE FROM data WHERE id='" + textBox4.Text + "'";

            MySqlCommand cmd = new MySqlCommand(del, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted");
            textBox4.Text = "";
            //string del = "DELETE FORM data WHERE id='" + textBox4.Text + "'";
            //"DELETE FROM data WHERE id='" + textBox4.Text + "'"
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand(q, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
           

            /* try
             {

                 con.Open();
                 string querry = "UPDATE data set  id=@id,name=@name,price=@price,num=@num,image = @image,datesaved = @daresaved";
                 MySqlCommand cmd = new MySqlCommand(querry,con);
                 int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                 DataGridViewRow selectedrow = dataGridView1.Rows[rowIndex];

                 cmd.Parameters.AddWithValue("@id", selectedrow.Cells["id"].Value.ToString());
                 cmd.Parameters.AddWithValue("@name", selectedrow.Cells["name"].Value.ToString());
                 cmd.Parameters.AddWithValue("@price", selectedrow.Cells["price"].Value.ToString());
                 cmd.Parameters.AddWithValue("@num", selectedrow.Cells["num"].Value.ToString());
                 cmd.Parameters.AddWithValue("@image", selectedrow.Cells["image"].Value);
                 cmd.Parameters.AddWithValue("@datesaved", selectedrow.Cells["datesaved"].Value);

                 cmd.ExecuteNonQuery ();

                 MySqlDataAdapter da = new MySqlDataAdapter(q,con);
                 da.Fill(table);
                 dataGridView1.DataSource = table;

                 con.Close();
             }
             catch (Exception ex){
                  MessageBox.Show (ex.Message);
             }
           /*  try
             {
                 con.Open();
                 MySqlDataAdapter ap = new MySqlDataAdapter(q, con);
                 ap.Fill(table);
                 dataGridView1.DataSource = table;

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally {
                 con.Close();
             }*/

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        /*   public void search(string value)
{

String q = "SELECT * FROM data CONCAT(`id`,`name`,`price`,`num`,`darasaved`) like'%'"+value+"'";
MySqlCommand c = new MySqlCommand(q, con);
MySqlDataAdapter adapter = new MySqlDataAdapter(c);
adapter.Fill(table);
dataGridView1.DataSource = table;

}*/
    }
}