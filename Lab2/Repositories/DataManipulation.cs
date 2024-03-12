using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Repositories
{
    internal interface DataManipulation<T>
    {
        public bool Write(string path);
        public bool Read(string path);
    }
}
