using Lab2.Models;
using Lab2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services
{
    internal class CarService : ManipulationRepository<Car>
    {
        private List<Car> cars = new List<Car>();
        
        public void add(Car entity)
        {
            cars.Add(entity);
        }

        public IEnumerable<Car> Filter(Func<Car, bool> predicate)
        {
            return cars.Where(predicate).ToList();
        }

        public Car? Find(Predicate<Car> predicate)
        {
            return cars.Find(predicate);
        }

        public void PrintStatistics()
        {
            Console.WriteLine($"Количество имеющихся машин = {cars.Count}");
            Console.WriteLine($"Количество созданых машин = {Car.numberOfCars}");
            Console.WriteLine($"Средняя стоимость машины = {cars.Average(x => x.cost)}");
            Console.WriteLine($"Средняя вес машины = {cars.Average(x => x.weight)}");
        }

        public void remove(int index)
        {
            cars.RemoveAt(index);
        }

        public IEnumerable<Car> Sort(Comparison<Car> comparison)
        {
            List<Car> res = new List<Car>(cars);
            res.Sort(comparison);
            return res;
        }

        public IEnumerable<Car> Sort()
        {
            List<Car> res = new List<Car>(cars);
            res.Sort();
            return res;
        }
    }
}
