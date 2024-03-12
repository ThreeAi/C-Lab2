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
                Console.WriteLine("Вариант 2");
                Console.WriteLine("1 – Добавить машину");
                Console.WriteLine("2 – Удалить машину");
                Console.WriteLine("3 – Показать статистику");
                Console.WriteLine("4 – Показать все машины");
                Console.WriteLine("5 – Подсчет типов");
                Console.WriteLine("6 – Кастомная сортировка");
                Console.WriteLine("7 - Кастомный поиск");
                Console.WriteLine("8 - Поиск по фильтру");
                Console.WriteLine("9 – Запись в файл");
                Console.WriteLine("10 – Чтение из файла");
                Console.WriteLine("0 - Выход из программы");
                switch (Console.ReadLine())
                {
                    case "1":
                        carController.addCar();
                        Clear();
                        break;
                    case "2":
                        carController.RemoveCar();
                        Clear();
                        break;
                    case "3":
                        carController.ShowStatistics();
                        Clear();
                        break;
                    case "4":
                        carController.ShowAllCars();
                        Clear();
                        break;
                    case "5":
                        carController.CountingTypes();
                        Clear();
                        break;
                    case "6":
                        carController.CustomSort();
                        Clear();
                        break;
                    case "7":
                        carController.CustomFind();
                        Clear();
                        break;
                    case "8":
                        carController.CustomFilter();
                        Clear();
                        break;
                    case "9":
                        carController.Write();
                        Clear();
                        break;
                    case "10":
                        carController.Read();
                        Clear();
                        break;
                    case "0":
                        isRun = false;
                        Clear();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, выберите 1, 2, 3 или 0.");
                        Clear();
                        break;
                }
            }

        }

        public static void Clear()
        {
            Console.WriteLine("Нажмите любую кнопку для продолжения");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
