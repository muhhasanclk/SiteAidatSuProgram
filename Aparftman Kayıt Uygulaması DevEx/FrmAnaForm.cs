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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void BtnBilgiler_Click(object sender, EventArgs e)
        {
            FrmBilgiler fr = new FrmBilgiler();

            fr.Show();
            this.Hide();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAidat_Click(object sender, EventArgs e)
        {
            FrmAidatIslemleri fr = new FrmAidatIslemleri();

            fr.Show();
            this.Hide();
        }

        private void btnSu_Click(object sender, EventArgs e)
        {
            FrmSu fr = new FrmSu();

            fr.Show();
            this.Hide();
        }

        private void btnKayıtİslemleri_Click(object sender, EventArgs e)
        {
            FrmKayit fr = new FrmKayit();

            fr.Show();
            this.Hide();
        }

        private void btnHakkimizda_Click(object sender, EventArgs e)
        {
            FrmHakkimizda fr = new FrmHakkimizda();

            fr.Show();
            this.Hide();
        }
    }
}
