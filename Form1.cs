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
using System.Security.Cryptography;

namespace PersonelKayitProgramiSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti= new SqlConnection("Data Source=DESKTOP-7EPCTQ4;Initial Catalog=PersonelVeriTabaniSql;User ID=DESKTOP-7EPCTQ4;Password=Mk34001900;Integrated Security=True");
        void temizle()
        {
            txtad.Text = "";
            txtsoyad.Text = "";
            txtid.Text = "";
            txtmeslek.Text = "";
            mskmaas.Text = "";
            cmbsehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtad.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniSqlDataSet.PersonelBilgileri' table. You can move, or remove it, as needed.
            this.personelBilgileriTableAdapter.Fill(this.personelVeriTabaniSqlDataSet.PersonelBilgileri);
            label8.Visible = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.personelBilgileriTableAdapter.Fill(this.personelVeriTabaniSqlDataSet.PersonelBilgileri);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut=new SqlCommand("insert into PersonelBilgileri (PersonelAd,PersonelSoyad,PerSehir,PerMaas,PerMeslek) values (@p1,@p2,@p3,@p4,@p5) ", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", mskmaas.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel başarıyla eklendi");
        }
        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            txtad.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            label8.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
           
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True") 
            {
                radioButton1.Checked=true;
            }
            if(label8.Text == "False")
            {
                radioButton2.Checked=true;
            }

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) 
            {
                label8.Text = "False";
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From PersonelBilgileri Where Personelid=@p1",baglanti);
            sil.Parameters.AddWithValue("@p1", txtid.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıdınız silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update PersonelBilgileri Set PersonelAd=@p1,PersonelSoyad=@p2,PerSehir=@p3,PerMaas=@p4,PerDurum=@p5,PerMeslek=@p6 where Personelid=@p7", baglanti);
            guncelle.Parameters.AddWithValue("p1", txtad.Text);
            guncelle.Parameters.AddWithValue("p2", txtsoyad.Text);
            guncelle.Parameters.AddWithValue("p3", cmbsehir.Text);
            guncelle.Parameters.AddWithValue("p4", mskmaas.Text);
            guncelle.Parameters.AddWithValue("p5", label8.Text);
            guncelle.Parameters.AddWithValue("p6", txtmeslek.Text);
            guncelle.Parameters.AddWithValue("p7", txtid.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgileri Güncellendi");

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
