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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void kreiranjeAzuriranjeKupcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            this.Hide();
            fr2.Show();
        }

        private void dodavanjeAzuriranjeArtikalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            this.Hide();
            fr4.Show();
        }

        private void prikazBrisanjeNarudzbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            this.Hide();
            fr5.Show();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            String upit = "SELECT a.artikal_id AS 'ID artikla', naziv_artikla AS 'Naziv artikla', vrsta_artikla AS 'Vrsta artikla', cijena AS 'Cijena artikla', kolicina_stanje AS 'Kolicina na stanju' FROM artikal a, skladiste s WHERE a.artikal_id=s.artikal_id";
            try
            {
                MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                konekcija.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(upit, konekcija);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
                adapter.Dispose();
                konekcija.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            String upit = "SELECT a.artikal_id AS 'ID artikla', naziv_artikla AS 'Naziv artikla', vrsta_artikla AS 'Vrsta artikla', cijena AS 'Cijena artikla', kolicina_stanje AS 'Kolicina na stanju' FROM artikal a, skladiste s WHERE a.artikal_id=s.artikal_id";
            try
            {

                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    upit += " and a.artikal_id LIKE '" + textBox1.Text + "%' AND naziv_artikla LIKE '" + textBox2.Text + "%' ";
                }

                if (textBox1.Text != "" && textBox2.Text == "")
                {
                    upit += " and a.artikal_id LIKE '" + textBox1.Text + "%' ";
                }

                if (textBox2.Text != "" && textBox1.Text == "")
                {
                    upit += " and naziv_artikla LIKE '" + textBox2.Text + "%' ";
                }

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

        private void add_button_Click(object sender, EventArgs e)
        {
            
        }

        private void Clear()
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
