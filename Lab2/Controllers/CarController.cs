using Lab2.Models;
using Lab2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Controllers
{
    public class CarController
    {
        private CarService carService = new CarService();
        public void addCar()
        {
            Console.WriteLine("Введите параметры автомобиля:");
            Console.Write("Вес: ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Мощность двигателя: ");
            double enginePower = double.Parse(Console.ReadLine());

            Console.Write("Название: ");
            string name = Console.ReadLine();

            Console.Write("Стоимость: ");
            int cost = int.Parse(Console.ReadLine());

            Console.Write("Емкость батареи: ");
            int batteryCapacity = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите параметры производителя:");
            Console.Write("Название: ");
            string nameProducer = Console.ReadLine();

            Console.Write("Страна производителя: ");
            string countryProducer = Console.ReadLine();

            Console.Write("Стоимость компании: ");
            int costProducer = int.Parse(Console.ReadLine());

            carService.Add(new ElecticCar(name, weight, enginePower, batteryCapacity, cost, new Producer(nameProducer, countryProducer, costProducer)));

            Console.WriteLine("Ваш объект записан (нажмите любую кнопку)");
        }

        public void ShowAllCars()
        {
            List<Car> temp = carService.GetAll();
            if (temp.Any())
            {
                Console.WriteLine("Все машины");
                for (int i = 0; i < temp.Count; i++)
                {
                    Console.WriteLine(i + temp[i].ToString());
                }
            }
            else
            {
                Console.WriteLine("Машин нет");
            }
            Console.WriteLine("Нажмите любую кнопку для продолжения");
            Console.ReadKey();
            
        }

        public void ShowStatistics()
        {
            List<Car> cars = carService.GetAll();
            Console.WriteLine($"Количество имеющихся машин: {cars.Count}");
            Console.WriteLine($"Количество созданых машин: {Car.numberOfCars}");
            Console.WriteLine("Средняя стоимость машины: " + (cars.Any() ? cars.Average(x => x.cost) : ""));
            Console.WriteLine($"Средний вес машины: " + (cars.Any() ? cars.Average(x => x.weight) : ""));
            Console.WriteLine("Нажмите любую кнопку для продолжения");
            Console.ReadKey();
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
                Console.WriteLine("Нажмите любую кнопку для продолжения");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Введите индекс объект которого хотите удалить");
            int index = int.Parse(Console.ReadLine());
            carService.Remove(index);
            Console.WriteLine("Нажмите любую кнопку для продолжения");
            Console.ReadKey();
        }

        public void Write()
        {
            carService.Write("data.dat");
        }


    }
}
