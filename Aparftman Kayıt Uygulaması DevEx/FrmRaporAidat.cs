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
using System.Collections;
using SortOrder = System.Windows.Forms.SortOrder;

namespace Aparftman_Kayıt_Uygulaması_DevEx
{
    public partial class FrmRaporAidat : Form
    {
        public FrmRaporAidat()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=HASAN\SQLEXPRESS;Initial Catalog=IsikSitesi;Integrated Security=True");

        private void kayitsayisiyaz()
        {
            int kayitsayisi = listRapor.Items.Count;
            label1.Text = Convert.ToString(kayitsayisi);
        }

        public void verilerigoster()
        {
            
            listRapor.Items.Clear();

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

                listRapor.Items.Add(ekle);
            }
            baglanti.Close();         
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int secilensayisi = listRapor.CheckedItems.Count;
            
            baglanti.Open();
            foreach (ListViewItem secilenkayitbilgisi in listRapor.CheckedItems)
            {               
                listRapor.Items.Clear();
                var name = secilenkayitbilgisi.Text;
                SqlCommand komut = new SqlCommand("DELETE from RaporAidat WHERE AdSoyad='" + name + "'", baglanti);
                komut.ExecuteNonQuery();
            }
            baglanti.Close();

            verilerigoster();
            kayitsayisiyaz();
            MessageBox.Show(secilensayisi.ToString() + " Adet Kayıt Silindi.");            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult sil = new DialogResult();
            sil = MessageBox.Show("Tüm Kayıtları Silmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo);

            if (sil == DialogResult.Yes)
            {
                listRapor.Items.Clear();

                baglanti.Open();
                SqlCommand komut = new SqlCommand("DELETE from RaporAidat", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                verilerigoster();
                
                MessageBox.Show(label1.Text + " Adet Kayıt Silindi.");
                kayitsayisiyaz();
            }
            else if (sil == DialogResult.No)
                return;            
        }

        private void FrmRaporAidat_Load(object sender, EventArgs e)
        {
            kayitsayisiyaz();
            verilerigoster();
            //listRapor_ColumnClick(this, new ColumnClickEventArgs());
        }

        private int sortColumn = -1;
        private void listRapor_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                listRapor.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (listRapor.Sorting == SortOrder.Ascending)
                    listRapor.Sorting = SortOrder.Descending;
                else
                    listRapor.Sorting = SortOrder.Ascending;
            }

            listRapor.Sort();
            this.listRapor.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              listRapor.Sorting);
        }

        class ListViewItemComparer : IComparer
        {
            private int col;
            private SortOrder order;
            public ListViewItemComparer()
            {
                col = 0;
                order = SortOrder.Ascending;
            }
            public ListViewItemComparer(int column, SortOrder order)
            {
                col = column;
                this.order = order;
            }
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                        ((ListViewItem)y).SubItems[col].Text);
                if (order == SortOrder.Descending)
                    returnVal *= -1;
                return returnVal;
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            verilerigoster();
            kayitsayisiyaz();
        }
    }
}
