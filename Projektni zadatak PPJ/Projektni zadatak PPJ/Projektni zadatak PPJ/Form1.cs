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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static String ID_Kupca;
        public static String konekcioniString = "Server=localhost; Port=3306; " +
            "Database=projektni zadatak ppj; Uid=root; Pwd=root";

        private void button1_Click(object sender, EventArgs e)
        {
            String user = textBox1.Text;
            String pass = textBox2.Text;
            String select = "SELECT user, pass, kupac_id, ime, prezime FROM kupac WHERE user='" + user + "' ";
            try
            {
                MySqlConnection konekcija = new MySqlConnection(konekcioniString);
                konekcija.Open();
                MySqlCommand cmd = new MySqlCommand(select, konekcija);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                reader.Read();

                if (!reader.HasRows)
                {
                    errorProvider1.SetError(textBox1, "Pogresno korisnicko ime!!!");
                }
                else 
                {
                    String password = reader[1].ToString();
                    ID_Kupca = reader[2].ToString();
                    String ime = reader[3].ToString();
                    String prezime = reader[4].ToString();
                    errorProvider1.Clear();

                    if (pass == password)
                    {
                        MessageBox.Show("Uspjesno ste logovani " + ime + " " + prezime);
                        if (ID_Kupca == "1")
                        {
                            Form2 fr2 = new Form2();
                            this.Hide();
                            fr2.Show();
                        }
                        else 
                        {
                            Form3 fr3 = new Form3();
                            this.Hide();
                            fr3.Show();
                        }
                    }
                    else { errorProvider2.SetError(textBox2, "Pogresan password!!!"); }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        

        
    }
}
