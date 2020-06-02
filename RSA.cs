using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Numerics;

namespace Shifri
{
    public partial class RSA : Form
    {
        public RSA()
        {
            InitializeComponent();
        }

        //проверка: простое ли число?
        public static bool IsTheNumberSimple(long n)
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        //зашифровать
        public static List<string> RSA_Endoce(string s, long e, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(Main.characters, s[i]) + 1;

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            return result;
        }

        //расшифровать
        public static string RSA_Dedoce(string[] input, long d, long n)
        {
            string result = "";

            BigInteger bi;

            foreach (string item in input)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                int index = Convert.ToInt32(bi.ToString()) - 1;

                result += Main.characters[index].ToString();
            }

            return result;
        }

        //вычисление параметра d. d должно быть взаимно простым с m
        public static long Calculate_d(long m)
        {
            
            long d = m - 1;

            for (long i = 2; i <= m; i++)
            {

               if ((m % i == 0) && (d % i == 0)) //если имеют общие делители
                {
                    d--;
                    i = 1;
                }
            } 
            return d;
        }

        //вычисление параметра e
        public static long Calculate_e(long d, long m)
        {
            long e = 10;

            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    e++;
            }

            return e;
        }

        private void RSA_Load(object sender, EventArgs e)
        {
            richTextBox2.Text = Main.text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox5.Text.Length > 0) && (textBox6.Text.Length > 0))
            {
                richTextBox1.Clear();
                long p = Convert.ToInt64(textBox5.Text);
                long q = Convert.ToInt64(textBox6.Text);

                if (RSA.IsTheNumberSimple(p) && RSA.IsTheNumberSimple(q))
                {
                    string s = richTextBox2.Text;

                    s = s.ToUpper();

                    long n = p * q;
                    long m = (p - 1) * (q - 1);
                    long d = RSA.Calculate_d(m);
                    long e_ = RSA.Calculate_e(d, m);

                    List<string> result = RSA.RSA_Endoce(s, e_, n);

                    foreach (string item in result)
                        richTextBox1.Text += item + "\n";

                    textBox8.Text = d.ToString();
                    textBox7.Text = n.ToString();
                }
                else
                    MessageBox.Show("p или q - не простые числа!");
            }
            else
                MessageBox.Show("Введите p и q!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox8.Text.Length > 0) && (textBox7.Text.Length > 0))
            {
                long d = Convert.ToInt64(textBox8.Text);
                long n = Convert.ToInt64(textBox7.Text);

                string[] input = richTextBox1.Text.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                richTextBox3.Text = RSA.RSA_Dedoce(input, d, n);
            }
            else
                MessageBox.Show("Введите секретный ключ!");
        }

      
    }
}
