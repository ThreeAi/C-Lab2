using Lab2.Controllers;
using System;
using System.Runtime.CompilerServices;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRun = true;
            CarController carController = new CarController();
            while (isRun)
            {
                Console.WriteLine("Вариант 3");
                Console.WriteLine("1 – Добавить машину");
                Console.WriteLine("2 – Удалить машину");
                Console.WriteLine("3 – Показать статистику");
                Console.WriteLine("4 – Показать все машины");
                Console.WriteLine("0 - Выход из программы");
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1':
                        carController.addCar();
                        Console.Clear();
                        break;
                    case '2':
                        carController.RemoveCar();
                        Console.Clear();
                        break;
                    case '3':
                        carController.ShowStatistics();
                        Console.Clear();
                        break;
                    case '4':
                        carController.ShowAllCars();
                        Console.Clear();
                        break;
                    case '0':
                        isRun = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, выберите 1, 2, 3 или 0.");
                        Console.Clear();
                        break;
                }
            }

        }
    }
}
