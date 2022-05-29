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

namespace Aparftman_Kayıt_Uygulaması_DevEx
{
    public partial class FrmBlokA1 : Form
    {
        public FrmBlokA1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=HASAN\SQLEXPRESS;Initial Catalog=IsikSitesi;Integrated Security=True");

        private void renkler()
        {   // Buton arka plan rengi 
            simpleBtnA1No1.Appearance.BackColor = Color.Gray;
            simpleBtnA1No2.Appearance.BackColor = Color.Gray;
            simpleBtnA1No3.Appearance.BackColor = Color.Gray;
            simpleBtnA1No4.Appearance.BackColor = Color.Gray;
            simpleBtnA1No5.Appearance.BackColor = Color.Gray;
            simpleBtnA1No6.Appearance.BackColor = Color.Gray;
            simpleBtnA1No7.Appearance.BackColor = Color.Gray;
            simpleBtnA1No8.Appearance.BackColor = Color.Gray;
            simpleBtnA1No9.Appearance.BackColor = Color.Gray;
            simpleBtnA1No10.Appearance.BackColor = Color.Gray;
        }

        private void FrmA1Blok_Load(object sender, EventArgs e)
        {
            renkler();
        }

        private void simpleBtnA1No1_Click(object sender, EventArgs e)
        {
            renkler();
            // Butona tıklandığında görünecek olan arka plan rengi
            simpleBtnA1No1.Appearance.BackColor = Color.AliceBlue;

            //id'ye göre bilgiler çekilecek
            textA1AdSoyad.Clear();
            textA1Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA1 where id=1", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read()) 
            {
                textA1AdSoyad.Text = oku["AdSoyad"].ToString();
                textA1Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA1No2_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA1No2.Appearance.BackColor = Color.AliceBlue;

            textA1AdSoyad.Clear();
            textA1Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA1 where id=2", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA1AdSoyad.Text = oku["AdSoyad"].ToString();
                textA1Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA1No3_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA1No3.Appearance.BackColor = Color.AliceBlue;

            textA1AdSoyad.Clear();
            textA1Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Kisiler.AdSoyad as AdSoyad, Kisiler.Telefon as Telefon from Kisiler where BlokId=1", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA1AdSoyad.Text = oku["AdSoyad"].ToString();
                textA1Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA1No4_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA1No4.Appearance.BackColor = Color.AliceBlue;

            textA1AdSoyad.Clear();
            textA1Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA1 where id=4", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA1AdSoyad.Text = oku["AdSoyad"].ToString();
                textA1Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA1No5_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA1No5.Appearance.BackColor = Color.AliceBlue;

            textA1AdSoyad.Clear();
            textA1Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA1 where id=5", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA1AdSoyad.Text = oku["AdSoyad"].ToString();
                textA1Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA1No6_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA1No6.Appearance.BackColor = Color.AliceBlue;

            textA1AdSoyad.Clear();
            textA1Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA1 where id=6", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA1AdSoyad.Text = oku["AdSoyad"].ToString();
                textA1Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA1No7_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA1No7.Appearance.BackColor = Color.AliceBlue;

            textA1AdSoyad.Clear();
            textA1Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA1 where id=7", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA1AdSoyad.Text = oku["AdSoyad"].ToString();
                textA1Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA1No8_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA1No8.Appearance.BackColor = Color.AliceBlue;

            textA1AdSoyad.Clear();
            textA1Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA1 where id=8", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA1AdSoyad.Text = oku["AdSoyad"].ToString();
                textA1Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA1No9_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA1No9.Appearance.BackColor = Color.AliceBlue;

            textA1AdSoyad.Clear();
            textA1Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA1 where id=9", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA1AdSoyad.Text = oku["AdSoyad"].ToString();
                textA1Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA1No10_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA1No10.Appearance.BackColor = Color.AliceBlue;

            textA1AdSoyad.Clear();
            textA1Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA1 where id=10", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA1AdSoyad.Text = oku["AdSoyad"].ToString();
                textA1Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA1Geri_Click(object sender, EventArgs e)
        {
            FrmBilgiler fr = new FrmBilgiler();

            fr.Show();
            this.Hide();
        }
    }
}
