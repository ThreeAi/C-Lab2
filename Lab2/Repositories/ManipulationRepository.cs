using Lab2.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Repositories
{
    internal interface ManipulationRepository<T> 
    {
        public void Add(T entity);
        public void Remove(int index);
        public void Sort(Comparison<T> comparison);
        public void Sort();
        public T? Find(Predicate<T> predicate);
        public IEnumerable<T> Filter(Func<T, bool> predicate);
    }
}
