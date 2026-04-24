using SitkovDN_01_07;

namespace CarTests
{
    public class CarTest
    {
        // конуструктор (перед запуском каждого теста)
        public CarTest()
        {
            Car.GetList().Clear();
        }

        // проверка валидного объекта от базового класса
        [Fact]
        public void Test_IsValide_BaseCar_ReturnsTrue()
        {
            var car = new Car("БМВ", 25000, 10);
            Assert.True(car.isValid());
        }
        // проверка невалидного объекта от базового класса
        [Fact]
        public void Test_IsValide_BaseCar_ReturnsFalse()
        {
            var car = new Car("БМВ", 25000, -1);
            Assert.False(car.isValid());
        }
        // проверка валидного объекта от класса наследника
        [Fact]
        public void Test_IsValide_YearCar_ReturnsTrue()
        {
            var car = new CarYear(2000, "БМВ", 25000, 10);
            Assert.True(car.isValid());
        }
        // проверка невалидного объекта от класса наследника
        [Fact]
        public void Test_IsValide_YearCar_ReturnsFalse()
        {
            var car = new CarYear(-100, "БМВ", 25000, 10);
            Assert.False(car.isValid());
        }
        // расчет качества на валидном объекте
        [Fact]
        public void Test_BaseCarCalcQ_Correct()
        {
            var car = new Car("БМВ", 25000, 10);
            Assert.Equal(2500, car.CalcQ());
        }
        // расчет перегрузки качества от класса наследника на валидном объекте
        [Fact]
        public void Test_YearCarCalcQ_Correct()
        {
            var car = new CarYear(2000, "БМВ", 25000, 10);
            Assert.Equal(8500000, car.CalcQ());
        }

        // проверка граничных значений по перегрузке расчета качества
        [Theory]
        [InlineData(0,0)]
        [InlineData(3,8625)]
        [InlineData(5,21250)]
        [InlineData(7,29750)]
        public void Test_CheckBarerNum_CarYearCalcQ(int p, double ozhidaemoe)
        {
            var car = new CarYear(p, "БМВ", 25000, 10);
            Assert.Equal(ozhidaemoe, car.CalcQ());
        }
        // добавление объекта
        [Fact]
        public void Test_CheckAddObject_Correct()
        {
            Car.AddObject(new CarYear(2000, "БМВ", 25000, 10));
            Assert.Equal(1, Car.GetList().Count);
        }
        // проверка на добавление только валидных объектов
        [Fact]
        public void Test_CheckAddValidObject_Correct()
        {
            Car.AddObject(new CarYear(2000, "БМВ", 25000, 10));
            Car.AddObject(new CarYear(-2000, "БМВ", 25000, 10));
            Assert.Equal(1, Car.GetList().Count);
        }
        // удаление объекта из списка
        [Fact]
        public void Test_CheckRemoveObject_Correct()
        {
            Car.AddObject(new CarYear(2000, "БМВ", 25000, 10));
            Car.AddObject(new CarYear(2000, "БМВ", 25000, 10));

            Car.RemoveAt(0);

            Assert.Equal(1, Car.GetList().Count);
        }
        // удаление нескольких объектов из списка
        [Fact]
        public void Test_CheckRemoveRangeObject_Correct()
        {
            Car.AddObject(new CarYear(2000, "БМВ", 25000, 10));
            Car.AddObject(new CarYear(2000, "БМВ", 25000, 10));
            Car.AddObject(new CarYear(2000, "БМВ", 25000, 10));
            Car.AddObject(new CarYear(2000, "БМВ", 25000, 10));

            Car.RemoveAt(0, 2);

            Assert.Equal(2, Car.GetList().Count);
        }
        // проверка корректности расчета среднего 
        [Fact]
        public void Test_CheckAvgQonList_Correct()
        {
            Car.AddObject(new CarYear(2000, "БМВ", 20000, 100));
            Car.AddObject(new CarYear(2000, "БМВ", 2500, 150));
            Car.AddObject(new CarYear(2000, "БМВ", 2000, 100));
            Car.AddObject(new CarYear(2000, "БМВ", 250, 150));

            Assert.Equal(202583.33, Car.AvgQ(), 2);
        }
    }
}