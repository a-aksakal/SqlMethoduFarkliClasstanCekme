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


namespace StokTakip
{
    public partial class FormYonetici : Form
    {
        public FormYonetici()
        {
            InitializeComponent();
            
        }
        Abstract.Database database = new Abstract.Database();
        
        
            
       

        private void btnAra_Click(object sender, EventArgs e)
        {
            string uAdi = txtUrunAdi.Text;
            database.BaglantiAc();
            dataGridView1.DataSource = database.VeriAra(uAdi);
            database.BaglantiKapat();
        }

        private void FormYonetici_Load(object sender, EventArgs e)
        {
            database.BaglantiAc();
            dataGridView1.DataSource = database.VeriGetir();
            database.BaglantiKapat();
            

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string urunAdi = txtUrunAdi.Text;
            int urunFiyati = Convert.ToInt32(txtUrunFiyati.Text);
            int urunStok = Convert.ToInt32(txtUrunStok.Text);
            database.BaglantiAc();
            database.YeniSatirEkle(urunAdi,urunFiyati,urunStok);
            database.BaglantiKapat();
        }
    }
}
