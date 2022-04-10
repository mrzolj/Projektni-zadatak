using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void kreiranjeNarudzbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            this.Hide();
            fr3.Show();
        }

        private void prikazNarudzbiIStavkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6();
            this.Hide();
            fr6.Show();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Insert1()
        {
            String upit = "SELECT * FROM narudzbenica WHERE kupac_id='" + Form1.ID_Kupca + "' ";
            try
            {
                MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                konekcija.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(upit, konekcija);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Insert1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String upit = "SELECT * FROM stavka_narudzbenice WHERE narudzbenica_id='" + textBox1.Text + "' ";
            try
            {
                MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                konekcija.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(upit, konekcija);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                dataGridView2.DataSource = tabela;
                adapter.Dispose();

                String total = "SELECT SUM(cijena*kolicina) FROM artikal a, stavka_narudzbenice sn WHERE a.artikal_id=sn.artikal_id AND narudzbenica_id='" + textBox1.Text + "'";
                MySqlCommand tot = new MySqlCommand(total, konekcija);
                MySqlDataReader reader;
                reader = tot.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    textBox2.Text = reader[0].ToString();
                    reader.Close();
                }
                reader.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
