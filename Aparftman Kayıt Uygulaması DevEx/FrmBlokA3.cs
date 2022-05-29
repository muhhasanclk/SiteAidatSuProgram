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
    public partial class FrmBlokA3 : Form
    {
        public FrmBlokA3()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=HASAN\SQLEXPRESS;Initial Catalog=IsikSitesi;Integrated Security=True");

        private void renkler()
        {
            simpleBtnA3No1.Appearance.BackColor = Color.Gray;
            simpleBtnA3No2.Appearance.BackColor = Color.Gray;
            simpleBtnA3No3.Appearance.BackColor = Color.Gray;
            simpleBtnA3No4.Appearance.BackColor = Color.Gray;
            simpleBtnA3No5.Appearance.BackColor = Color.Gray;
            simpleBtnA3No6.Appearance.BackColor = Color.Gray;
            simpleBtnA3No7.Appearance.BackColor = Color.Gray;
            simpleBtnA3No8.Appearance.BackColor = Color.Gray;
            simpleBtnA3No9.Appearance.BackColor = Color.Gray;
            simpleBtnA3No10.Appearance.BackColor = Color.Gray;
        }

        private void FrmA3Blok_Load(object sender, EventArgs e)
        {
            renkler();
        }

        private void simpleBtnA3No1_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA3No1.Appearance.BackColor = Color.AliceBlue;

            textA3AdSoyad.Clear();
            textA3Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA3 where id=1", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA3AdSoyad.Text = oku["AdSoyad"].ToString();
                textA3Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA3No2_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA3No2.Appearance.BackColor = Color.AliceBlue;

            textA3AdSoyad.Clear();
            textA3Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA3 where id=2", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA3AdSoyad.Text = oku["AdSoyad"].ToString();
                textA3Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA3No3_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA3No3.Appearance.BackColor = Color.AliceBlue;

            textA3AdSoyad.Clear();
            textA3Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA3 where id=3", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA3AdSoyad.Text = oku["AdSoyad"].ToString();
                textA3Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA3No4_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA3No4.Appearance.BackColor = Color.AliceBlue;

            textA3AdSoyad.Clear();
            textA3Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA3 where id=4", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA3AdSoyad.Text = oku["AdSoyad"].ToString();
                textA3Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA3No5_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA3No5.Appearance.BackColor = Color.AliceBlue;

            textA3AdSoyad.Clear();
            textA3Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA3 where id=5", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA3AdSoyad.Text = oku["AdSoyad"].ToString();
                textA3Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA3No6_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA3No6.Appearance.BackColor = Color.AliceBlue;

            textA3AdSoyad.Clear();
            textA3Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA3 where id=6", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA3AdSoyad.Text = oku["AdSoyad"].ToString();
                textA3Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA3No7_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA3No7.Appearance.BackColor = Color.AliceBlue;

            textA3AdSoyad.Clear();
            textA3Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA3 where id=7", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA3AdSoyad.Text = oku["AdSoyad"].ToString();
                textA3Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA3No8_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA3No8.Appearance.BackColor = Color.AliceBlue;

            textA3AdSoyad.Clear();
            textA3Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA3 where id=8", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA3AdSoyad.Text = oku["AdSoyad"].ToString();
                textA3Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA3No9_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA3No9.Appearance.BackColor = Color.AliceBlue;

            textA3AdSoyad.Clear();
            textA3Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA3 where id=9", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA3AdSoyad.Text = oku["AdSoyad"].ToString();
                textA3Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA3No10_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA3No10.Appearance.BackColor = Color.AliceBlue;

            textA3AdSoyad.Clear();
            textA3Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA3 where id=10", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA3AdSoyad.Text = oku["AdSoyad"].ToString();
                textA3Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA3Geri_Click(object sender, EventArgs e)
        {
            FrmBilgiler fr = new FrmBilgiler();

            fr.Show();
            this.Hide();
        }
    }
}
