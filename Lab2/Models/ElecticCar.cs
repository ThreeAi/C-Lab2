using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    internal class ElecticCar : Car
    {
        private double batteryCapacity { init; get; }

        public ElecticCar(string name, double weight, double enginePower, double batteryCapacity) 
            : base(name, weight, enginePower)
        {
            this.batteryCapacity = batteryCapacity;
        }

        public override sealed double mileage()
        {
            return this.batteryCapacity * this.enginePower / this.weight;
        }

        public override double racing()
        {
            return this.batteryCapacity * 0.3 * this.enginePower / this.weight;
        }
    }
}
