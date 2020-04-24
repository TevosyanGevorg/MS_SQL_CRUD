using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sql_crud
{
    public partial class Form1 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionCommpanies"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowData()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            string sql = "SELECT * FROM Companies";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter= new SqlDataAdapter(sql, connection);
                adapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                // делаем недоступным столбец id для изменения
                dataGridView1.Columns["Id"].ReadOnly = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlCommand_INSERT = $"INSERT INTO Companies (Name) VALUES ('{textBox1.Text}')";
                SqlCommand command = new SqlCommand(sqlCommand_INSERT, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Operation <ADD> has been seccess");
                //ShowData();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlCommand_DELETE = $"DELETE  FROM Companies WHERE Name='{textBox1.Text}'";
                SqlCommand command = new SqlCommand(sqlCommand_DELETE, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Operation <DELETE> has been seccess");
                //ShowData();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update update = new Update();
            update.Show();
        }
    }
}
