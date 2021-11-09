using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VergiOtomasyon.Abstract
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
            
            string sqlQuery = "Select * From Vergiler";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, sqlCon);
            DataTable sqlDt = new DataTable();
            sqlDa.Fill(sqlDt);
            return sqlDt;
        }

        public void BaglantiKapat()
        {
            sqlCon.Close();
        }

        public DataTable VeriAra(string vergiadi)
        {

            string sqlQuery = "Select * From Vergiler where vergi_adi like '%" + vergiadi + "%'";
            //AND urun_fiyati like '%" + urunFiyati + "%' AND urun_stok like '%" + urunStok + "%'
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, sqlCon);
            DataTable sqlDt = new DataTable();
            sqlDa.Fill(sqlDt);
            return sqlDt;
        }

        public void VeriEkle(string yeniAd, int yenikdv, int yenigelir)
        {
            
            SqlCommand kmt = new SqlCommand("Insert into  Vergiler (vergi_adi,vergi_kdv,gelir_bilgi) Values ('" + yeniAd + "'," + yenikdv + "," + yenigelir + ")",sqlCon);
            kmt.ExecuteNonQuery();
        }

        public void VeriGuncelle(string vergiAdi, int vergiKdv, int gelirBilgi, int vergiId)
        {
            SqlCommand sqlkmt = new SqlCommand("update Vergiler set vergi_adi='" + vergiAdi + "', vergi_kdv=" + vergiKdv + ", gelir_bilgi=" + gelirBilgi + " where vergi_id=" + vergiId + "", sqlCon);
            sqlkmt.ExecuteNonQuery();
        }

        public void VeriSil(int vergiId)
        {
            SqlCommand sqlkmt = new SqlCommand("Delete from Vergiler where vergi_id=" + vergiId + "",sqlCon);
            sqlkmt.ExecuteNonQuery();
        }


    }
}
