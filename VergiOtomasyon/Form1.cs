using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VergiOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Abstract.Database db = new Abstract.Database();

        private void btnAra_Click(object sender, EventArgs e)
        {
            string vergiadi = txtvergiAdi.Text;
            db.BaglantiAc();
            db.VeriAra(vergiadi);
            db.BaglantiKapat();
            
        }

        public void griddoldur()
        {
            db.BaglantiAc();
            dataGridView1.DataSource = db.VeriGetir();
            db.BaglantiKapat();
            txtvergiId.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtvergiId.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            txtvergiAdi.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            txtvergiKdv.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            txtgelirBilgi.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string vergiAdi = txtvergiAdi.Text;
            int vergiKdv = Convert.ToInt32(txtvergiKdv.Text);
            int gelirBilgi = Convert.ToInt32(txtgelirBilgi.Text);
            db.BaglantiAc();
            db.VeriEkle(vergiAdi,vergiKdv,gelirBilgi);
            db.BaglantiKapat();
            MessageBox.Show("Eklendi.");
            griddoldur();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string vergiAdi = txtvergiAdi.Text;
            int vergiKdv = Convert.ToInt32(txtvergiKdv.Text);
            int gelirBilgi = Convert.ToInt32(txtgelirBilgi.Text);
            int vergiId = Convert.ToInt32(txtvergiId.Text);
            db.BaglantiAc();
            db.VeriGuncelle(vergiAdi, vergiKdv, gelirBilgi,vergiId);
            db.BaglantiKapat();
            MessageBox.Show("Güncellendi.");
            griddoldur();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int vergiId = Convert.ToInt32(txtvergiId.Text);
            db.BaglantiAc();
            db.VeriSil(vergiId);
            db.BaglantiKapat();
            MessageBox.Show("Silindi.");
            griddoldur();
        }
    }
}
