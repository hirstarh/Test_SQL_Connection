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
        int ErrorCode;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql, sql_Insert, Output = "";

            /* SQL Server IP address 45.76.138.73 */
            try
            {
            /* Set up strings with ConnectionString and SQL commands */
            connectionString = @"Data Source=agem-se1.agem-bisenhs.org.uk;Initial Catalog =AdventureWorks2019;User ID=AHirst;Password=Coniston125";
            sql = "Select TOP (10) AddressID, AddressLine1, City, StateProvinceID, PostalCode from [AdventureWorks2019].[Person].[Address] ";
            sql_Insert = "Insert into [AdventureWorks2019].[Person].[Address] (AddressLine1, City, StateProvinceID, PostalCode) values('200 St Georges Place', 'Steyning', 51,  'BN44 3LN')"; 
                  
            /* Connect to database and execute the insert and select command */   
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql_Insert, cnn);
            adapter.InsertCommand.ExecuteNonQuery();

                
                MessageBox.Show("Congratulations you have successfully connected to the SQL-SE1 server", "Connection Made", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                
                /* Read back data from AdventureWorks2019 database Table */
                dataReader = command.ExecuteReader();
                    
                    while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2) + " - " + dataReader.GetValue(3) + " - " + dataReader.GetValue(4) + " \n ";
                
                }
                MessageBox.Show(Output);
                /* Close connections to SQL server */
                dataReader.Close();
                command.Dispose();
                cnn.Close();
            }
            catch (SqlException sqlEx)
            {
                ErrorCode = sqlEx.Number;
                MessageBox.Show($"Error code {ErrorCode}, No connection made to AGEM-SE1 SQL server, probably Firewall issues", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
    }
}
