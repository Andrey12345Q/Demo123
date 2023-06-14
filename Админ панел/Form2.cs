using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Админ_панел
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 db = new Class1();


            SqlCommand command = new SqlCommand("UPDATE admin SET login = @login, pass = @pass WHERE id = @id", db.getConnection());
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = textBox1.Text;

            command.Parameters.Add("@login", SqlDbType.VarChar).Value = textBox2.Text;

            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBox3.Text;


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Запись изменена");
            else
                MessageBox.Show("Ошибка");
            db.closeConnection();

            Class1 dbb = new Class1();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand comman = new SqlCommand("SELECT id, login AS Логин, pass AS Пароль FROM admin", dbb.getConnection());

            adapter.SelectCommand = comman;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить пользователя", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Class1 db = new Class1();

                DataTable table = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand command = new SqlCommand("DELETE  FROM admin WHERE id = @pId", db.getConnection()); //TableName - имя таблицы, из которой удаляете запись
                command.Parameters.Add(new SqlParameter("@pId", this.dataGridView1.CurrentRow.Cells["id"].EditedFormattedValue)); //DataGridViewName - имя DataGridView на форме


                adapter.SelectCommand = command;
                adapter.Fill(table);

                SqlCommand commandd = new SqlCommand("SELECT id, login AS Логин, pass AS Пароль FROM admin", db.getConnection());

                adapter.SelectCommand = commandd;
                adapter.Fill(table);
                dataGridView1.DataSource = table;

            }
            MessageBox.Show("Запись удалена");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Class1 db = new Class1();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand commandd = new SqlCommand("SELECT id, login AS Логин, pass AS Пароль FROM admin", db.getConnection());

            adapter.SelectCommand = commandd;
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Class1 db = new Class1();

            SqlCommand command = new SqlCommand("INSERT INTO admin ( login, pass) VALUES (@login, @pass)", db.getConnection());


            command.Parameters.Add("@login", SqlDbType.VarChar).Value = textBox4.Text;

            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBox5.Text;


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Запись добавлена");
            else
                MessageBox.Show("Ошибка");
            db.closeConnection();

            Class1 dbb = new Class1();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand comman = new SqlCommand("SELECT id, login AS Логин, pass AS Пароль FROM admin", dbb.getConnection());

            adapter.SelectCommand = comman;
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            /*
            string searchValue = textBox1.Text;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            */
        }
    }
}
