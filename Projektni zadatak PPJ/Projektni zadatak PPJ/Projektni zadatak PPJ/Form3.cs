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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string ID;
        string NarMaxID;
        int Kol;
        int test;

        private void Form3_Load(object sender, EventArgs e)
        {
            Insert();
            Insert2();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Greska prilikom unosa. Provjerite unesene podatke!!!");
                }
                else
                {
                    ID = textBox1.Text;
                    Kol = Convert.ToInt32(textBox2.Text);
                    Kolicina();

                    if (Kol <= test)
                    {
                        String upit1 = "INSERT INTO stavka_narudzbenice(artikal_id, narudzbenica_id, kolicina) VALUES " +
                            "('" + ID + "', '" + NarMaxID + "', '" + Kol + "')";
                        String upit2 = "UPDATE skladiste SET kolicina_stanje=kolicina_stanje-'" + Kol + "' WHERE artikal_id='" + ID + "'";

                        MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                        konekcija.Open();
                        MySqlCommand cmd1 = new MySqlCommand(upit1, konekcija);
                        MySqlCommand cmd2 = new MySqlCommand(upit2, konekcija);
                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        konekcija.Close();
                    }
                    else if (Kol > test) { MessageBox.Show("Trenutno na stanju nemamo tu kolicinu, molimo Vas unesite manji broj!"); }

                    Insert();
                    Insert2();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Insert()
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

        private void create_button_Click(object sender, EventArgs e)
        {
            DateTime Time = DateTime.Now;
            String vrijeme = "INSERT INTO narudzbenica(kupac_id, datum_narudzbe) VALUES('" + Form1.ID_Kupca + "', '" + Time.ToString("yyyy-MM-dd") + "')";
            MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
            konekcija.Open();
            MySqlCommand time = new MySqlCommand(vrijeme, konekcija);
            time.ExecuteNonQuery();
            String upit = "SELECT MAX(narudzbenica_id) FROM narudzbenica";
            MySqlCommand cmd = new MySqlCommand(upit, konekcija);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows) {NarMaxID = reader[0].ToString(); }
            reader.Close();
            konekcija.Close();
        }

        private void Kolicina()
        {
            String upit = "SELECT kolicina_stanje FROM skladiste WHERE artikal_id='" + textBox1.Text + "'";
            MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
            konekcija.Open();
            MySqlCommand cmd1 = new MySqlCommand(upit, konekcija);
            MySqlDataReader reader;
            reader = cmd1.ExecuteReader();
            reader.Read();

            test =Convert.ToInt32(reader[0].ToString());

            reader.Close();
            konekcija.Close();
        }

        private void Insert2()
        {
            String upit = "SELECT a.artikal_id AS 'ID artikla', naziv_artikla AS 'Naziv artikla', kolicina AS Kolicina, cijena AS 'Cijena artikla' FROM artikal a, stavka_narudzbenice s WHERE a.artikal_id=s.artikal_id";
            try
            {
                MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                konekcija.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(upit, konekcija);;
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                dataGridView2.DataSource = tabela;
                adapter.Dispose();
                konekcija.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "") { MessageBox.Show("Greska prilikom brisanja. Provjerite unesene podatke!!!"); }
                else
                {
                    int broj = 0;
                    ID = textBox1.Text;

                    String query = "SELECT kolicina FROM stavka_narudzbenice WHERE narudzbenica_id='" + NarMaxID + "' AND artikal_id='" + ID + "' ";

                    String upit1 = "DELETE FROM stavka_narudzbenice WHERE artikal_id='" + ID + "' AND narudzbenica_id='" + NarMaxID + "'";


                    MySqlConnection konekcija1 = new MySqlConnection(Form1.konekcioniString);
                    konekcija1.Open();
                    MySqlCommand cmd1 = new MySqlCommand(upit1, konekcija1);
                    MySqlCommand cmd3 = new MySqlCommand(query, konekcija1);

                    MySqlDataReader reader;
                    reader=cmd3.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                       broj = Convert.ToInt32(reader[0].ToString());
                    }

                    reader.Close();
                    String upit2 = "UPDATE skladiste SET kolicina_stanje=kolicina_stanje+'" + broj + "' WHERE artikal_id='" + ID + "' ";
                    MySqlCommand cmd2 = new MySqlCommand(upit2, konekcija1);
                    cmd2.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();

                    Insert();
                    Insert2();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Insert2();
        }
    }
}
