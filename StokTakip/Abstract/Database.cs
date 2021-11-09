using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StokTakip.Abstract
{
    public class Database
    {
        public SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-8M7D7GE;Initial Catalog=Wissen;User ID=sa; password=1234");
        
        public void BaglantiAc()
        {
            sqlCon.Open();
        }

        
        
        public DataTable VeriGetir()
        {
            
            string sqlQuery = "Select * From Urunler";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, sqlCon);
            //DataSet sqlDs = new DataSet();
            DataTable sqlDt = new DataTable();
            sqlDa.Fill(sqlDt);
            //a = sqlDs.Tables["Urunler"];
            return sqlDt;
        }

        public void BaglantiKapat()
        {
            sqlCon.Close();
        }

        public DataTable VeriAra(string urunAdi)
        {

            string sqlQuery = "Select * From Urunler where urun_adi like '%" + urunAdi + "%'";
            //AND urun_fiyati like '%" + urunFiyati + "%' AND urun_stok like '%" + urunStok + "%'
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, sqlCon);
            //DataSet sqlDs = new DataSet();
            DataTable sqlDt = new DataTable();
            sqlDa.Fill(sqlDt);
            return sqlDt;
        }

        public void YeniSatirEkle(string yeniAd, int yeniFiyat, int yeniStok)
        {
            
            SqlCommand kmt = new SqlCommand("Insert into  Urunler (urun_adi,urun_fiyati,urun_stok) Values ('" + yeniAd + "'," + yeniFiyat + "," + yeniStok + ")",sqlCon);
            
            kmt.ExecuteNonQuery();
            
        }


    }
}
