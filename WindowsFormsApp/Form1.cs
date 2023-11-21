using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp
{

        public partial class Form1 : Form
        {   

        private List<string> dictionary = File.ReadAllLines("C:\\Users\\Shuti\\source\\repos\\WindowsFormsApp\\dictionary.txt", Encoding.UTF8).ToList();


        public Form1()
        {
            InitializeComponent();
        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;
            if (number == 8 && textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length-1);
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length-1);
            }
            if (dictionary.Contains(number.ToString()) && textBox1.Text.Length < 32)
                textBox2.Text += dictionary[dictionary.Count - 1 - dictionary.IndexOf(number.ToString())].ToString();
            else if (textBox1.Text.Length < 32 && number != 8)
            {
                e.Handled = true;
                MessageBox.Show("Запрещенный символ!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if (number != 8)
            {
                e.Handled = true;
                MessageBox.Show("Превышенна длина символов!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";
           
            try
            {
             str = File.ReadAllText("C:\\Users\\Shuti\\source\\repos\\WindowsFormsApp\\name.txt");
            }
            catch(Exception)
            {
                MessageBox.Show("Файл не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            textBox1.Clear();
            textBox2.Clear();
            string def = "", shf = "";

            if (str.Length == 0)
            {
                MessageBox.Show("Файл пуст!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            if (str.Length > 32)
            {
                MessageBox.Show("Превышенна длина символов в файле!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (dictionary.Contains((str[i]).ToString()))
                {
                    def += str[i];
                    shf += dictionary[dictionary.Count - 1 - dictionary.IndexOf(str[i].ToString())];
                }
                else
                {
                    MessageBox.Show("Запрещенный символ в файле!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
                textBox1.Text = def;
                textBox2.Text = shf;
        }

            private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }


    }
}
