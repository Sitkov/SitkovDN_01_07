using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitkovDN_01_07
{
    public class Car // базовый класс
    {
        public string Name { get; set; } // Марка автомобиля
        public double Probeg { get; set; } // Пробег автомобиля
        public double Rashod { get; set; } // Расход автомобиля 

        // приватный статический список объектов
        private static List<Car> listCar = new List<Car>();

        // конструктор класса
        public Car(string name, double probeg, double rashod) 
        {
            Name = name;
            Probeg = probeg;
            Rashod = rashod;
        }

        // проверка валидации
        public virtual bool isValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && Probeg > 0 && Rashod > 0;
        }
        // расчет качества
        public virtual double CalcQ()
        {
            return Probeg / Rashod;
        }
        // вывод информации о объекте
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Марка: {Name}; \n" +
                              $"Пробег: {Probeg}; \n" +
                              $"Расход: {Rashod}; \n" +
                              $"Качество: {CalcQ().ToString("F2")}");
        }
        // добавление объекта в список (только валидные объекты)
        public static void AddObject(Car car)
        {
            if (car.isValid())
            {
                listCar.Add(car);
            }
        }
        // удаление из списка по позиции объекта
        public static void RemoveAt(int index)
        {
            if (index >= 0 && index <= listCar.Count)
            {
                listCar.RemoveAt(index);
            }
        }
        // удаление нескольких объектов из списка
        public static void RemoveAt(int index,int count)
        {
            if (index >= 0 && index + count <= listCar.Count)
            {
                listCar.RemoveRange(index, count);
            }
        }
        // расчет среднего занчения "качества" по списку объектов
        public static double AvgQ()
        {
            return listCar.Average(c => c.CalcQ());
        }

        public static List<Car> GetList() => listCar;
    }
}
