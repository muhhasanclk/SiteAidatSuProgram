using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //SQL bağlantısı için gerekli

namespace Aparftman_Kayıt_Uygulaması_DevEx
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        //Veri tabanı ile bağlantıyı sağlayan dize 
        SqlConnection baglanti = new SqlConnection(@"Data Source=HASAN\SQLEXPRESS;Initial Catalog=IsikSitesi;Integrated Security=True");


        private void BtnGiris_Click(object sender, EventArgs e)
        {   //Veri tabanındaki kullanıcı adı ve şifre bilgilerine erişim
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Kullanici where usrname=@user AND passwd=@pass", baglanti);
            komut.Parameters.AddWithValue("@user", TxtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@pass", TxtSifre.Text);
            SqlDataReader oku = komut.ExecuteReader();

            if (oku.Read())
            {
                FrmAnaForm fr = new FrmAnaForm();

                fr.Show();
                this.Hide();
            }
            else
            {   
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!");
            }
            baglanti.Close();
            
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {   //Şifreyi göster seçeneği
            if (checkEdit1.Checked)
            {
                TxtSifre.Properties.UseSystemPasswordChar = false;
            }

            else
            {
                TxtSifre.Properties.UseSystemPasswordChar = true;
            }
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {   //Açılışta fare imlecinin otomatik olarak kullanıcı adı kısmına gelmesi
            TxtKullaniciAdi.Select();
        }


        private void FrmAdmin_KeyDown(object sender, KeyEventArgs e)
        {   //Enter ile gezinti
            if (e.KeyCode == Keys.Enter)
            {
                BtnGiris_Click(this, new EventArgs());
            }
        }

        private void TxtSifre_KeyDown(object sender, KeyEventArgs e)
        {   //Enter ile giriş 
            if (e.KeyCode == Keys.Enter)
            {
                BtnGiris_Click(this, new EventArgs());
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
