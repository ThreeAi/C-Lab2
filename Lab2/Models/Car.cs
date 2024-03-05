using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    internal abstract class Car
    {
        protected double weight { init; get; }
        protected double enginePower { init; get; }
        protected string name { init; get; }

        public static int numberOfCars;

        public Car(string name, double weight, double enginePower)
        {
            this.name = name;
            this.weight = weight;
            this.enginePower = enginePower;
            numberOfCars++;
        }

        public abstract double mileage();
        public virtual double racing() { return enginePower/weight; }
    }
}
