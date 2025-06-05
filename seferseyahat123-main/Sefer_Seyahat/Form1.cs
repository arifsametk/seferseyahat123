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

namespace Sefer_Seyahat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-M8R9N1A\\SQLEXPRESS;Initial Catalog=\"yolcu bilet\";Integrated Security=True;");
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            bool cinsiyet = true;
            if (cmbcinsiyet.Text == "ERKEK")
            {
                cinsiyet = true;
            }


            else if (cmbcinsiyet.Text == "KADIN")
            {
                cinsiyet = false;
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_yolcubilgi (ad,soyad,telefon,tc,cinsiyet,mail) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktelefon.Text);
            komut.Parameters.AddWithValue("@p4", msktc.Text);
            komut.Parameters.AddWithValue("@p5", cinsiyet);
            komut.Parameters.AddWithValue("@p6", txtmail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yolcu Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_seferbilgi (seferno,kalkis,varis,tarih,saat,kaptan,fiyat) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            komut.Parameters.AddWithValue("@p1", txt_seferno.Text);
            komut.Parameters.AddWithValue("@p2", mtb_kalkis.Text);
            komut.Parameters.AddWithValue("@p3", mtb_varis.Text);
            komut.Parameters.AddWithValue("@p4", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@p5", mtb_saat.Text);
            komut.Parameters.AddWithValue("@p6", mtb_kaptan.Text);
            komut.Parameters.AddWithValue("@p7", txt_fiyat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sefer Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnrezervasyon_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_seferdetay (seferno,yolcutc,koltuk) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", txt_seferno.Text);
            komut.Parameters.AddWithValue("@p2", msktc.Text);
            komut.Parameters.AddWithValue("@p3", txtkoltukno.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Rezervasyon Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
