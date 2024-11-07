using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace up1._2
{
    public class Shop
    {
        private Dictionary<Product, int> products; // Словарь для хранения продуктов и их количества
        private decimal profit; // Прибыль магазина

        // Конструктор класса Shop
        public Shop()
        {
            products = new Dictionary<Product, int>();
            profit = 0;
        }

        // Метод для добавления продукта в магазин
        public void AddProduct(Product product, int count)
        {
            if (products.ContainsKey(product))
                // Если продукт уже существует, увеличиваем его количество
                products[product] += count;
            else
            {
                if (FindByName(product.Name) != null)
                    //Если продукт не существует, но существует продукт с таким именем, выводим сообщение об ошибки
                    throw new Exception("Продукт с таким именем уже существует!\nПроверьте введеные вами данные");
                // Если продукт не существует, добавляем его в словарь
                products.Add(product, count);
            }
        }

        // Метод для создания нового продукта и добавления его в магазин
        public void CreateProduct(string name, decimal price, int count)
        {
            if (name != "" && name != " ")
            {
                Product product = new Product(name, price);
                AddProduct(product, count);
            }
            else
                throw new Exception("Введите имя!");
        }

        // Метод для получения информации о всех продуктах в магазине
        public string GetAllProductsInfo()
        {
            string info = "";
            foreach (var product in products)
            {
                info += product.Key.GetInfo() + "; Количество: " + product.Value + "\n";
            }
            return info;
        }

        // Метод для получения текущей прибыли магазина
        public string GetProfit()
        {
            return $"{profit} руб.";
        }

        // Метод для продажи продукта по экземпляру
        public void Sell(Product product, int quantity)
        {
            if (products.ContainsKey(product))
            {
                if (products[product] < quantity)
                    throw new Exception("Недостаточно товара в наличии!");
                else
                {
                    products[product] -= quantity;
                    profit += product.Price * quantity;
                }
            }
            else
                throw new Exception("Товар не найден!");
            {
            //    if (products.ContainsKey(product1) || products.ContainsKey(product2))
            //    {
            //        if (products[product1] < quantity1 || products[product2] < quantity2)
            //            throw new Exception("Недостаточно товаров в наличии!");
            //        else
            //        {
            //            products[product1] -= quantity1;
            //            profit += product1.Price * quantity1;
            //        }
            //    }
            //    else
            //        throw new Exception("Один из товаров не найден!");
            }
        }

        // Метод для продажи продукта по имени
        public void Sell(string productName, int quantity)
        {
            Product toSell = FindByName(productName);
            if (toSell != null)
                Sell(toSell, quantity);
            else
                throw new Exception("Товар не найден!");
        }

        // Метод для поиска продукта по имени
        public Product FindByName(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                    return product;
            }
            return null;
        }

        // Метод для удаления продукта из списка
        public void Remove(string productName)
        {
            Product toDel = FindByName(productName);
            if (toDel != null)
                products.Remove(toDel);
            else
                throw new Exception("Товар не найден!");
        }
    }
}
