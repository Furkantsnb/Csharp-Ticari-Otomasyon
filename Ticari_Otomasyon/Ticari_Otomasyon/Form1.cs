using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FrmUrunler fr;
        private void BtnUrunler_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr = new FrmUrunler();
            fr.MdiParent = this;
            fr.Show();

        }
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr1 = new FrmMusteriler();
            fr1.MdiParent = this;
            fr1.Show();
        }

        FrmFirmalar fr2;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr2 = new FrmFirmalar();
            fr2.MdiParent = this;
            fr2.Show();
        }
        FrmPersoneller fr3;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr3 = new FrmPersoneller();
            fr3.MdiParent = this;
            fr3.Show();
        }
        FrmGiderler fr4;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr4 = new FrmGiderler();
            fr4.MdiParent = this;
            fr4.Show();
        }
        FrmRehber fr5;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr5 = new FrmRehber();
            fr5.MdiParent = this;
            fr5.Show();
        }
        FrmMusteriler fr1;

        
    }
}
