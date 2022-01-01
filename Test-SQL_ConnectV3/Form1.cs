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

namespace Test_SQL_ConnectV3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;

            /* SQL Server IP address 45.76.138.73 */
            connectionString = @"Data Source=agem-se1.agem-bisenhs.org.uk;Database=Master;User ID=AHirst;Password=Coniston125";

            cnn = new SqlConnection(connectionString);

            try
            {
                /* Open up connection to the database*/
                cnn.Open();
                MessageBox.Show("Congratulations you have successfully connected to the SQL-SE1 server", "Connection Made", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("No connection made to AGEM-SE1 SQL server, probably Firewall issues", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
    }
}
