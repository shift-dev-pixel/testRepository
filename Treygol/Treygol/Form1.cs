using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Treygol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.TextChanged += UpdateLabels;
            textBox2.TextChanged += UpdateLabels;
            textBox3.TextChanged += UpdateLabels;
        }
        private void UpdateLabels(object sender, EventArgs e)
        {
            label5.Text = "A: " + textBox1.Text;
            label6.Text = "B: " + textBox2.Text;
            label7.Text = "C: " + textBox3.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, c;
            if (double.TryParse(textBox1.Text, out a) && double.TryParse(textBox2.Text, out b) && double.TryParse(textBox3.Text, out c))
            {
                if (a <= 0 || b <= 0 || c <= 0)
                {
                    MessageBox.Show("Стороны треугольника должны быть положительными числами.", "Ошибка ввода");
                    return;
                }

                double s = (a + b + c) / 2;
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

                if (double.IsNaN(area))
                {
                    MessageBox.Show("Невозможно вычислить площадь треугольника. Проверьте введённые стороны.", "Ошибка вычисления");
                }
                else
                {
                    label10.Text = "Площадь треугольника: " + area.ToString("F2");

                    if (a == b && b == c)
                    {
                        label9.Text = "Тип треугольника: Равносторонний";
                    }
                    else if (a == b || a == c || b == c)
                    {
                        label9.Text = "Тип треугольника: Равнобедренный";
                    }
                    else
                    {
                        label9.Text = "Тип треугольника: Разносторонний";
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для всех сторон треугольника.", "Ошибка ввода");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
