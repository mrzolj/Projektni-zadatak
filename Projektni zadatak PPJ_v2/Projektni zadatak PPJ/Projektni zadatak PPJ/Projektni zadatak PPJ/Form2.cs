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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void kreiranjeAzuriranjeNovogKupcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            this.Hide();
            fr2.Show();
        }

        private void azuriranjeArtikalaToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            String upit = "SELECT kupac_id AS 'ID kupca', ime AS 'Ime kupca', prezime AS 'Prezime kupca', grad AS Grad, adresa AS Adresa, telefon AS Telefon, user AS 'Korisnicko ime', pass AS Password" + " FROM kupac";
            try{

                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    upit += " WHERE ime LIKE '" + textBox1.Text + "%' AND prezime LIKE '" + textBox2.Text + "%' ";
                }

                if (textBox1.Text != "" && textBox2.Text=="")
                {
                upit += " WHERE ime LIKE '" + textBox1.Text + "%' ";
                }

                if (textBox2.Text != "" && textBox1.Text=="")
                {
                upit += " WHERE prezime LIKE '" + textBox2.Text + "%' ";
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

        private void Form2_Load(object sender, EventArgs e)
        {
            Insert();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Kreiranje_kupca_Click(object sender, EventArgs e)
        {
            String upit = "INSERT INTO kupac(ime, prezime, grad, adresa, telefon, user, pass) VALUES('" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" +textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "')";
            MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
            konekcija.Open();
            MySqlCommand cmd = new MySqlCommand(upit, konekcija);
            int test=cmd.ExecuteNonQuery();
            konekcija.Close();

            if (test == 0)
            {
                MessageBox.Show("Greska prilikom kreiranja novog korisnika!!!");
            }
            else if (test > 0)
            {
                MessageBox.Show("Uspjesno ste kreirali novog korisnika!!!");
                Clear();
            }

            Insert();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String ID = textBox10.Text;
                String upit = "SELECT ime, prezime, grad, adresa, telefon, user, pass FROM kupac WHERE kupac_id='" + ID + "' ";
                MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                konekcija.Open();
                MySqlCommand cmd1 = new MySqlCommand(upit, konekcija);
                MySqlDataReader reader;
                reader = cmd1.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    textBox3.Text = reader[0].ToString();
                    textBox4.Text = reader[1].ToString();
                    textBox5.Text = reader[2].ToString();
                    textBox6.Text = reader[3].ToString();
                    textBox7.Text = reader[4].ToString();
                    textBox8.Text = reader[5].ToString();
                    textBox9.Text = reader[6].ToString();
                }
                else 
                {
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                }

                reader.Close();
                konekcija.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            
        }

        private void azuriranje_kupca_Click(object sender, EventArgs e)
        {
            try
            {
                String ID = textBox10.Text;
                String upit = "UPDATE kupac SET ime='" + textBox3.Text + "', prezime='" + textBox4.Text + "', grad='" + textBox5.Text + "', adresa='" + textBox6.Text + "', telefon='" + textBox7.Text + "', user='" + textBox8.Text + "', pass='" + textBox9.Text + "' WHERE kupac_id='" + ID + "' ";
                MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                konekcija.Open();
                MySqlCommand cmd = new MySqlCommand(upit, konekcija);
                int test=cmd.ExecuteNonQuery();
                konekcija.Close();

                if (test == 0) { MessageBox.Show("Azuriranje podataka nije izvrseno!!!"); }
                else if (test > 0) { MessageBox.Show("Podaci su uspjesno azurirani!!!"); Clear(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Insert();
        }

        private void Insert()
        {
            String upit = "SELECT kupac_id AS 'ID kupca', ime AS 'Ime kupca', prezime AS 'Prezime kupca', grad AS Grad, adresa AS Adresa, telefon AS Telefon, user AS 'Korisnicko ime', pass AS Password FROM kupac";
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
