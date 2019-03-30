using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    class Program
    {
        public static void Main(String[] args)
        {
            DynArray<int> dya = new DynArray<int>();

            for (int i = 0; i < 16; i++)
            {
                dya.Append(i);
            }

            dya.Insert(100, 15);
        }
    }
}
