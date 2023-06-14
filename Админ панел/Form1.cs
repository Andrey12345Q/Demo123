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
    public partial class Form1 : Form
    {
        Class1 class1 = new Class1();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
               Class1 db = new Class1();
               DataTable table = new DataTable();

               SqlDataAdapter adapter = new SqlDataAdapter();

               SqlCommand command = new SqlCommand("SELECT * FROM admin WHERE login = @uL AND pass = @Ps", db.getConnection());

               command.Parameters.AddWithValue("@uL", textBox1.Text);
               command.Parameters.AddWithValue("@Ps", textBox2.Text);
               adapter.SelectCommand = command;
               adapter.Fill(table);
               if (table.Rows.Count > 0)
               {
                   this.Hide();
                   Form2 form2 = new Form2();
                   form2.Show();
               }
               else
               {
                   MessageBox.Show("Неправильный Логин или Пароль", "Ошибка");
                   return;
               }
           */
            SqlConnection connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestDB1;Integrated Security=True");

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM admin WHERE login = @uL AND pass = @Ps", connection);

            command.Parameters.AddWithValue("@uL", textBox1.Text);
            command.Parameters.AddWithValue("@Ps", textBox2.Text);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Неправильный Логин или Пароль", "Ошибка");
                return;
            }
        }

    }
}
