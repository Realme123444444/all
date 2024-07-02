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
    public partial class Form4 : Form
    {

        private string connectionString = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog = hh;Integrated Security=True;";
        private DataTable dataTable = new DataTable("Издания");
        public Form4()
        {
            InitializeComponent();

            Fin();
            Fin1();
            Fin2();
            ff();
        }
        private void Fin() {


            string connection = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog=hh;Integrated Security=True;";

            string sql = "SELECT ID_издания, Название  AS Назв FROM Издания";

            // Создание объекта DataAdapter для выполнения запроса
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            // Создание DataTable для хранения результатов запроса
            DataTable dt = new DataTable();

            // Заполнение DataTable результатами запроса
            adapter.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Назв"; // Устанавливаем поле для отображения в ComboBox
            comboBox1.ValueMember = "ID_издания";



        }
        private void Fin1()
        {

            string connection = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog=hh;Integrated Security=True;";
            string sql = "SELECT ID_работника, Фамилия + ', ' + Имя AS ПолноеИмя FROM Работники WHERE Должность = 'Редактор'";


            // Создание объекта DataAdapter для выполнения запроса
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            // Создание DataTable для хранения результатов запроса
            DataTable dt = new DataTable();

            // Заполнение DataTable результатами запроса
            adapter.Fill(dt);

            // Заполнение ComboBox данными из DataTable
            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "ПолноеИмя"; // Устанавливаем поле для отображения в ComboBox
            comboBox4.ValueMember = "ID_работника"; // Теперь это поле присутствует в DataTable




        }
        private void Fin2()
        {

            string connection = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog=hh;Integrated Security=True;";
            string sql = "SELECT ID_работника, Фамилия + ', ' + Имя AS ПолноеИмя FROM Работники WHERE Должность = 'Корректор'";


            // Создание объекта DataAdapter для выполнения запроса
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            // Создание DataTable для хранения результатов запроса
            DataTable dt = new DataTable();

            // Заполнение DataTable результатами запроса
            adapter.Fill(dt);

            // Заполнение ComboBox данными из DataTable
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "ПолноеИмя"; // Устанавливаем поле для отображения в ComboBox
            comboBox2.ValueMember = "ID_работника"; // Теперь это поле присутствует в DataTable




        }
        public void ff()
        {

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog = hh;Integrated Security=True;");

            // Создание объекта DataSet и DataTable
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable("Издания");
            dataSet.Tables.Add(dataTable);

            // Создание объекта DataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(" SELECT  i.Название AS Название_Издания,  r1.Фамилия AS Редактор,  r2.Фамилия AS Корректор FROM  Издания i JOIN  Работники r1 ON i.Редактор = r1.ID_Работника JOIN  Работники r2 ON i.Корректор = r2.ID_Работника; ", connection);

            // Заполнение DataTable данными из базы данных
            adapter.Fill(dataTable);

            // Привязка DataGridView к DataTable
            dataGridView1.DataSource = dataTable;

            // Включить режим редактирования
            dataGridView1.ReadOnly = true;
            // Включить возможность добавления строк
            dataGridView1.AllowUserToAddRows = false;

        }
        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"UPDATE Издания SET  Редактор  = '{comboBox4.SelectedValue}',    Корректор = '{comboBox2.SelectedValue}'    WHERE Название = '{comboBox1.Text}'";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            ff();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog=hh;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Random random = new Random();

                int randomId = random.Next();

                connection.Open();



                string query = $"INSERT INTO Работники (ID_работника, Имя, Фамилия,Должность ) VALUES (@ID_работника, @Имя, @Фамилия,'Редактор')  ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_работника", randomId);
                command.Parameters.AddWithValue("@Имя", textBox1.Text);
                command.Parameters.AddWithValue("@Фамилия", textBox2.Text);

                command.ExecuteNonQuery();
                Fin1();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog=hh;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Random random = new Random();

                int randomId = random.Next();

                connection.Open();



                string query = $"INSERT INTO Работники (ID_работника, Имя, Фамилия,Должность ) VALUES (@ID_работника, @Имя, @Фамилия,'Корректор')  ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_работника", randomId);
                command.Parameters.AddWithValue("@Имя", textBox3.Text);
                command.Parameters.AddWithValue("@Фамилия", textBox4.Text);

                command.ExecuteNonQuery();
                Fin2();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 s = new Form1();
            s.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
