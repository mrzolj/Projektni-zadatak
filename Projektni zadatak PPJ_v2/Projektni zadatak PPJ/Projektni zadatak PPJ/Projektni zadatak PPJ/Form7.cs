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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            this.Hide();
            fr1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                String upit = "INSERT INTO kupac(ime, prezime, grad, adresa, telefon, user, pass) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "')";
                MySqlConnection konekcija = new MySqlConnection(Form1.konekcioniString);
                konekcija.Open();
                MySqlCommand cmd = new MySqlCommand(upit, konekcija);
                int test = cmd.ExecuteNonQuery();
                konekcija.Close();
                if (test != 0) 
                { 
                    
                    errorProvider1.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    MessageBox.Show("Usjesno ste izvrsili registraciju novog korisnika!!!");
                }
                else { MessageBox.Show("Greska prilikom registracije novog korisnika. Molimo pokusajte ponovo!!!"); }
            }
            else {
                errorProvider1.SetError(button2, "Sva polja moraju biti popunjena prilikom registracije!!!");
            }

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
