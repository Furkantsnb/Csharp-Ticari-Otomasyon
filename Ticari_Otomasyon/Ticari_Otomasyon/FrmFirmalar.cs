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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        

        sqlbaglantisi bgl = new sqlbaglantisi();

        void firnalistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TB_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR From TB_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 from TB_KODLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                RchKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }
        void temizle()
        {
            textAd.Text = "";
            textId.Text = "";
            textKod1.Text = "";
            textKod2.Text = "";
            textKod3 .Text = "";
            textMail.Text = "";
            textSektor.Text = "";
            textVergi.Text = "";
            textYetkili.Text = "";
            textYetkiliGorev.Text = "";
            MskFax.Text = "";
            MskTelefon1.Text = "";
            MskTelefon2.Text = "";
            MskTelefon3.Text = "";
            MskYetkiliTC.Text = "";
            RchAdres.Text = "";
            
        }


        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            firnalistesi();
            sehirlistesi();
            carikodaciklamalar();
            temizle();
            
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                textId.Text = dr["ID"].ToString();
                textAd.Text = dr["AD"].ToString();
                textYetkiliGorev.Text = dr["YETKILISTATU"].ToString();
                textYetkili.Text = dr["YETKILIADSOYAD"].ToString();
                MskYetkiliTC.Text = dr["YETKILITC"].ToString();
                textSektor.Text = dr["SEKTOR"].ToString();
                MskTelefon1.Text = dr["TELEFON1"].ToString();
                MskTelefon2.Text = dr["TELEFON2"].ToString();
                MskTelefon3.Text = dr["TELEFON3"].ToString();
                textMail.Text = dr["MAIL"].ToString();
                MskFax.Text = dr["FAX"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                textVergi.Text = dr["VERGIDAIRE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                textKod1.Text = dr["OZELKOD1"].ToString();
                textKod2.Text = dr["OZELKOD2"].ToString();
                textKod3.Text = dr["OZELKOD3"].ToString();
            }
        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(" insert into TB_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3," +
                "MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14," +
                "@p15,@p16,@p17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",textAd.Text);
            komut.Parameters.AddWithValue("@p2", textYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", textYetkili.Text);
            komut.Parameters.AddWithValue("@p4", MskYetkiliTC.Text);
            komut.Parameters.AddWithValue("@p5", textSektor.Text);
            komut.Parameters.AddWithValue("@p6", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p7", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@p8", MskTelefon3.Text);
            komut.Parameters.AddWithValue("@p9", textMail.Text);
            komut.Parameters.AddWithValue("@p10", MskFax.Text);
            komut.Parameters.AddWithValue("@p11", Cmbil.Text);
            komut.Parameters.AddWithValue("@p12", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p13", textVergi.Text);
            komut.Parameters.AddWithValue("@p14", RchAdres.Text);
            komut.Parameters.AddWithValue("@p15", textKod1.Text);
            komut.Parameters.AddWithValue("@p16", textKod2.Text);
            komut.Parameters.AddWithValue("@p17", textKod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Kaydedildi", "Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            firnalistesi();
            temizle();
        }

        private void Cmbil_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand(" Select ILCE From TB_ILCELER where SEHIR = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                
                Cmbilce.Properties.Items.Add(dr[0]);

            }
            bgl.baglanti().Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TB_FIRMALAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            firnalistesi();
            MessageBox.Show("Firma listeden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            temizle();
        }

        private void BtnGuncelle_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TB_FIRMALAR set AD=@p1,YETKILISTATU=@p2,YETKILIADSOYAD=@p3,YETKILITC=@p4,SEKTOR=@p5," +
                "TELEFON1=@p6,TELEFON2=@p7,TELEFON3=@p8,MAIL=@p9,IL=@p10,ILCE=@p11,FAX=@p12,VERGIDAIRE=@p13,ADRES=@p14,OZELKOD1=@p15," +
                "OZELKOD2=@p16,OZELKOD3=@p17 where ID =@p18", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", textYetkili.Text);
            komut.Parameters.AddWithValue("@p4", MskYetkiliTC.Text);
            komut.Parameters.AddWithValue("@p5", textSektor.Text);
            komut.Parameters.AddWithValue("@p6", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p7", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@p8", MskTelefon3.Text);
            komut.Parameters.AddWithValue("@p9", textMail.Text);
            komut.Parameters.AddWithValue("@p10", Cmbil.Text);
            komut.Parameters.AddWithValue("@p11", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p12", MskFax.Text);
            komut.Parameters.AddWithValue("@p13", textVergi.Text);
            komut.Parameters.AddWithValue("@p14", RchAdres.Text);
            komut.Parameters.AddWithValue("@p15", textKod1.Text);
            komut.Parameters.AddWithValue("@p16", textKod2.Text);
            komut.Parameters.AddWithValue("@p17", textKod3.Text);
            komut.Parameters.AddWithValue("@p18", textId.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firnalistesi();
            temizle();
        }

       
    }
}
