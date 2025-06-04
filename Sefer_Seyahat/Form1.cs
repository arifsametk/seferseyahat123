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
        private SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-EQQDFBS\\SQLEXPRESS01;Initial Catalog=\"yolcu bilet\";Integrated Security=True;");
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            bool cinsiyet=true;
            if (cmbcinsiyet.Text == "ERKEK")
            {
                cinsiyet = true;
            }


            else if (cmbcinsiyet.Text=="KADIN")
            {
                cinsiyet = false;
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblyolcubilgi (ad,soyad,telefon,tc,cinsiyet,mail) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
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
    }
}
