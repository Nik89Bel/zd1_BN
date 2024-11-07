using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Запрашиваем у пользователя имя кота
                Console.WriteLine("Введите имя вашего кота");
                string catname = Console.ReadLine();
                try
                {
                    //Запрашиваем у пользователя вес кота
                    Console.WriteLine("Введите вес вашей кошки");
                    double catweight = Double.Parse(Console.ReadLine());
                    //Создаем новый экземпляр класса Cat с введенными данными
                    Cat mycat = new Cat(catname, catweight);
                    //Вызываем метод Meow для кота
                    mycat.Meow();
                    //Выводим информацию о коте
                    Console.WriteLine($"{mycat.Name} весит {mycat.Weight} кг.");
                } 
                catch
                {
                    //Обрабатываем исключение, если пользователь ввел символы при введение веса кота
                    Console.WriteLine("Введен символ"); 
                }
            }
            catch (ArgumentException ex)
            {
                //Обрабатываем исключение, если пользователь ввел некорректное имя кота или вес
                Console.WriteLine(ex.Message);
            }
        }
    }
}
