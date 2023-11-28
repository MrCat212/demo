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

namespace Demo
{
    public partial class ManagerPanel : Form
    {
        string updateData = $"SELECT * FROM НазваниеТаблицы";
        public ManagerPanel()
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



        private void ManagerPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
