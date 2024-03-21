using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace ArabaKiralama
{
    public partial class Form1 : Form
    {


        SqlConnection con = new SqlConnection("server= DESKTOP-OOMAMHS\\SQLEXPRESS; initial catalog = otomotiv; integrated security =sspi");
        SqlCommand cmd;
        SqlDataAdapter da;
        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text=" ";
            pictureBox1.ImageLocation = "";

        }
        
        void listele()
        {
            da=new SqlDataAdapter("select * from araclar",con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource=tablo;
            temizle();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("insert into araclar (plaka, marka, model, uretimYili, km, renk, yakitTuru, kiraUcreti, durum, resim  ) values ('"+textBox1.Text + "' , '"+textBox2 .Text +"' , '"+textBox3.Text +"' ,'"+ int.Parse(textBox4.Text) +"' , '"+int.Parse (textBox5.Text) +"' , '"+textBox6.Text +"','"+textBox7.Text +"','"+int.Parse (textBox8.Text )+"' , '"+ comboBox1.Text + "' , '"+pictureBox1.Location +"' ) ", con);
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Başarılı Kayıt. ");
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofl  = new OpenFileDialog();
            ofl.Filter = "Resim Dosyası |*.jpg; *.png | Butun Dosyalar|*.*";
            ofl.ShowDialog();
            pictureBox1.ImageLocation = ofl.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("UPDATE  araclar set plaka='" + textBox1.Text + "', marka =' " + textBox2.Text + "',model='" + textBox3.Text + "',uretimYili='" + int.Parse(textBox4.Text) + "', km='" + int.Parse(textBox5.Text) + "',renk='" + textBox6.Text + "',yakitTuru='" + textBox7.Text + "',kiraUcreti='" + int.Parse(textBox8.Text) + "',durum='" + comboBox1.Text + "',resim='" + pictureBox1.Location + "'where id = '" +int.Parse( dataGridView1.CurrentRow.Cells[0].Value.ToString() ) +"'   ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();         
            MessageBox.Show("Başarılı Kayıt. ");
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[0].Value.ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("DELETE FROM  araclar where id = '" + int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'   ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Silindi . ");
            listele();
        }
    }

}
        