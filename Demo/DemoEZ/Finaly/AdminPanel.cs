using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Demo
{
    public partial class AdminPanel : Form
    {
        string updateData = $"SELECT * FROM [User]";
        public AdminPanel()
        {
            
            InitializeComponent();
            UpdateSale();
        }

        public void UpdateSale()
        {
            db dataBase = new db();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand(updateData, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataGridView1.DataSource = table;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            db dataBase = new db();
            dataBase.openConnection();

            
            string idRole = textBox2.Text;
            string userLogin = textBox3.Text;
            string userPassword = textBox4.Text;

            string query = $"INSERT INTO [User] (ID_Роль, Логин, Пароль) VALUES ('{idRole}', '{userLogin}', '{userPassword}')";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());


            command.ExecuteNonQuery();
            UpdateSale();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string delete = textBox1.Text;

            db dataBase = new db();
            dataBase.openConnection();

            string deleteQuery = $"DELETE FROM НазваниеТаблицы WHERE ПоЧемуУдалять = @delete";
            SqlCommand command = new SqlCommand(deleteQuery, dataBase.getConnection());

            command.Parameters.AddWithValue("@delete", delete);
            command.ExecuteNonQuery();

            UpdateSale();
            dataBase.closeConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string articul = textBox1.Text;
            string name = textBox2.Text;
            string unit_of_measurement = textBox3.Text;
            decimal cost = Convert.ToDecimal(textBox4.Text);
            decimal maxDiscount = Convert.ToDecimal(textBox5.Text);
            string manufacturer = textBox6.Text;
            string supplier = textBox7.Text;
            string productCategory = textBox8.Text;
            decimal currentDiscount = Convert.ToDecimal(textBox9.Text);
            int quantityStock = Convert.ToInt32(textBox10.Text);
            string description = textBox11.Text;

            db dataBase = new db();
            dataBase.openConnection();

            string updateQuery = "UPDATE НазваниеТаблицы " +
                                 "SET [Наименование] = @Name, [Единица измерения] = @Unit_of_measurement, [Стоимость] = @Cost, [Размер максимально возможной скидки] = @MaxDiscount, " +
                                 "[Производитель] = @Manufacturer, [Поставщик] = @Supplier, [Категория товара] = @ProductCategory, [Действующая скидка] = @CurrentDiscount, " +
                                 "[Кол-во на складе] = @QuantityStock, [Описание] = @Description " +
                                 "WHERE [Артикул] = @Articul";

            SqlCommand command = new SqlCommand(updateQuery, dataBase.getConnection());

            command.Parameters.AddWithValue("@Articul", articul);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Unit_of_measurement", unit_of_measurement);
            command.Parameters.AddWithValue("@Cost", cost);
            command.Parameters.AddWithValue("@MaxDiscount", maxDiscount);
            command.Parameters.AddWithValue("@Manufacturer", manufacturer);
            command.Parameters.AddWithValue("@Supplier", supplier);
            command.Parameters.AddWithValue("@ProductCategory", productCategory);
            command.Parameters.AddWithValue("@CurrentDiscount", currentDiscount);
            command.Parameters.AddWithValue("@QuantityStock", quantityStock);
            command.Parameters.AddWithValue("@Description", description);

            command.ExecuteNonQuery();

            UpdateSale();
            dataBase.closeConnection();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateSale();
        }
    }
}
