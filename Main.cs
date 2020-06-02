using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shifri
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.FileName = "Select a text file";
        }


        public static string text = null;
        public static char[] characters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',' '};

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                text = sr.ReadToEnd();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (text != null)
            {
                RSA rsa = new RSA();
                rsa.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (text != null)
            {
                DES rsa = new DES();
                rsa.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (text != null)
            {
                AES rsa = new AES();
                rsa.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
