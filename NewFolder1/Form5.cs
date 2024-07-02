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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Fin();
            a();
            s();
        }
        public void s()
        {
            string connection = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog=hh;Integrated Security=True;";

            string sql = "SELECT ID_издания, Название  AS Назв FROM Издания";

            // Создание объекта DataAdapter для выполнения запроса
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            // Создание DataTable для хранения результатов запроса
            DataTable dt = new DataTable();

            // Заполнение DataTable результатами запроса
            adapter.Fill(dt);

            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Назв"; // Устанавливаем поле для отображения в ComboBox
            comboBox2.ValueMember = "ID_издания";



        }
        public void a()
        {
            string connection = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog=hh;Integrated Security=True;";

            string sql = @"
SELECT 
    r.ID_распространителя,
    r.Название AS Название_Распространителя
FROM 
    Распространители r";

            // Создание объекта DataAdapter для выполнения запроса
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            // Создание DataTable для хранения результатов запроса
            DataTable dt = new DataTable();

            // Заполнение DataTable результатами запроса
            adapter.Fill(dt);

            // Настройка ComboBox
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Название_Распространителя"; // Устанавливаем поле для отображения в ComboBox
            comboBox1.ValueMember = "ID_распространителя"; // Устанавливаем поле для хранения значения





        }


        private void Fin()
        {
            

                // Включить режим редактирования
                dataGridView1.ReadOnly = true;
                // Включить возможность добавления строк
                dataGridView1.AllowUserToAddRows = false;
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog = hh;Integrated Security=True;");

                // Создание объекта DataSet и DataTable
                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable("Печать"); //  Имя таблицы 
                dataSet.Tables.Add(dataTable);

                // Создание объекта DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT     i.Название AS Название_Издания,    r.Название AS Название_Распространителя,    p.Количество AS Количество FROM     Издания i JOIN     Печать p ON i.ID_издания = p.Издание JOIN     Распространители r ON p.Распространители = r.ID_распространителя;", connection);

                // Заполнение DataTable данными из базы данных
                adapter.Fill(dataTable);

                // Привязка DataGridView к DataTable
                dataGridView1.DataSource = dataTable;

            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 s = new Form1();
            s.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection1 = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog=hh;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connection1))
            {
                connection.Open();

                // Assuming you want to update the 'Распространители' column in the 'Печать' table
                // Make sure the values are correctly fetched from the comboboxes
                string distributorId = comboBox1.SelectedValue.ToString(); // Get the ID of the selected distributor
                string publicationId = comboBox2.SelectedValue.ToString(); // Get the ID of the selected publication

                string query = $"UPDATE Печать SET Распространители = '{distributorId}' WHERE Издание = '{publicationId}'";

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                Fin();
            }
        }
    }
}
