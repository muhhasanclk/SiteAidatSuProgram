using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aparftman_Kayıt_Uygulaması_DevEx
{
    public partial class FrmBloklarAidat : Form
    {
        public FrmBloklarAidat()
        {
            InitializeComponent();
        }

        private void BtnGeriAidat_Click(object sender, EventArgs e)
        {
            FrmAnaForm fr = new FrmAnaForm();

            fr.Show();
            this.Hide();
        }

        private void BtnA1Aidat_Click(object sender, EventArgs e)
        {
            FrmAidatIslemleri fr = new FrmAidatIslemleri();

            fr.Show();
            this.Hide();
        }

        private void BtnA2Aidat_Click(object sender, EventArgs e)
        {
            FrmAidatA2 fr = new FrmAidatA2();

            fr.Show();
            this.Hide();
        }

        private void BtnA3Aidat_Click(object sender, EventArgs e)
        {
            FrmAidatA3 fr = new FrmAidatA3();

            fr.Show();
            this.Hide();
        }

        private void BtnBAidat_Click(object sender, EventArgs e)
        {
            FrmAidatB fr = new FrmAidatB();

            fr.Show();
            this.Hide();
        }

        private void BtnCAidat_Click(object sender, EventArgs e)
        {
            FrmAidatC fr = new FrmAidatC();

            fr.Show();
            this.Hide();
        }
    }
}
