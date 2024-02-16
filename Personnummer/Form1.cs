using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personnummer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Datacontainer.connectsource = "Data Source=Klingen-su-db,62468; Initial Catalog = Klingen;";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Datacontainer.connectsource = "Data Source=Klingen-test-su-db,62468; Initial Catalog = Klingen_Test;";
        }
        ////
        private void button1_Click(object sender, EventArgs e)
        {
            if (Datacontainer.connectsource == "Data Source=Klingen-su-db,62468; Initial Catalog = Klingen;")
            {

                Datacontainer.SQLSearch = "SELECT [Personal number] FROM [Klingen].[dbo].[Patients] where [Personal number] is not null";

            }
            else
            {
                Datacontainer.SQLSearch = "SELECT [Personal number] FROM [Klingen_test].[dbo].[Patients] where [Personal number] is not null";

            }

            Datacontainer.command = new SqlCommand(Datacontainer.SQLSearch, Datacontainer.cnn);
            Datacontainer.command.CommandType = CommandType.Text;
            Datacontainer.reader = Datacontainer.command.ExecuteReader();
            Datacontainer.antal_reservnummer = 0;
            Datacontainer.antal_samordningsnummer = 0;
            Datacontainer.antal_vanliga_personnummer = 0;
            Datacontainer.antal_totala_poster = 0;
            while (Datacontainer.reader.Read())
            {
                char sam,n1, n2, n3, n4;
                Datacontainer.personnummer = (String)Datacontainer.reader.GetValue(0);
                if (Datacontainer.personnummer.Length >12)
                {
                    sam = Datacontainer.personnummer[6];
                    n1 = Datacontainer.personnummer[9];
                    n2 = Datacontainer.personnummer[10];
                    n3 = Datacontainer.personnummer[11];
                    n4 = Datacontainer.personnummer[12];
                    if (n1 < '0' || n1 > '9')
                    {
                        if (n2 < '0' || n2 > '9')
                        {
                            if (n3 < '0' || n3 > '9')
                            {
                                if (n4 < '0' || n4 > '9')
                                {
                                    Datacontainer.antal_reservnummer++;
                                }
                            }
                        }
                    }
                    else if(sam > '6')
                    {
                        Datacontainer.antal_samordningsnummer++;
                    }
                    else
                    {
                        Datacontainer.antal_vanliga_personnummer++;
                    }
                }
                Datacontainer.antal_totala_poster++;
            }
            ///Totala antal reservnummer
            textBox5.Text = Datacontainer.antal_reservnummer.ToString();
            textBox6.Text = Datacontainer.antal_samordningsnummer.ToString();
            textBox4.Text = Datacontainer.antal_vanliga_personnummer.ToString();
            textBox3.Text = Datacontainer.antal_totala_poster.ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Datacontainer.anvandarnamn = textBox1.Text;
            Datacontainer.losen = textBox2.Text;
            Datacontainer.connectionString = @Datacontainer.connectsource + "User ID=" + textBox1.Text + ";Password=" + textBox2.Text + "";
            Datacontainer.cnn = new SqlConnection(Datacontainer.connectionString);
            Datacontainer.cnn.Open();
            string message = "Connection Open  !";
            string title = "";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.OK)
            {
                button2.Enabled = true;
            }
            else
            {
                // Do something
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
