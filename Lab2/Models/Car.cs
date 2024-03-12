using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Lab2.Models
{
    internal abstract class Car : IComparable<Car>, IEquatable<Car>
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

        public virtual void Serialize(StreamWriter writer)
        {
            writer.WriteLine($"{{\"weight\":\"{weight}\",\"enginePower\":\"{enginePower}\",\"name\":\"{name}\",\"cost\":\"{cost}\"");
        }
        public virtual double racing() { return enginePower/weight; }

        public int CompareTo(Car? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(other, null)) return 1;
            return this.cost.CompareTo(other.cost);
        }

        public bool Equals(Car? other)
        {
            if (ReferenceEquals(other, null)) return false;
            return this.name.Equals(other.name);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }

        public static bool operator ==(Car lhs, Car rhs) { return lhs.Equals(rhs); }

        public static bool operator !=(Car lhs, Car rhs) { return !(lhs == rhs); }

        public static bool operator <(Car lhs, Car rhs) { return lhs.cost < rhs.cost; }

        public static bool operator >(Car lhs, Car rhs) { return lhs.cost > rhs.cost; }

        public override string ToString()
        {
            return $"ElectricCar: name={this.name}, weight={this.weight}, enginePower={this.enginePower}, cost={this.cost}";
        }
    }
}
