using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Demo
{
    public partial class Entrance : Form
    {
        db dataBase = new db();

        public Entrance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var Login = textBox1.Text;
            var Password = textBox2.Text;


            SqlDataAdapter adapter =  new SqlDataAdapter();
            DataTable table = new DataTable();
            string queryString = $"SELECT ID, ID_Роль, Логин, Пароль FROM [User] where Логин = '{Login}' and Пароль = '{Password}'";


            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                string role = table.Rows[0]["ID_Роль"].ToString();


                if (role == "1")
                {
                    AdminPanel admin = new AdminPanel();
                    admin.Show();
                }
                else if (role == "2")
                {
                    ManagerPanel manager = new ManagerPanel();
                    manager.Show();
                }
                else if (role == "2")
                {
                    ClientPanel client = new ClientPanel();
                    client.Show();
                }
            }
            else
            {
                MessageBox.Show("Ошибка", "Неверный логин или пароль");
            } 
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            MessageBox.Show("успешно", "Вы вошли как гость");
            ClientPanel client = new ClientPanel();
            client.Show();
        }       
    }  
}
