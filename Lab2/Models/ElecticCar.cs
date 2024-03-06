using Lab2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    [Serializable]
    internal class ElecticCar : Car, IComparable<ElecticCar>, IEquatable<ElecticCar>
    {
        public double batteryCapacity { init; get; }
        public Producer producer { init; get; }

        public ElecticCar(string name, double weight, double enginePower, double batteryCapacity, int cost, Producer producer) 
            : base(name, weight, enginePower, cost)
        {
            this.batteryCapacity = batteryCapacity;
            this.producer = producer;
        }

        public override sealed double mileage()
        {
            return this.batteryCapacity * this.enginePower / this.weight;
        }

        public override double racing()
        {
            return this.batteryCapacity * 0.3 * this.enginePower / this.weight;
        }

        public int CompareTo(ElecticCar? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(other, null)) return 1;
            return this.cost.CompareTo(other.cost);
        }

        public bool Equals(ElecticCar? other)
        {
            if (ReferenceEquals(other, null)) return false;
            return this.name.Equals(other.name);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }

        public static bool operator ==(ElecticCar lhs, ElecticCar rhs) { return lhs.Equals(rhs); }

        public static bool operator !=(ElecticCar lhs, ElecticCar rhs) { return !(lhs == rhs); }

        public static bool operator <(ElecticCar lhs, ElecticCar rhs) { return lhs.cost < rhs.cost; }

        public static bool operator >(ElecticCar lhs, ElecticCar rhs) { return lhs.cost > rhs.cost; }

        public override string ToString()
        {
            return $"ElectricCar: name={this.name}, weight={this.weight}, enginePower={this.enginePower}, cost={this.cost}, ({this.producer})";
        }
    }
}
