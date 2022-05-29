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
    public partial class FrmAidatIslemleri : Form
    {
        public FrmAidatIslemleri()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=HASAN\SQLEXPRESS;Initial Catalog=IsikSitesi;Integrated Security=True");

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

        private void verilerigoster()
        {
            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Bloklar join Kisiler on Bloklar.Id=Kisiler.BlokId where Bloklar.BlokAd='" + cbxBloklar.Text + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text=oku["id"].ToString();
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["BlokId"].ToString());
                ekle.SubItems.Add(oku["DaireNo"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Aidat"].ToString());
                ekle.SubItems.Add(oku["Borc"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void FrmAidatA1_Load(object sender, EventArgs e)
        {
            LoadBloks();
        }

        //id'ye çift tıklayınca bilgilerin görünmesi
        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();

            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text= listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox8.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox5.Focus();
        }

        private void temizle() 
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
        //temizle butonu
        private void aidatBtnA1Temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        //geri butonu
        private void btnGeri_Click(object sender, EventArgs e)
        {
            FrmAnaForm fr = new FrmAnaForm();

            fr.Show();
            this.Hide();
        }
        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //sadece sayısal değerlere izin ver
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsPunctuation(e.KeyChar);
        }
        //sadece harflere izin ver
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }
        //borç çıkarma-ödeme
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
            if (textBox7.Text == "0")
            {
                MessageBox.Show("Kişinin borcu bulunmamaktadır!");
                textBox5.Clear();
                textBox6.Focus();
                return;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Lütfen Kişi Seçimini Yapınız!");
                textBox5.Clear();
                return;
            }

            sayi1 = Convert.ToInt32(textBox5.Text); //Ödenen Miktar
            sayi2 = Convert.ToInt32(textBox7.Text); //Kalan Borç

            
            sonuc = sayi2 - sayi1;
            if (sonuc < 0)
            {
                MessageBox.Show("Kalan Borç 0'ın altında olamaz!");
                return;
            }
            else
            {
                textBox7.Text = sonuc.ToString(); //Kalan Borç
            }

            string detay = Convert.ToString(DateTime.Now);

            //Kalan Borcu güncelle
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Kisiler set Borc='" + textBox7.Text.ToString() + "' where id=" + id + "", baglanti);
            komut.ExecuteNonQuery();

            FrmRaporAidat frrapor = new FrmRaporAidat();

            SqlCommand komut1 = new SqlCommand("INSERT into RaporAidat(AdSoyad,Blok,DaireNo,Odenen,Kalan,Detay) Values ('"+ textBox1.Text.ToString() + "' ,'" + textBox2.Text.ToString() + "' ,'" + textBox3.Text.ToString() + "' ,'" + textBox5.Text.ToString() + "' ,'" + textBox7.Text.ToString() + "' ,'" + detay + "')", baglanti);
            komut1.ExecuteNonQuery();

            baglanti.Close();
            verilerigoster();
            textBox5.Text = "";

        }
        //borç ekleme
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
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox7.Text == "" && textBox8.Text == "")
            {
                MessageBox.Show("Lütfen Kişi Seçimini Yapınız!");
                textBox6.Clear();
                return;
            }

            sayi3 = Convert.ToInt32(textBox6.Text); //Eklenen Miktar
            sayi4 = Convert.ToInt32(textBox7.Text); //Kalan Borç

            toplam = sayi3 + sayi4;
            textBox7.Text = toplam.ToString(); //Kalan Borç

            //Kalan Borcu güncelle
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Kisiler set Borc='" + textBox7.Text.ToString() + "' where id=" + id + "", baglanti);
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
            //AŞAĞI OK TUŞUYLA ALTTAKİ TEXTBOXA (6) GEÇ
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
            //YUKARI OK TUŞUYLA YUKARDAKİ TEXTBOXA (5) GEÇ
            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }

        private void cbxBloklar_SelectedIndexChanged(object sender, EventArgs e)
        {
            verilerigoster();
            temizle();
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox7.Text == "0")
            {
                MessageBox.Show("Kişinin borcu bulunmamaktadır!");
                textBox5.Clear();
                textBox6.Focus();
                return;
            }
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            FrmRaporAidat frrapor = new FrmRaporAidat();

            frrapor.listRapor.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from RaporAidat ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["AdSoyad"].ToString();
                ekle.SubItems.Add(oku["Blok"].ToString());
                ekle.SubItems.Add(oku["DaireNo"].ToString());
                ekle.SubItems.Add(oku["Odenen"].ToString());
                ekle.SubItems.Add(oku["Kalan"].ToString());
                ekle.SubItems.Add(oku["Detay"].ToString());

                frrapor.listRapor.Items.Add(ekle);
            }
            baglanti.Close();
            
            
            frrapor.Show();
        }
    }
}
