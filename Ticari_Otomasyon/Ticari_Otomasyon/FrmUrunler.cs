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

namespace Ticari_Otomasyon
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

       

       
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(" Select * From TB_URUNLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;   
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
        }

       

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // VERİLERİ KAYDETME
            SqlCommand komut = new SqlCommand(" insert into TB_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8) " , bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textMarka.Text);
            komut.Parameters.AddWithValue("@p3", textModel.Text);
            komut.Parameters.AddWithValue("@p4", MskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(textAlis.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(textSatis.Text));
            komut.Parameters.AddWithValue("@p8", RchDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi " , "Bilgi" , MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

          // VERİ SİLME
        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From TB_URUNLER where ID=@p1" , bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", textid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            textid.Text = dr["ID"].ToString();
            textAd.Text = dr["URUNAD"].ToString();
            textMarka.Text = dr["MARKA"].ToString();
            textModel.Text = dr["MODEL"].ToString();
            MskYil.Text = dr["YIL"].ToString();
            NudAdet.Value = decimal.Parse(dr["ADET"].ToString());
            textAlis.Text = dr["ALISFIYAT"].ToString();
            textSatis.Text = dr["SATISFIYAT"].ToString();
            RchDetay.Text = dr["DETAY"].ToString();

        }

          // VERİ GÜNCELLEME
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TB_URUNLER set URUNAD =@p1 ,MARKA=@p2, MODEL=@p3,YIL=@p4,ADET=@p5,ALISFIYAT=@p6,SATISFIYAT=@p7,DETAY=@p8 where ID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textMarka.Text);
            komut.Parameters.AddWithValue("@p3", textModel.Text);
            komut.Parameters.AddWithValue("@p4", MskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(textAlis.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(textSatis.Text));
            komut.Parameters.AddWithValue("@p8", RchDetay.Text);
            komut.Parameters.AddWithValue("@p9", textid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün bilgisi Güncellendi" , "Bilgi" , MessageBoxButtons.OK,MessageBoxIcon.Warning);
            listele();

        }
    }
}
