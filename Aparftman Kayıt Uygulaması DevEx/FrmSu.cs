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
    public partial class FrmSu : Form
    {
        public FrmSu()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=HASAN\SQLEXPRESS;Initial Catalog=IsikSitesi;Integrated Security=True");

        private void verilerigoster()
        {
            Arama();
        }

        private void FrmSu_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }

        int id = 0;
        private void listViewSu_DoubleClick(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();

            id = int.Parse(listViewSu.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listViewSu.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listViewSu.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listViewSu.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listViewSu.SelectedItems[0].SubItems[4].Text;
            textBox10.Text = listViewSu.SelectedItems[0].SubItems[6].Text;
            textBox9.Text = "";
            textBox8.Text = listViewSu.SelectedItems[0].SubItems[7].Text;
            textBox11.Text = listViewSu.SelectedItems[0].SubItems[8].Text;
            textBox12.Text = listViewSu.SelectedItems[0].SubItems[9].Text;
            textBox7.Text = listViewSu.SelectedItems[0].SubItems[10].Text;
            label1.Text=listViewSu.SelectedItems[0].SubItems[5].Text;
            label2.Text=listViewSu.SelectedItems[0].SubItems[6].Text;

            textBox9.Focus();
        }

        private void btnSuTemizle_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void btnSuGeri_Click(object sender, EventArgs e)
        {
            FrmAnaForm fr = new FrmAnaForm();

            fr.Show();
            this.Hide();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            Arama();
        }

        private void Arama() 
        {
            listViewSu.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Su where AdSoyad like '%" + txtAra.Text + "%' ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["Blok"].ToString());
                ekle.SubItems.Add(oku["DaireNo"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["İlkEndeks"].ToString());
                ekle.SubItems.Add(oku["SonEndeks"].ToString());
                ekle.SubItems.Add(oku["BirimFiyatTon"].ToString());
                ekle.SubItems.Add(oku["Kullanilan"].ToString());
                ekle.SubItems.Add(oku["KullanimTutari"].ToString());
                ekle.SubItems.Add(oku["SuBorcu"].ToString());

                listViewSu.Items.Add(ekle);
            }
            baglanti.Close();
        }

        
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            /*
             * textBox10 İlk Endeks
             * textBox9 Son Endeks
             * textBox11 Kullanılan
             * textBox8 Birim Fiyat
             * textBox12 Kullanım Tutarı
            */
            
            if (textBox1.Text == ""  || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Lütfen Kişi Seçimini Yapınız!");
                textBox9.Clear();
                textBox10.Clear();
                return;
            }
            if (textBox9.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Lütfen bütün Endeks değerlerini giriniz!");
                textBox9.Focus();
                return;
            }

            double ilkEndeks, sonEndeks, kullanilan, birimFiyat, kTutari, kBorc;

            ilkEndeks = Convert.ToDouble(textBox10.Text); 
            sonEndeks = Convert.ToDouble(textBox9.Text);

            if (ilkEndeks < 0 || sonEndeks < 0)
            {
                MessageBox.Show("Endeks değerleri 0'ın altında olamaz!");
                return;
            }
            
            double listIlk = Convert.ToDouble(label1.Text);
            double listSon = Convert.ToDouble(label2.Text);

            if (ilkEndeks < listSon)
            {
                MessageBox.Show("Endeks değerleri geçmiş değerlerden küçük olamaz!");
                textBox10.Text = label2.Text;
                textBox10.Focus();
                textBox9.Clear();
                return;
            }
            if (ilkEndeks == listIlk)
            {
                MessageBox.Show("Endeks değerleri geçmiş değerler ile eşit olamaz!");
                textBox10.Text = label2.Text;
                textBox10.Focus();
                textBox9.Clear();
                return;
            }

            if (sonEndeks < ilkEndeks)
            {
                MessageBox.Show("Son Endeks İlk Endeksten küçük olamaz!");
                textBox9.Clear();
                textBox9.Focus();
                return;
            }
            else if (sonEndeks==ilkEndeks)
            {
                MessageBox.Show("Endekslerin eşit olduğu durumda herhangi bir su kullanımı söz konusu değildir, hesaplama gereği olmaz.", "HATIRLATMA");
                return;
            }

            else
            {
                kullanilan = sonEndeks - ilkEndeks;
                textBox11.Text = kullanilan.ToString();

                kullanilan = Convert.ToDouble(textBox11.Text); birimFiyat = Convert.ToDouble(textBox8.Text);

                kTutari = kullanilan * birimFiyat;
                textBox12.Text = kTutari.ToString();

                kTutari = Convert.ToDouble(textBox12.Text);

                if (textBox7.Text == "")
                {
                    textBox7.Text = "0";
                }
                
                kBorc = Convert.ToDouble(textBox7.Text);
                kBorc = kBorc + kTutari;
                
                textBox7.Text = kBorc.ToString();
            }

            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Su set Kullanilan='" + textBox11.Text.ToString() + "' where id=" + id + "", baglanti);
            SqlCommand komut1 = new SqlCommand("update Su set KullanimTutari='" + textBox12.Text.ToString() + "' where id=" + id + "", baglanti);
            SqlCommand komut2 = new SqlCommand("update Su set SuBorcu='" + textBox7.Text.ToString() + "' where id=" + id + "", baglanti);
            SqlCommand komut3 = new SqlCommand("update Su set İlkEndeks='" + textBox10.Text.ToString() + "' where id=" + id + "", baglanti);
            SqlCommand komut4 = new SqlCommand("update Su set SonEndeks='" + textBox9.Text.ToString() + "' where id=" + id + "", baglanti);
            komut.ExecuteNonQuery();
            komut1.ExecuteNonQuery();
            komut2.ExecuteNonQuery();
            komut3.ExecuteNonQuery();
            komut4.ExecuteNonQuery();

            baglanti.Close();
            label1.Text = textBox10.Text;
            label2.Text = textBox9.Text;
            textBox10.Text = textBox9.Text;
            textBox9.Clear();
            verilerigoster();
        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            double sayi1;
            double sayi2;
            double sonuc;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Lütfen Kişi Seçimini Yapınız!");
                textBox5.Clear();
                return;
            }
            if (textBox7.Text == "" || textBox7.Text == "0")
            {
                MessageBox.Show("Borç Bulunmamaktadır!");
            }

            else
            {
                sayi1 = Convert.ToDouble(textBox5.Text); //Ödenen Miktar
                sayi2 = Convert.ToDouble(textBox7.Text); //Borç
                if (sayi1 < 0)
                {
                    MessageBox.Show("Miktar Negatif Olamaz!");
                    return;
                }
                sonuc = sayi2 - sayi1;
                if (sonuc<0)
                {
                    MessageBox.Show("Borç Tutarı 0'ın altında olamaz!");
                    return;
                }
                textBox7.Text = sonuc.ToString(); //Toplam Borç
            }
            
            //Kalan Borcu güncelle
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Su set SuBorcu='" + textBox7.Text.ToString() + "' where id=" + id + "", baglanti);
            komut.ExecuteNonQuery();

            string detay = Convert.ToString(DateTime.Now);
            FrmRaporAidat frrapor = new FrmRaporAidat();

            SqlCommand komut1 = new SqlCommand("INSERT into RaporSu(AdSoyad,Blok,DaireNo,Odenen,Kalan,Detay) Values ('" + textBox1.Text.ToString() + "' ,'" + textBox2.Text.ToString() + "' ,'" + textBox3.Text.ToString() + "' ,'" + textBox5.Text.ToString() + "' ,'" + textBox7.Text.ToString() + "' ,'" + detay + "')", baglanti);
            komut1.ExecuteNonQuery();

            baglanti.Close();
            verilerigoster();

            textBox5.Text = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Lütfen Kişi Seçimini Yapınız!");
                textBox6.Clear();
                return;
            }

            double sayi3;
            double sayi4;
            double toplam;

            if (textBox7.Text == "")
            {
                textBox7.Text = "0";
            }

            sayi3 = Convert.ToDouble(textBox6.Text); //Eklenen Miktar
            sayi4 = Convert.ToDouble(textBox7.Text); //Borç
            if (sayi3 < 0)
            {
                MessageBox.Show("Miktar Negatif Olamaz!");
                return;
            }
            toplam = sayi3 + sayi4;
            textBox7.Text = toplam.ToString(); //Toplam Borç

            //Kalan Borcu güncelle
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Su set SuBorcu='" + textBox7.Text.ToString() + "' where id=" + id + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigoster();

            textBox6.Text = "";
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnHesapla_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");  
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; 
                e.SuppressKeyPress = true;
                btnHesapla_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");  
            }
            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }

        private void asagiYukari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }

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
            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnEkle_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }

        private void txtAra_MouseClick(object sender, MouseEventArgs e)
        {
            txtAra.Clear();
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            FrmRaporSu frrapor = new FrmRaporSu();

            frrapor.listRapor.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from RaporSu ", baglanti);
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

        //sadece sayısal değerlere izin ver
        public void sayisal(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsPunctuation(e.KeyChar);
        }

        //sadece harflere izin ver
        public void harf(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }
    }
}
