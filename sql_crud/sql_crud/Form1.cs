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
        string connectionString = ConfigurationManager.ConnectionStrings["POS_Connection"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Insert_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlCommand_INSERT = $"INSERT INTO Terminals (Merchant_Id,Terminal_Id,Name,Model,[S/N],Address) VALUES ('{textBoxMerchant_Id.Text}','{textBoxTerminal_Id.Text}','{textBoxName.Text}','{textBoxModel.Text}','{textBoxSN.Text}','{textBoxAddress.Text}')";
                SqlCommand command = new SqlCommand(sqlCommand_INSERT, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Operation <ADD> has been seccess");
                //ShowData();
            }
        }
        private void Update_Click(object sender, EventArgs e)
        {
            Update update=new Update();
            update.Show();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            delete.Show();
        }
        private void Load_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        private void ShowData()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            string sql = "SELECT * FROM Terminals";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                // делаем недоступным столбец id для изменения
                dataGridView1.Columns["Id"].ReadOnly = true;
            }
        }
    }
}
