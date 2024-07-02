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

namespace WindowsFormsApp6
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Включить режим редактирования
            dataGridView1.ReadOnly = true;
            // Включить возможность добавления строк
            dataGridView1.AllowUserToAddRows = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog = hh;Integrated Security=True;");

            // Создание объекта DataSet и DataTable
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable("Финансы"); //  Имя таблицы 
            dataSet.Tables.Add(dataTable);

            // Создание объекта DataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Финансы", connection);

            // Заполнение DataTable данными из базы данных
            adapter.Fill(dataTable);

            // Привязка DataGridView к DataTable
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 s = new Form1();
            s.Show();
            this.Hide();
        }
    }
}
