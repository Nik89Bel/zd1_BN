using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up1
{
    class Cat
    {
        private string name; //Скрытое поле для имени
        private double weight; //Скрытое поле для веса
        //Свойство Name для доступа к имени кота с проверкой на корректность
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (IsNameValid(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException($"{value} - неправильное имя!!!");
                }
            }
        }
        //Свойство Weight для доступа к весу кота с проверкой на корректность
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (IsWeightValid(value))
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException($"{value} - неправильный вес!!!");
                }
            }
        }
        //Конструктор класса Cat
        public Cat(string catName, double catWeight)
        {
            Name = catName;
            Weight = catWeight;
        }
        //Метод для проверки корректности имени
        private bool IsNameValid(string name)
        {
            foreach (var ch in name)
            {
                //Проверка символа имени кота на букву 
                if (!char.IsLetter(ch))
                {
                    return false;
                }
            }
            return true;
        }
        //Метод для проверки корректности веса
        private bool IsWeightValid(double weight)
        {
            return weight > 0;
        }
        //Метод для "мяуканья" кота
        public void Meow()
        {
            Console.WriteLine($"{name}: МЯЯЯЯУ!!!!");
        }
    }
}
