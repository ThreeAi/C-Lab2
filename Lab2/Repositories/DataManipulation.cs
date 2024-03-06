using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Repositories
{
    internal interface DataManipulation<T>
    {
        public void Write(string path);
        public void Read(string path);
    }
}
