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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ff();
            s();
            a();
            M();
            
        }

        public void M()
        {
            comboBox4.Items.Add("Активен");
            comboBox4.Items.Add("Не Активен");

            comboBox3.Items.Add("Авторское право");
            comboBox3.Items.Add("Печатный договор");
            comboBox3.Items.Add("Распространительский договор");
        }
        public void a()
        {
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
        public void s()
        {
            string connection = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog=hh;Integrated Security=True;";
            string sql = "SELECT ID_работника, Фамилия + ', ' + Имя AS ПолноеИмя FROM Работники WHERE Должность = 'Автор'";
        

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
            DataTable dataTable = new DataTable("Авторские_Права"); // Имя таблицы 
            dataSet.Tables.Add(dataTable);

            // Создание объекта DataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(" SELECT  ap.ID_Права,  i.Название AS Название_Издания,  r.Фамилия AS Имя_Автора,  ap.Тип_Права,  ap.Дата_Начала,  ap.Дата_Окончания,  ap.Условия,  ap.Статус FROM Авторские_Права ap JOIN  Издания i ON ap.Издание = i.ID_Издания JOIN  Работники r ON ap.Автор = r.ID_Работника; ", connection);

            // Заполнение DataTable данными из базы данных
            adapter.Fill(dataTable);

            // Привязка DataGridView к DataTable
            dataGridView2.DataSource = dataTable;

            // Включить режим редактирования
            dataGridView2.ReadOnly = true;
            // Включить возможность добавления строк
            dataGridView2.AllowUserToAddRows = false;

        }


        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog=hh;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Random random = new Random();
                int randomId = random.Next(1, 10000);

                connection.Open();

                string query = "INSERT INTO Авторские_Права (ID_Права, Издание, Автор, Тип_Права, Дата_Начала, Дата_Окончания, Условия, Статус) " +
                        "VALUES (@ID_Права, @Издание, @Автор, @Тип_Права, @Дата_Начала, @Дата_Окончания, @Условия, @Статус)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Права", Convert.ToInt32(randomId));
                command.Parameters.AddWithValue("@Издание", Convert.ToInt32(comboBox1.SelectedValue));
                command.Parameters.AddWithValue("@Автор", Convert.ToInt32(comboBox2.SelectedValue));
                command.Parameters.AddWithValue("@Тип_Права", comboBox3.Text); // Добавлен параметр @Тип_Права
                command.Parameters.AddWithValue("@Дата_Начала", textBox6.Text);
                command.Parameters.AddWithValue("@Дата_Окончания", textBox2.Text);
                command.Parameters.AddWithValue("@Условия", "");
                command.Parameters.AddWithValue("@Статус", comboBox4.Text);

                command.ExecuteNonQuery();

                ff();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RNM07NB\\SQLEXPRESS;Initial Catalog=hh;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Random random = new Random();

                int randomId = random.Next();

                connection.Open();



                string query = $"INSERT INTO Работники (ID_работника, Имя, Фамилия,Должность ) VALUES (@ID_работника, @Имя, @Фамилия,'Автор') INSERT INTO Издания (ID_издания, Название) VALUES (@ID_издания,@Название) ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_работника", randomId);
                command.Parameters.AddWithValue("@ID_издания", randomId);
                command.Parameters.AddWithValue("@Имя", textBox1.Text);
                command.Parameters.AddWithValue("@Фамилия", textBox4.Text);
                command.Parameters.AddWithValue("@Название", textBox3.Text);
             

                command.ExecuteNonQuery();

                s();
                a();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 s = new Form1();
            s.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
