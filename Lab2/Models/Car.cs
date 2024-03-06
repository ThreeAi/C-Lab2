using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    [Serializable]
    internal abstract class Car
    {
        public static int numberOfCars;
        public double weight { init; get; }
        public double enginePower { init; get; }
        public string name { init; get; }
        public int cost { init; get; }
        

        public Car(string name, double weight, double enginePower, int cost)
        {
            this.name = name;
            this.weight = weight;
            this.enginePower = enginePower;
            this.cost = cost;
            numberOfCars++;
        }

        public abstract double mileage();
        public virtual double racing() { return enginePower/weight; }
    }
}
