using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Act_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void clearData()
        {
            name_txt.Text = "";
            yearsec_txt.Text = "";
            sub_txt.Text = "";
            gr1.Text = "";
            gr2.Text = "";
            gr3.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string connectionStr = "server = localhost;user=root;database=cit203;port3306;password=";

            string name = name_txt.Text;
            string yearsec = yearsec_txt.Text;
            string subject = sub_txt.Text;
            double g1 = Convert.ToInt32(gr1_txt.Text);
            double g2 = Convert.ToInt32(gr2_txt.Text);
            double g3 = Convert.ToInt32(gr3_txt.Text);

            if (name == " " || yearsec == " " || subject == " " || g1 == 0 || g2 == 0 || g3 == 0)

            {
                MessageBox.Show("Please fill in the details asked.");
            }

            else
            {

                double totalgrade = (g1 + g2 + g3) / 3;

                MySqlConnection conn = new MySqlConnection(connectionStr);
                MySqlCommand cmd = null; 
                string addcommandstring = "";
                conn.Open();


            

                addcommandstring = "INSERT INTO  student (fullname, yrsec, subject, totalgrade) VALUES (@fullname, @yrsec, @subject, @totalgrade)";

                cmd = new MySqlCommand(addcommandstring, conn);

                cmd.Parameters.AddWithValue("@fullname", name);
                cmd.Parameters.AddWithValue("@yrsec", yearsec);
                cmd.Parameters.AddWithValue("@subject", subject);
                cmd.Parameters.AddWithValue("@totalgrade", totalgrade);
                cmd.ExecuteNonQuery();

                conn.Close();


            }
            MessageBox.Show("Data Stored Successfully");
            clearData();


        }
    }
}
 