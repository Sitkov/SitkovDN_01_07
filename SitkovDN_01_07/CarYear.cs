using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitkovDN_01_07
{
    public class CarYear : Car // класс наследник
    {
        public int Year { get; set; } // Год (P - дополнительное поле)
        // конструктор класса
        public CarYear(int year, string name, double probeg, double rashod) 
                : base(name, probeg, rashod)
        {
            Year = year;
        }
        // перегрузка метода валидности от базового класса 
        // с добавлением проверки нового поля
        public override bool isValid()
        {
            return base.isValid() && Year > 0;
        }
        // перегрузка расчета качества от базового класса
        public override double CalcQ()
        {
            double Q = base.CalcQ(); // значение от базового класса
            if (Year < 5)
            {
                return Q * 1.15 * Year;
            }
            else
            {
                return Q * 1.7 * Year;
            }
        }
    }
}
