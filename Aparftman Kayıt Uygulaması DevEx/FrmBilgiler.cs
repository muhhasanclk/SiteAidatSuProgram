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
    public partial class FrmBilgiler : Form
    {
        public FrmBilgiler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=HASAN\SQLEXPRESS;Initial Catalog=IsikSitesi;Integrated Security=True");

        private void FrmBilgiler_Load(object sender, EventArgs e)
        {
            LoadBloks();
        }
        public void LoadBloks()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Bloklar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbxBloklar.Items.Add(oku["BlokAd"].ToString());
            }
            baglanti.Close();
        }

        public void GetDaireNoByBlokId()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Bloklar join Kisiler on Bloklar.Id=Kisiler.BlokId where Bloklar.BlokAd='" + cbxBloklar.Text + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku["DaireNo"].ToString());
            }
            baglanti.Close();

        }

        private void cbxBloklar_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            GetDaireNoByBlokId();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetKisiByDaireNo();
        }

        private void GetKisiByDaireNo()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Bloklar join Kisiler on Bloklar.Id=Kisiler.BlokId where " +
                "Bloklar.BlokAd='" + cbxBloklar.Text + "' and Kisiler.DaireNo=" + comboBox2.Text, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox1.Text = oku["AdSoyad"].ToString();
                textBox2.Text = oku["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            FrmAnaForm fr = new FrmAnaForm();

            fr.Show();
            this.Hide();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
