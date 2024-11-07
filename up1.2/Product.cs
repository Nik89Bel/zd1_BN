using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up1._2
{
    public class Product
    {
        public decimal Price { get; set; } // Свойство для хранения цены продукта

        public string Name { get; set; } // Свойство для хранения имени продукта

        // Конструктор класса Product
        public Product(string Name, decimal Price)
        {
            this.Name = Name;
            this.Price = Price;
        }

        // Метод для получения информации о продукте
        public string GetInfo()
        {
            return $"Наименование: {Name}; Цена: {Price} руб.";
        }

        // Переопределение метода Equals для сравнения продуктов по значению
        // Для того чтоб метод AddProduct в классе Shop работал корректно
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Product other = (Product)obj;
            return Name == other.Name && Price == other.Price;
        }

        // Переопределение метода GetHashCode для корректного сравнения продуктов в словаре
        // Для того чтоб метод AddProduct в классе Shop работал корректно
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Price.GetHashCode();
        }
    }
}
