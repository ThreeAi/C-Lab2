using Lab2.Models;
using Lab2.Repositories;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services
{
    internal class CarService : ManipulationRepository<Car>, DataManipulation<CarService>
    {
        private List<Car> cars = new List<Car>();
        public Car this[int index]
        {
            get
            {
                if (index >= 0 && index < cars.Count)
                {
                    return cars[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }

        public List<Car> GetAll() { return cars; }
        public void Add(Car entity)
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

        public void Remove(int index)
        {
            if (index >= 0 && index < cars.Count)
            {
                cars.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Index out of range");
            }
        }

        public void Sort(Comparison<Car> comparison)
        {
            cars.Sort(comparison);
        }

        public void Sort()
        {
            cars.Sort();
        }

        public void Write(string path)
        {
        }

        public void Read(string path)
        {     
        }

    }
}
