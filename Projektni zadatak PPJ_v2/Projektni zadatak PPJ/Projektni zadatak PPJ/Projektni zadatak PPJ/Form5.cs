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
    public partial class Form5 : Form
    {
        public Form5()
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

        private void Form5_Load(object sender, EventArgs e)
        {
            Insert();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String upit = "DELETE FROM narudzbenica WHERE narudzbenica_id='" + textBox1.Text + "'";
                MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                konekcija.Open();
                MySqlCommand cmd = new MySqlCommand(upit, konekcija);
                int test = cmd.ExecuteNonQuery();
                konekcija.Close();

                if (test == 0) { MessageBox.Show("Greska prilikom brisanja narudzbe!!!"); }
                else { MessageBox.Show("Uspjesno ste obrisali narudzbu ID='" + textBox1.Text); textBox1.Clear(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Insert();
        }

        private void Insert()
        {
            String upit = "SELECT narudzbenica_id AS 'ID narudzbe', n.kupac_id AS 'ID kupca', datum_narudzbe AS 'Datum narudzbe' FROM narudzbenica n, kupac k WHERE k.kupac_id=n.kupac_id";
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
    }
}
