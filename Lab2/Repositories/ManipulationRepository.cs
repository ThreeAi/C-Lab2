using Lab2.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Repositories
{
    internal interface ManipulationRepository<T> 
    {
        public void add(T entity);
        public void remove(int index);
        public IEnumerable<T> Sort(Comparison<T> comparison);
        public IEnumerable<T> Sort();
        public T? Find(Predicate<T> predicate);
        public IEnumerable<T> Filter(Func<T, bool> predicate);
        public void PrintStatistics();
    }
}
