using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    internal class GasolineCar : Car, IComparable<GasolineCar>, IEquatable<GasolineCar>
    {
        public double tankCapacity { init; get; }
        public Producer producer { init; get; }

        public GasolineCar(string name, double weight, double enginePower, double tankCapacity, int cost, Producer producer)
            : base(name, weight, enginePower, cost)
        {
            this.tankCapacity = tankCapacity;
            this.producer = producer;
        }

        public double mileage()
        {
            return this.tankCapacity * this.enginePower / this.weight;
        }

        public override double racing()
        {
            return this.tankCapacity * 0.3 * this.enginePower / this.weight;
        }

        public int CompareTo(GasolineCar? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(other, null)) return 1;
            return this.cost.CompareTo(other.cost);
        }

        public bool Equals(GasolineCar? other)
        {
            if (ReferenceEquals(other, null)) return false;
            return this.name.Equals(other.name);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }

        public static bool operator ==(GasolineCar lhs, GasolineCar rhs) { return lhs.Equals(rhs); }

        public static bool operator !=(GasolineCar lhs, GasolineCar rhs) { return !(lhs == rhs); }

        public static bool operator <(GasolineCar lhs, GasolineCar rhs) { return lhs.cost < rhs.cost; }

        public static bool operator >(GasolineCar lhs, GasolineCar rhs) { return lhs.cost > rhs.cost; }

        public override string ToString()
        {
            return $"GasolineCar: name={this.name}, weight={this.weight}, enginePower={this.enginePower}, cost={this.cost}, tankCapacity={this.tankCapacity} ({this.producer})";
        }
    }
}
