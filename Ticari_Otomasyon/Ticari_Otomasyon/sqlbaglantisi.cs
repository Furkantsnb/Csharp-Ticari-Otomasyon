using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    internal class sqlbaglantisi
    {
public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TicariOtomasyon.mdf;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
