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
    public partial class FrmKayit : Form
    {
        public FrmKayit()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=HASAN\SQLEXPRESS;Initial Catalog=IsikSitesi;Integrated Security=True");

        private void verilerigoster()
        {
            GetSuByAdSoyad();
        }

        public void LoadKayit()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Bloklar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbxKayit.Items.Add(oku["BlokAd"].ToString());
            }
            baglanti.Close();
        }

        private void verilerigosterAidat()
        {
            listViewAidat.Items.Clear();

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from Bloklar join Kisiler on Bloklar.Id=Kisiler.BlokId where Bloklar.BlokAd='" + cbxKayit.Text + "'", baglanti);
            SqlDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku1["id"].ToString();
                ekle1.SubItems.Add(oku1["AdSoyad"].ToString());
                ekle1.SubItems.Add(oku1["BlokId"].ToString());
                ekle1.SubItems.Add(oku1["DaireNo"].ToString());
                ekle1.SubItems.Add(oku1["Telefon"].ToString());
                ekle1.SubItems.Add(oku1["Borc"].ToString());

                listViewAidat.Items.Add(ekle1);
            }
            baglanti.Close();
        }

        private void temizle()
        {
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
        }

        private void cbxKayit_SelectedIndexChanged(object sender, EventArgs e)
        {
            verilerigosterAidat();
            temizle();
        }
        
        private void FrmKayit_Load(object sender, EventArgs e)
        {
            verilerigoster();
            LoadKayit();
        }


        int id = 0;
        private void listViewSu_DoubleClick(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();

            id = int.Parse(listViewSu.SelectedItems[0].SubItems[0].Text);
            textBox5.Text = listViewSu.SelectedItems[0].SubItems[1].Text;
            textBox6.Text = listViewSu.SelectedItems[0].SubItems[4].Text;
            textBox8.Text = listViewSu.SelectedItems[0].SubItems[5].Text;
        }

        private void listViewAidat_DoubleClick(object sender, EventArgs e)
        {
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();

            id = int.Parse(listViewAidat.SelectedItems[0].SubItems[0].Text);
            textBox12.Text = listViewAidat.SelectedItems[0].SubItems[1].Text;
            textBox11.Text = listViewAidat.SelectedItems[0].SubItems[4].Text;
            textBox10.Text = listViewAidat.SelectedItems[0].SubItems[5].Text;
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKayitGeri_Click(object sender, EventArgs e)
        {
            FrmAnaForm fr = new FrmAnaForm();

            fr.Show();
            this.Hide();
        }

        private void btnAraSu_Click(object sender, EventArgs e)
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
                ekle.SubItems.Add(oku["SuBorcu"].ToString());

                listViewSu.Items.Add(ekle);
            }
            baglanti.Close();

            txtAra.Clear();
        }

        private void btnAlSatSu_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Ad Soyad Boş Bırakılamaz!");
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("Telefon Boş Bırakılamaz!");
            }
            if (textBox8.Text == "")
            {
                textBox8.Text = "0";
            }
            double suborc = Convert.ToDouble(textBox8.Text);
            if (suborc<0)
            {
                MessageBox.Show("Borç Tutarı 0 'ın altında olamaz!");
                return;
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Su set AdSoyad='" + textBox5.Text.ToString() + "' where id=" + id + "", baglanti);
            SqlCommand komut1 = new SqlCommand("update Su set Telefon='" + textBox6.Text.ToString() + "' where id=" + id + "", baglanti);
            SqlCommand komut2 = new SqlCommand("update Su set SuBorcu='" + textBox8.Text.ToString() + "' where id=" + id + "", baglanti);            
            komut.ExecuteNonQuery();
            komut1.ExecuteNonQuery();
            komut2.ExecuteNonQuery();

            baglanti.Close();
            verilerigoster();
            }
        private void btnAlSatAidat_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                MessageBox.Show("Ad Soyad Boş Bırakılamaz!");
            }
            if (textBox11.Text == "")
            {
                MessageBox.Show("Telefon Boş Bırakılamaz!");
            }
            if (textBox10.Text == "")
            {
                textBox10.Text = "0";
            }
            double aidatborc = Convert.ToDouble(textBox10.Text);
            if (aidatborc < 0)
            {
                MessageBox.Show("Borç Tutarı 0 'ın altında olamaz!");
                return;
            }
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("update Kisiler set AdSoyad='" + textBox12.Text.ToString() + "' where id=" + id + "", baglanti);
            SqlCommand komut4 = new SqlCommand("update Kisiler set Telefon='" + textBox11.Text.ToString() + "' where id=" + id + "", baglanti);
            SqlCommand komut5 = new SqlCommand("update Kisiler set Borc='" + textBox10.Text.ToString() + "' where id=" + id + "", baglanti);
            komut3.ExecuteNonQuery();
            komut4.ExecuteNonQuery();
            komut5.ExecuteNonQuery();

            baglanti.Close();
            verilerigosterAidat();
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
        
        //Enter tuşu, aşağı ve yukarı ok tuşları işlevi (Su için)
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnAlSatSu_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnAlSatSu_Click(this, new EventArgs());
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

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnAlSatSu_Click(this, new EventArgs());
            }

            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }

        //Enter tuşu, aşağı ve yukarı ok tuşları işlevi (Aidat için)
        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnAlSatAidat_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnAlSatAidat_Click(this, new EventArgs());
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

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnAlSatAidat_Click(this, new EventArgs());
            }

            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            GetSuByAdSoyad();
        }
        private void GetSuByAdSoyad()
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
                ekle.SubItems.Add(oku["SuBorcu"].ToString());

                listViewSu.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void txtAra_MouseClick(object sender, MouseEventArgs e)
        {
            txtAra.Clear();
        }

        private void btnYAidat_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("update Kisiler set Aidat='" + textBox1.Text + "'", baglanti);
            komut6.ExecuteNonQuery();
            MessageBox.Show("Yıllık Aidat Miktarı " + textBox1.Text + " ₺ olarak güncellenmiştir.", "Güncelleme Başarıyla Tamamlandı!");
            textBox1.Clear();
            
            baglanti.Close();
        }

        private void btnSuBirim_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("update Su set BirimFiyatTon='" + textBox2.Text + "'", baglanti);
            komut7.ExecuteNonQuery();
            MessageBox.Show("Birim Su Fiyatı " + textBox2.Text + " ₺ olarak güncellenmiştir.", "Güncelleme Başarıyla Tamamlandı!");
            textBox2.Clear();

            baglanti.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnYAidat_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnSuBirim_Click(this, new EventArgs());
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

        private void btnBilgiler_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "" ) {
                MessageBox.Show("Kullanıcı Adı Boş Bırakılamaz!", "Eksik Bilgi!");
                textBox3.Focus();
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Şifre Boş Bırakılamaz!", "Eksik Bilgi!");
                textBox4.Focus();
                return;
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Kullanici set usrname='" + textBox3.Text + "'", baglanti);
            SqlCommand komut1 = new SqlCommand("update Kullanici set passwd='" + textBox4.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            komut1.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı Adı ve Şifre başarıyla değiştirilmiştir.", "Güncelleme Tamamlandı!");
            textBox1.Clear();

            baglanti.Close();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
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

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnBilgiler_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }
    }
}
