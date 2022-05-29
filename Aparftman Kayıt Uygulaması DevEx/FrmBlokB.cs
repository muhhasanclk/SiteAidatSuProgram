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
    public partial class FrmBlokB : Form
    {
        public FrmBlokB()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=HASAN\SQLEXPRESS;Initial Catalog=IsikSitesi;Integrated Security=True");

        private void renkler()
        {
            simpleBtnBNo1.Appearance.BackColor = Color.Gray;
            simpleBtnBNo2.Appearance.BackColor = Color.Gray;
            simpleBtnBNo3.Appearance.BackColor = Color.Gray;
            simpleBtnBNo4.Appearance.BackColor = Color.Gray;
            simpleBtnBNo5.Appearance.BackColor = Color.Gray;
            simpleBtnBNo6.Appearance.BackColor = Color.Gray;
            simpleBtnBNo7.Appearance.BackColor = Color.Gray;
            simpleBtnBNo8.Appearance.BackColor = Color.Gray;
            simpleBtnBNo9.Appearance.BackColor = Color.Gray;
            simpleBtnBNo10.Appearance.BackColor = Color.Gray;
        }

        private void FrmBBlok_Load(object sender, EventArgs e)
        {
            renkler();
        }

        private void simpleBtnBNo1_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnBNo1.Appearance.BackColor = Color.AliceBlue;

            textBAdSoyad.Clear();
            textBTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokB where id=1", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBAdSoyad.Text = oku["AdSoyad"].ToString();
                textBTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnBNo2_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnBNo2.Appearance.BackColor = Color.AliceBlue;

            textBAdSoyad.Clear();
            textBTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokB where id=2", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBAdSoyad.Text = oku["AdSoyad"].ToString();
                textBTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnBNo3_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnBNo3.Appearance.BackColor = Color.AliceBlue;

            textBAdSoyad.Clear();
            textBTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokB where id=3", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBAdSoyad.Text = oku["AdSoyad"].ToString();
                textBTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnBNo4_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnBNo4.Appearance.BackColor = Color.AliceBlue;

            textBAdSoyad.Clear();
            textBTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokB where id=4", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBAdSoyad.Text = oku["AdSoyad"].ToString();
                textBTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnBNo5_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnBNo5.Appearance.BackColor = Color.AliceBlue;

            textBAdSoyad.Clear();
            textBTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokB where id=5", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBAdSoyad.Text = oku["AdSoyad"].ToString();
                textBTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnBNo6_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnBNo6.Appearance.BackColor = Color.AliceBlue;

            textBAdSoyad.Clear();
            textBTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokB where id=6", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBAdSoyad.Text = oku["AdSoyad"].ToString();
                textBTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnBNo7_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnBNo7.Appearance.BackColor = Color.AliceBlue;

            textBAdSoyad.Clear();
            textBTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokB where id=7", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBAdSoyad.Text = oku["AdSoyad"].ToString();
                textBTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnBNo8_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnBNo8.Appearance.BackColor = Color.AliceBlue;

            textBAdSoyad.Clear();
            textBTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokB where id=8", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBAdSoyad.Text = oku["AdSoyad"].ToString();
                textBTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnBNo9_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnBNo9.Appearance.BackColor = Color.AliceBlue;

            textBAdSoyad.Clear();
            textBTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokB where id=9", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBAdSoyad.Text = oku["AdSoyad"].ToString();
                textBTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnBNo10_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnBNo10.Appearance.BackColor = Color.AliceBlue;

            textBAdSoyad.Clear();
            textBTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokB where id=10", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBAdSoyad.Text = oku["AdSoyad"].ToString();
                textBTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnBGeri_Click(object sender, EventArgs e)
        {
            FrmBilgiler fr = new FrmBilgiler();

            fr.Show();
            this.Hide();
        }
    }
}
