﻿using System;
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
    public partial class Update : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["POS_Connection"].ConnectionString;
        public Update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlCommand_UPDATE = $"UPDATE Terminals SET {textBox3.Text} = '{textBox2.Text}' WHERE {textBox3.Text} = '{textBox1.Text}';";
                SqlCommand command = new SqlCommand(sqlCommand_UPDATE, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Operation <UPDATE> has been seccess");

            }
        }
    }
}
