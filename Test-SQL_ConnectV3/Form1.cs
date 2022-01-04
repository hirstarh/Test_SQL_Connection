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
    public partial class txtAddress2 : Form
    {
        int ErrorCode;
        public txtAddress2()
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
            String sql, sql_Insert,sql_Update, sql_Delete, Output = "";

            /* SQL Server IP address 45.76.138.73 */
            try
            {

                connectionString = @"Data Source=agem-se1.agem-bisenhs.org.uk;Initial Catalog =AdventureWorks2019;User ID=AHirst;Password=Coniston125";
                sql = " Select TOP (20) AddressID, AddressLine1, City, StateProvinceID, PostalCode From [AdventureWorks2019].[Person].[Address] ";
                sql_Insert = "Insert into [AdventureWorks2019].[Person].[Address] (AddressLine1, City, StateProvinceID, PostalCode) values('950 Mill Lane', 'Steyning', 45, 'BN44 3LN') ";
                sql_Update = "Update [AdventureWorks2019].[Person].[Address] set AddressLine1='330 Mill Lane' where AddressID=32523";
                sql_Delete = "Delete [AdventureWorks2019].[Person].[Address] where AddressID=32522";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                adapter.DeleteCommand = new SqlCommand(sql_Delete, cnn);
                adapter.DeleteCommand.ExecuteNonQuery();

                command = new SqlCommand(sql, cnn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " _ " + dataReader.GetValue(2) + " - " + dataReader.GetValue(3) + " - " + dataReader.GetValue(4);
                }
                MessageBox.Show(Output);
                
                MessageBox.Show("Congratulations you have successfully connected to the SQL-SE1 server", "Connection Made", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnn.Close();
                dataReader.Close();
                command.Dispose();
                
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
