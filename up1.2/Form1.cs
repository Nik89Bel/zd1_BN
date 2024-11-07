using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace up1._2
{
    public partial class Form1 : Form
    {
        private Shop pyaterochka;
        public Form1()
        {
            InitializeComponent();
            pyaterochka = new Shop();
        }
        //Кнопка добавления продукта
        private void AddProduct(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            decimal price = numericUpDown1.Value;
            int count = (int)numericUpDown2.Value;
            try
            {
                pyaterochka.CreateProduct(name, price, count);
                UpdateProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Кнопка продажи продукта
        private void SellProduct(object sender, EventArgs e)
        {
            string[] name = textBox2.Text.ToString().Split(' ', ',');
            int[] quantity = { (int)numericUpDown3.Value, (int)numericUpDown4.Value };
            try
            {
                for (int i = 0; i < name.Length; i++)
                    pyaterochka.Sell(name[i], quantity[i]);
                UpdateProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Кнопка удаления продукта
        private void DeleteProduct(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            try 
            {
                pyaterochka.Remove(name);
                UpdateProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Перезапись листа(списка продуктов)
        private void UpdateProductList()
        {
            listBox1.Items.Clear();
            string[] productsInfo = pyaterochka.GetAllProductsInfo().Split('\n');
            foreach (var info in productsInfo)
            {
                listBox1.Items.Add(info);
            }
            label7.Text = pyaterochka.GetProfit();
        }
    }
}
