using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitkovDN_01_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ДЕМОНСТРАЦИЯ РАБОТЫ МЕТОДОВ КЛАССОВ ===");
            Console.WriteLine("");

            // создание обьектов класса
            Car.AddObject(new Car("Мерседес", 10000, 13));
            Car.AddObject(new Car("AUDI", 345677, 15));
            Car.AddObject(new CarYear(1998 ,"BMW", 176, 35));
            Car.AddObject(new CarYear(2025 ,"LADA", 10, 11));

            // проверка валидации
            Console.WriteLine("Проверка валидации:");
            var car = new Car("AUDI", 345677, 15);
            var car2 = new Car("AUDI", -345677, 15);
            Console.WriteLine($"Результат валидации: {car.isValid()}");
            Console.WriteLine($"Результат валидации: {car2.isValid()}");
            Console.WriteLine("");

            // вывод списка объектов
            Console.WriteLine("Текущий список объектов:");
            var list = Car.GetList();
            foreach (var i in list)
            {
                i.DisplayInfo();
                Console.WriteLine("");
            }

            Console.WriteLine($"Среднее значение качества по списку: {Car.AvgQ().ToString("F2")}");
            Console.WriteLine("");

            Console.WriteLine("Проверка удаления объекта из списка:");
            Console.WriteLine($"Кол-во объектов до удаления: {Car.GetList().Count}");
            Car.RemoveAt(0);
            Console.WriteLine($"Кол-во объектов после удаления: {Car.GetList().Count}");

            Console.WriteLine("");

            Console.WriteLine("Проверка добавления объекта в список:");
            Console.WriteLine($"Кол-во объектов до добавления: {Car.GetList().Count}");
            Car.AddObject(new Car("AUDI", 345677, 15));
            Console.WriteLine($"Кол-во объектов после добавления: {Car.GetList().Count}");

            Console.WriteLine("");

            Console.WriteLine("Проверка удаления нескольких объектов из списка:");
            Console.WriteLine($"Кол-во объектов до удаления: {Car.GetList().Count}");
            Car.RemoveAt(0,3);
            Console.WriteLine($"Кол-во объектов после удаления: {Car.GetList().Count}");

            Console.WriteLine("");

            Console.WriteLine($"Оставщийся элемент списка: ");
            Car.GetList()[0].DisplayInfo();
            Console.WriteLine("");
            Console.WriteLine("Тестирование заверешено! Спасибо за ванимание!!!");

            return;
        }
    }
}
