using Lab2.Models;
using Lab2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lab2.Controllers
{
    public class CarController
    {
        private CarService carService = new CarService();
        public void addCar()
        {
            bool isElectric;
            Console.WriteLine("Какой автомобиль хотите добавить?");
            Console.WriteLine("1 – Электрическую");
            Console.WriteLine("2 – Бензиновую");
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '1':
                    isElectric = true;
                    break;
                case '2':
                    isElectric = false;
                    break;
                default:
                    Console.WriteLine("Не правильный ввод");
                    return;
            }
                    Console.WriteLine("Введите параметры автомобиля:");
            Console.Write("Вес: ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Мощность двигателя: ");
            double enginePower = double.Parse(Console.ReadLine());

            Console.Write("Название: ");
            string name = Console.ReadLine();

            Console.Write("Стоимость: ");
            int cost = int.Parse(Console.ReadLine());
            int сapacity;
            if (isElectric) { 
                Console.Write("Емкость батареи: ");
                сapacity = int.Parse(Console.ReadLine());
            }
            else {
                Console.Write("Объем бака: ");
                сapacity = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Введите параметры производителя:");
            Console.Write("Название: ");
            string nameProducer = Console.ReadLine();

            Console.Write("Страна производителя: ");
            string countryProducer = Console.ReadLine();

            Console.Write("Стоимость компании: ");
            int costProducer = int.Parse(Console.ReadLine());

            carService.Add(isElectric ? new ElectricCar(name, weight, enginePower, сapacity, cost, new Producer(nameProducer, countryProducer, costProducer)) :
                new GasolineCar(name, weight, enginePower, сapacity, cost, new Producer(nameProducer, countryProducer, costProducer)));

            Console.WriteLine("Ваш объект записан");
        }

        public void ShowAllCars()
        {
            List<Car> temp = carService.GetAll();
            if (temp.Any())
            {
                Console.WriteLine("Все машины");
                for (int i = 0; i < temp.Count; i++)
                {
                    Console.WriteLine(i + " " + temp[i].ToString());
                }
            }
            else
            {
                Console.WriteLine("Машин нет");
            }
        }

        public void ShowStatistics()
        {
            List<Car> cars = carService.GetAll();
            Console.WriteLine($"Количество имеющихся машин: {cars.Count}");
            Console.WriteLine($"Количество созданых машин: {Car.numberOfCars}");
            Console.WriteLine("Средняя стоимость машины: " + (cars.Any() ? cars.Average(x => x.cost) : ""));
            Console.WriteLine($"Средний вес машины: " + (cars.Any() ? cars.Average(x => x.weight) : ""));
        }

        public void RemoveCar()
        {
            if (carService.GetAll().Any())
            {
                Console.WriteLine("Все машины");
                for (int i = 0; i < carService.GetAll().Count; i++)
                {
                    Console.WriteLine(i + " " + carService[i].ToString());
                }
            }
            else
            {
                Console.WriteLine("Машин нет");
                return;
            }
            Console.WriteLine("Введите индекс объект которого хотите удалить");
            int index = int.Parse(Console.ReadLine());
            carService.Remove(index);
        }

        public void Write()
        {
            if (carService.Write("data.json"))
            {
                Console.WriteLine("Успешно");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }

        public void Read()
        {
            if (carService.Read("data.json"))
            {
                Console.WriteLine("Успешно");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }

        public void CountingTypes()
        {
            Console.WriteLine("Электрических машин = " + carService.GetAll().Count(car => car is ElectricCar));
            Console.WriteLine("Бензиновых машин = " + carService.GetAll().Count(car => car is GasolineCar));
        }

        public void CustomSort()
        {
            Type type = typeof(Car);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            List<FieldInfo> numberFields = new List<FieldInfo>();
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(int) || field.FieldType == typeof(double))
                {
                    numberFields.Add(field);
                }
            }

            Console.WriteLine("Выберите поля сортировки:");
            for (int i = 0; i < numberFields.Count; i++)
            {
                Console.WriteLine($"{i}. {numberFields[i].Name}");
            }

            int choice; 
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > numberFields.Count - 1)
            {
                Console.WriteLine("Ошибка в вводе");
                return;
            }

            FieldInfo chosenField = numberFields[choice];

            int CompareCarsByField(Car x, Car y)
            {
                var val1 = chosenField.GetValue(x)!;
                var val2 = chosenField.GetValue(y)!;
                if (val2 is IComparable comparable)
                {
                    return comparable.CompareTo(val1);
                }
                throw new ArgumentException("Field does not implement IComparable interface.");
            }

            carService.Sort(CompareCarsByField);
        }

        public void CustomFind()
        {
            Type type = typeof(Car);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

            Console.WriteLine("Выберите поле поиска:");
            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine($"{i}. {fields[i].Name}");
            }

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > fields.Length - 1)
            {
                Console.WriteLine("Ошибка в вводе");
                return;
            }

            FieldInfo chosenField = fields[choice];
            Console.WriteLine($"Выбранное поле: {chosenField.Name}");

            Console.WriteLine("Введите значение для сравнения:");
            string value = Console.ReadLine();

            Predicate<Car> predicate = car =>
            {
                object fieldValue = chosenField.GetValue(car);
                if (fieldValue != null && fieldValue.GetType().IsValueType)
                {
                    object valueToCompare = Convert.ChangeType(value, fieldValue.GetType());
                    return fieldValue.Equals(valueToCompare);
                }
                else if (fieldValue != null && fieldValue.GetType() == typeof(string))
                {
                    return fieldValue.Equals(value);
                }
                else
                {
                    return false;
                }
            };
            Console.WriteLine("Найденое значение:");
            Console.WriteLine(carService.Find(predicate));
            return;
        }

        public void CustomFilter()
        {
            Type type = typeof(Car);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            List<FieldInfo> numberFields = new List<FieldInfo>();
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(int) || field.FieldType == typeof(double))
                {
                    numberFields.Add(field);
                }
            }

            Console.WriteLine("Выберите поля фильтрации:");
            for (int i = 0; i < numberFields.Count; i++)
            {
                Console.WriteLine($"{i}. {numberFields[i].Name}");
            }

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > numberFields.Count - 1)
            {
                Console.WriteLine("Ошибка в вводе");
                return;
            }

            FieldInfo chosenField = numberFields[choice];
            double button;
            Console.WriteLine("Введите нижнюю границу");
            double.TryParse(Console.ReadLine(), out button);
            double top;
            Console.WriteLine("Введите вернюю границу");
            double.TryParse(Console.ReadLine(), out top);

            Func<Car, bool> predicate = car =>
            {
                object fieldValue = chosenField.GetValue(car);
                double value = Convert.ToDouble(fieldValue);
                return button <= value && value < top;
            };

            var res = carService.Filter(predicate);
            Console.WriteLine("Результат");
            foreach(var c in res)
            {
                Console.WriteLine(c);
            }
        }
    }
}
