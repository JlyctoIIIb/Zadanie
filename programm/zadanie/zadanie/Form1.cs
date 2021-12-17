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

namespace zadanie
{
    public partial class Form1 : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-UQEHNUB;Persist Security Info=True;Integrated Security=SSPI;Initial Catalog=zadanie");
        public Form1()
        {
            InitializeComponent();
            try
            {
                Connection = new SqlConnection(@"Data Source=DESKTOP-UQEHNUB;Persist Security Info=True;Integrated Security=SSPI;Initial Catalog=zadanie");
                Connection.Open();
            }
            catch
            {
                MessageBox.Show("Ошибка не подключилось");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string AddBase = "INSERT INTO zadanie(id_Z, FIO, Mesto, Vrema) VALUES (" + textBox1.Text + "," + textBox2.Text + "," + comboBox1.Text + "," + textBox4.Text + ")";
                SqlCommand Command = new SqlCommand(AddBase, Connection);
                Command.ExecuteNonQuery();
                MessageBox.Show("Сохранено!");
            }
            catch
            {
                MessageBox.Show("Не записало");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                try
                {
                    string DelBase = "DELETE FROM zadanie WHERE id_Z=" + textBox5.Text;
                    SqlCommand Command = new SqlCommand(DelBase, Connection);
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Сохранено!");
                }
                catch 
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Ошибка!");
            }
            else
            {
                string EdditBase = "UPDATE zadanie SET id_Z=" + textBox7.Text + ", FIO=" + textBox8.Text + ", Mesto=" + comboBox2.Text + ", Vrema=" + textBox10.Text;
                SqlCommand Command = new SqlCommand(EdditBase, Connection);
                Command.ExecuteNonQuery();
                MessageBox.Show("Сохранено!");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.zadanie". При необходимости она может быть перемещена или удалена.
            this.zadanieTableAdapter.Fill(this.dataSet1.zadanie);

        }
    }
}
