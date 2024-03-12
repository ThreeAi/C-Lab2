using Lab2.Models;
using Lab2.Repositories;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public List<Car> Filter(Func<Car, bool> predicate)
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
                throw new IndexOutOfRangeException("Index out of range");
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

        public bool Write(string path)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };
                string json = JsonConvert.SerializeObject(cars, settings);
                Console.WriteLine(json);
                StreamWriter file = File.CreateText(path);
                file.WriteLine(json);
                file.Close();
                return true;
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            
        }

        public bool Read(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    };
                    string data = File.ReadAllText(path);
                    cars = JsonConvert.DeserializeObject<List<Car>>(data, settings);
                    return true;
                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
        }
    }
}
