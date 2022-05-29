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
    public partial class FrmBlokC : Form
    {
        public FrmBlokC()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=HASAN\SQLEXPRESS;Initial Catalog=IsikSitesi;Integrated Security=True");

        private void renkler()
        {
            simpleBtnCNo1.Appearance.BackColor = Color.Gray;
            simpleBtnCNo2.Appearance.BackColor = Color.Gray;
            simpleBtnCNo3.Appearance.BackColor = Color.Gray;
            simpleBtnCNo4.Appearance.BackColor = Color.Gray;
            simpleBtnCNo5.Appearance.BackColor = Color.Gray;
            simpleBtnCNo6.Appearance.BackColor = Color.Gray;
            simpleBtnCNo7.Appearance.BackColor = Color.Gray;
            simpleBtnCNo8.Appearance.BackColor = Color.Gray;
            simpleBtnCNo9.Appearance.BackColor = Color.Gray;
            simpleBtnCNo10.Appearance.BackColor = Color.Gray;
        }

        private void FrmCBlok_Load(object sender, EventArgs e)
        {
            renkler();
        }

        private void simpleBtnCNo1_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnCNo1.Appearance.BackColor = Color.AliceBlue;

            textCAdSoyad.Clear();
            textCTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokC where id=1", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textCAdSoyad.Text = oku["AdSoyad"].ToString();
                textCTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnCNo2_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnCNo2.Appearance.BackColor = Color.AliceBlue;

            textCAdSoyad.Clear();
            textCTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokC where id=2", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textCAdSoyad.Text = oku["AdSoyad"].ToString();
                textCTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnCNo3_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnCNo3.Appearance.BackColor = Color.AliceBlue;

            textCAdSoyad.Clear();
            textCTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokC where id=3", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textCAdSoyad.Text = oku["AdSoyad"].ToString();
                textCTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnCNo4_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnCNo4.Appearance.BackColor = Color.AliceBlue;

            textCAdSoyad.Clear();
            textCTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokC where id=4", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textCAdSoyad.Text = oku["AdSoyad"].ToString();
                textCTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnCNo5_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnCNo5.Appearance.BackColor = Color.AliceBlue;

            textCAdSoyad.Clear();
            textCTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokC where id=5", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textCAdSoyad.Text = oku["AdSoyad"].ToString();
                textCTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnCNo6_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnCNo6.Appearance.BackColor = Color.AliceBlue;

            textCAdSoyad.Clear();
            textCTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokC where id=6", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textCAdSoyad.Text = oku["AdSoyad"].ToString();
                textCTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnCNo7_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnCNo7.Appearance.BackColor = Color.AliceBlue;

            textCAdSoyad.Clear();
            textCTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokC where id=7", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textCAdSoyad.Text = oku["AdSoyad"].ToString();
                textCTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnCNo8_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnCNo8.Appearance.BackColor = Color.AliceBlue;

            textCAdSoyad.Clear();
            textCTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokC where id=8", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textCAdSoyad.Text = oku["AdSoyad"].ToString();
                textCTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnCNo9_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnCNo9.Appearance.BackColor = Color.AliceBlue;

            textCAdSoyad.Clear();
            textCTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokC where id=9", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textCAdSoyad.Text = oku["AdSoyad"].ToString();
                textCTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnCNo10_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnCNo10.Appearance.BackColor = Color.AliceBlue;

            textCAdSoyad.Clear();
            textCTelefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokC where id=10", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textCAdSoyad.Text = oku["AdSoyad"].ToString();
                textCTelefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnCGeri_Click(object sender, EventArgs e)
        {
            FrmBilgiler fr = new FrmBilgiler();

            fr.Show();
            this.Hide();
        }
    }
}
