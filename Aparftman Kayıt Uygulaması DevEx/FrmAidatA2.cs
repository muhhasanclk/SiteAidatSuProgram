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
    public partial class FrmAidatA2 : Form
    {
        public FrmAidatA2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=HASAN\SQLEXPRESS;Initial Catalog=IsikSitesi;Integrated Security=True");

        private void verilerigoster()
        {
            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from BlokA2", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["Blok"].ToString());
                ekle.SubItems.Add(oku["DaireNo"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Aidat"].ToString());
                ekle.SubItems.Add(oku["Borc"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void aidatBtnA1VG_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void FrmAidatA2_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }

        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();

            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox8.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox5.Focus();
        }

        private void aidatBtnA2Temizle_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FrmBloklarAidat fr = new FrmBloklarAidat();

            fr.Show();
            this.Hide();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            double sayi1;
            double sayi2;
            double sonuc;

            // Henuz hic borc odenmemisse yani kalan borc kismi bossa, kalan borcu yillik aidattan cek 
            if (textBox7.Text == "")
            {
                textBox7.Text = textBox8.Text;
            }

            sayi1 = Convert.ToInt32(textBox5.Text); //Ödenen Miktar
            sayi2 = Convert.ToInt32(textBox7.Text); //Kalan Borç

            sonuc = sayi2 - sayi1;
            textBox7.Text = sonuc.ToString(); //Kalan Borç

            //Kalan Borcu güncelle
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update BlokA2 set Borc='" + textBox7.Text.ToString() + "' where id=" + id + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigoster();

            textBox5.Text = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            double sayi3;
            double sayi4;
            double toplam;

            // Henuz hic borc eklenmemisse yani kalan borc kismi bossa, kalan borcu yillik aidattan cek 
            if (textBox7.Text == "")
            {
                textBox7.Text = textBox8.Text;
            }
            
            sayi3 = Convert.ToInt32(textBox6.Text); //Eklenen Miktar
            sayi4 = Convert.ToInt32(textBox7.Text); //Kalan Borç

            toplam = sayi3 + sayi4;
            textBox7.Text = toplam.ToString(); //Kalan Borç

            //Kalan Borcu güncelle
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update BlokA2 set Borc='" + textBox7.Text.ToString() + "' where id=" + id + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigoster();

            textBox6.Text = "";
        }
        
        // Odenen miktar yazildiktan sonra Enter'a basildiginda otomatik Borc Cikar butonuna basar. 
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnCikar_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
        }

        // Eklenen miktar yazildiktan sonra Enter'a basildiginda otomatik Borc Ekle butonuna basar. 
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnEkle_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }
    }
}
