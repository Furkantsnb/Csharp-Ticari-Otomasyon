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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void giderlistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TB_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            textEkstra.Text = "";
            textElektrik.Text = "";
            textinternet.Text = "";
            textMaaslar.Text = "";
            textDogalgaz.Text = "";
            textSu.Text = "";
            textid.Text = "";
            CmbAy.Text = "";
            CmbYil.Text = "";
            RchNotlar.Text = "";

        }
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            giderlistesi();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TB_GIDERLER (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1",CmbAy.Text);
            komut.Parameters.AddWithValue("@p2", CmbYil.Text);
            komut.Parameters.AddWithValue("@p3",decimal.Parse( textElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse (textSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(textDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(textinternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(textMaaslar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse( textEkstra.Text));
            komut.Parameters.AddWithValue("@p9", RchNotlar.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider tablosuna eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderlistesi();
            temizle();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!= null)
            {
                textid.Text = dr["ID"].ToString();
                CmbAy.Text = dr["AY"].ToString();
                CmbYil.Text = dr["YIL"].ToString();
                textElektrik.Text = dr["ELEKTRIK"].ToString();
                textSu.Text = dr["SU"].ToString();
                textDogalgaz.Text = dr["DOGALGAZ"].ToString();
                textinternet.Text = dr["INTERNET"].ToString();
                textMaaslar.Text = dr["MAASLAR"].ToString();
                textEkstra.Text = dr["EKSTRA"].ToString();
                RchNotlar.Text = dr["NOTLAR"].ToString();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From TB_GIDERLER where ID = @p1",bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", textid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            giderlistesi();
            MessageBox.Show("Gider listesinden silindir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            temizle();


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TB_GIDERLER set AY=@p1,YIL=@p2,ELEKTRIK=@p3,SU=@p4,DOGALGAZ=@p5,INTERNET=@p6,MAASLAR=@p7,EKSTRA=@p8,NOTLAR=@p9 where ID=@p10 ",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbAy.Text);
            komut.Parameters.AddWithValue("@p2", CmbYil.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(textElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(textSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(textDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(textinternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(textMaaslar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(textEkstra.Text));
            komut.Parameters.AddWithValue("@p9", RchNotlar.Text);
            komut.Parameters.AddWithValue("@p10", textid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderlistesi();
            temizle();
        }
    }
}
