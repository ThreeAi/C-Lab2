using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    [Serializable]
    internal class Producer : IComparable<Producer>, IEquatable<Producer>
    {
        public string name { init; get; }
        public string country { init; get; }
        public double companyValue { init; get; }

        public Producer(string name, string country, double companyValue)
        {
            this.name = name;
            this.country = country;
            this.companyValue = companyValue;
        }

        public int CompareTo(Producer? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(other, null)) return 1;
            return this.companyValue.CompareTo(other.companyValue);
        }


        public bool Equals(Producer? other)
        {
            if (ReferenceEquals(other, null)) return false;
            return this.name.Equals(other.name);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }

        public static bool operator ==(Producer lhs, Producer rhs) { return lhs.Equals(rhs); }

        public static bool operator !=(Producer lhs, Producer rhs) { return !(lhs == rhs); }

        public static bool operator <(Producer lhs, Producer rhs) { return lhs.companyValue < rhs.companyValue; }

        public static bool operator >(Producer lhs, Producer rhs) { return lhs.companyValue > rhs.companyValue; }

        public override string ToString()
        {
            return $"Producer: name={this.name}, country={this.country}, companyValue={this.companyValue}";
        }
    }
}
