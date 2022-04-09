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
            Insert();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            String upit = "SELECT a.artikal_id AS 'ID artikla', naziv_artikla AS 'Naziv artikla', vrsta_artikla AS 'Vrsta artikla', cijena AS 'Cijena artikla', s.kolicina_stanje AS 'Kolicina na stanju' FROM artikal a, skladiste s WHERE a.artikal_id=s.artikal_id";
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
            if (textBox3.Text != "" && textBox4.Text != "" && textBox4.Text != "" && textBox4.Text != "")
            {
                String upit = "INSERT INTO artikal(naziv_artikla, vrsta_artikla, cijena ) VALUES " +
                       "('" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "');" +
                       "INSERT INTO skladiste(artikal_id, kolicina_stanje) VALUES " +
                         "((SELECT MAX(artikal_id) FROM artikal), '" + textBox6.Text + "')";
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
                    errorProvider1.Clear();
                    MessageBox.Show("Uspjesno ste dodali novi artikal!!!");
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Insert();

            }
            else
            { errorProvider1.SetError(add_button, "Morate unijeti sve podatke o artiklu!!!");
                MessageBox.Show("Morate unijeti sve podatke o artiklu!!!");
            }
            Insert();



        }

        private void Clear()
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            numericUpDown1.Value = 0;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            String upit = "SELECT naziv_artikla, vrsta_artikla, cijena, s.kolicina_stanje FROM artikal a, skladiste s WHERE a.artikal_id=s.artikal_id AND a.artikal_id='" + textBox7.Text + "%'";
            MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
            konekcija.Open();
            MySqlCommand cmd = new MySqlCommand(upit, konekcija);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {

                textBox3.Text = reader[0].ToString();
                textBox4.Text = reader[1].ToString();
                textBox5.Text = reader[2].ToString();
                textBox6.Text = reader[3].ToString();
            }
            else { Clear(); }
            reader.Close();
            konekcija.Close();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown1.Value != 0)
                {
                    String upit = "UPDATE artikal a, skladiste s SET naziv_artikla='" + textBox3.Text + "', vrsta_artikla='" + textBox4.Text + "', cijena='" + textBox5.Text + "', s.kolicina_stanje=s.kolicina_stanje + '" + numericUpDown1.Value + "' WHERE a.artikal_id=s.artikal_id AND a.artikal_id='" + textBox7.Text + "'";
                    MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                    konekcija.Open();
                    MySqlCommand cmd = new MySqlCommand(upit, konekcija);
                    int a = cmd.ExecuteNonQuery();
                    konekcija.Close();
                    if (a == 0) { MessageBox.Show("Greska prilikom azuriranja artikla!!!"); }
                    else { MessageBox.Show("Uspjesno ste azurirali podatke za artikal " + textBox3.Text + " ID= " + textBox7.Text); Clear(); }
                }
                else
                {
                    String upit = "UPDATE artikal a, skladiste s SET naziv_artikla='" + textBox3.Text + "', vrsta_artikla='" + textBox4.Text + "', cijena='" + textBox5.Text + "', s.kolicina_stanje='" + textBox6.Text + "' WHERE a.artikal_id=s.artikal_id AND a.artikal_id='" + textBox7.Text + "'";
                    MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                    konekcija.Open();
                    MySqlCommand cmd = new MySqlCommand(upit, konekcija);
                    int a = cmd.ExecuteNonQuery();
                    konekcija.Close();
                    if (a == 0) { MessageBox.Show("Greska prilikom azuriranja artikla!!!"); }
                    else { MessageBox.Show("Uspjesno ste azurirali podatke za artikal " + textBox3.Text + " ID= " + textBox7.Text); Clear(); textBox7.Clear(); }
 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Insert();
            

        }

        private void Insert()
        {
            String upit = "SELECT a.artikal_id AS 'ID artikla', naziv_artikla AS 'Naziv artikla', vrsta_artikla AS 'Vrsta artikla', cijena AS 'Cijena artikla', s.kolicina_stanje AS 'Kolicina na stanju' FROM artikal a, skladiste s WHERE a.artikal_id=s.artikal_id";
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
