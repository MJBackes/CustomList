using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> ints = new CustomList<int> { 1, 3, 5, 7, 9, 3, 2, 5, 6, 3, 4, 2, 1, };
            int[] intsArray = new int[7];
            CustomList<int> ints2 = ints.FindAll(i => i == 1);
            Console.WriteLine(ints.FindLastIndex(5,2,(i => i == 2)));
            Console.ReadLine();
        }
    }
}
