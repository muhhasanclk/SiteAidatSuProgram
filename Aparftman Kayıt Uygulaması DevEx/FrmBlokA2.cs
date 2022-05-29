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
    public partial class FrmBlokA2 : Form
    {
        public FrmBlokA2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=HASAN\SQLEXPRESS;Initial Catalog=IsikSitesi;Integrated Security=True");

        private void renkler()
        {   
            simpleBtnA2No1.Appearance.BackColor = Color.Gray;
            simpleBtnA2No2.Appearance.BackColor = Color.Gray;
            simpleBtnA2No3.Appearance.BackColor = Color.Gray;
            simpleBtnA2No4.Appearance.BackColor = Color.Gray;
            simpleBtnA2No5.Appearance.BackColor = Color.Gray;
            simpleBtnA2No6.Appearance.BackColor = Color.Gray;
            simpleBtnA2No7.Appearance.BackColor = Color.Gray;
            simpleBtnA2No8.Appearance.BackColor = Color.Gray;
            simpleBtnA2No9.Appearance.BackColor = Color.Gray;
            simpleBtnA2No10.Appearance.BackColor = Color.Gray;
        }

        private void FrmA2Blok_Load(object sender, EventArgs e)
        {
            renkler();
        }

        private void simpleBtnA2No1_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA2No1.Appearance.BackColor = Color.AliceBlue;

            textA2AdSoyad.Clear();
            textA2Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA2 where id=1", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA2AdSoyad.Text = oku["AdSoyad"].ToString();
                textA2Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA2No2_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA2No2.Appearance.BackColor = Color.AliceBlue;

            textA2AdSoyad.Clear();
            textA2Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA2 where id=2", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA2AdSoyad.Text = oku["AdSoyad"].ToString();
                textA2Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA2No3_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA2No3.Appearance.BackColor = Color.AliceBlue;

            textA2AdSoyad.Clear();
            textA2Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA2 where id=3", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA2AdSoyad.Text = oku["AdSoyad"].ToString();
                textA2Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA2No4_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA2No4.Appearance.BackColor = Color.AliceBlue;

            textA2AdSoyad.Clear();
            textA2Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA2 where id=4", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA2AdSoyad.Text = oku["AdSoyad"].ToString();
                textA2Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA2No5_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA2No5.Appearance.BackColor = Color.AliceBlue;

            textA2AdSoyad.Clear();
            textA2Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA2 where id=5", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA2AdSoyad.Text = oku["AdSoyad"].ToString();
                textA2Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA2No6_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA2No6.Appearance.BackColor = Color.AliceBlue;

            textA2AdSoyad.Clear();
            textA2Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA2 where id=6", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA2AdSoyad.Text = oku["AdSoyad"].ToString();
                textA2Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA2No7_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA2No7.Appearance.BackColor = Color.AliceBlue;

            textA2AdSoyad.Clear();
            textA2Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA2 where id=7", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA2AdSoyad.Text = oku["AdSoyad"].ToString();
                textA2Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA2No8_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA2No8.Appearance.BackColor = Color.AliceBlue;

            textA2AdSoyad.Clear();
            textA2Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA2 where id=8", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA2AdSoyad.Text = oku["AdSoyad"].ToString();
                textA2Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA2No9_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA2No9.Appearance.BackColor = Color.AliceBlue;

            textA2AdSoyad.Clear();
            textA2Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA2 where id=9", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA2AdSoyad.Text = oku["AdSoyad"].ToString();
                textA2Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA2No10_Click(object sender, EventArgs e)
        {
            renkler();
            simpleBtnA2No10.Appearance.BackColor = Color.AliceBlue;

            textA2AdSoyad.Clear();
            textA2Telefon.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA2 where id=10", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textA2AdSoyad.Text = oku["AdSoyad"].ToString();
                textA2Telefon.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void simpleBtnA2Geri_Click(object sender, EventArgs e)
        {
            FrmBilgiler fr = new FrmBilgiler();

            fr.Show();
            this.Hide();
        }
    }
}
