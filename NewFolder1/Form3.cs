using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp6
{
    public partial class Form3 : Form
    {
        private string connectionString = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog = hh;Integrated Security=True;";
        private DataTable dataTable = new DataTable("Издания");

        public bool Visible { get; set; }
        public bool IsVisibleCalled { get; set; }
        public bool IsVisibleCal { get; set; }

        public Form3()
        {
            InitializeComponent();

            ff();
        }



        public void ff()
        {

            // Включить режим редактирования
            dataGridView1.ReadOnly = true;
            // Включить возможность добавления строк
            dataGridView1.AllowUserToAddRows = false;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog = hh;Integrated Security=True;");

            // Создание объекта DataSet и DataTable
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable("Издания"); //  Имя таблицы 
            dataSet.Tables.Add(dataTable);

            // Создание объекта DataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Издания", connection);

            // Заполнение DataTable данными из базы данных
            adapter.Fill(dataTable);

            // Привязка DataGridView к DataTable
            dataGridView1.DataSource = dataTable;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Получаем выбранную строку
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Заполняем TextBox-ы значениями из выбранной строки
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
            }
        }
            private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"UPDATE Издания SET  Название = '{textBox1.Text}',    Статус = '{textBox2.Text}',    Дата_выпуска = '{textBox3.Text}',   Цена = {textBox4.Text},   Автор = {textBox5.Text} WHERE Название = '{textBox1.Text}'";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            ff();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Random random = new Random();

                int randomId = random.Next();

                connection.Open();



                string query = $"INSERT INTO Издания (ID_издания, Название, Статус, Дата_выпуска, Цена, Автор) VALUES (@ID_издания, @Название, @Статус, @Дата_выпуска, @Цена, @Автор)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_издания", randomId);
                command.Parameters.AddWithValue("@Название", textBox1.Text);
                command.Parameters.AddWithValue("@Статус", textBox2.Text);
                command.Parameters.AddWithValue("@Дата_выпуска", textBox3.Text);
                command.Parameters.AddWithValue("@Цена", textBox4.Text);
                command.Parameters.AddWithValue("@Автор", textBox5.Text);

                command.ExecuteNonQuery();

                ff();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Пожалуйста, выберите строку в DataGridView", "Ошибка");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"DELETE FROM Издания WHERE Название = '{textBox1.Text}'";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            ff();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 s = new Form1();
            s.Show();
            this.Hide();
        }
    }
}
