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
            CustomList<char> list1 = new CustomList<char>();
            CustomList<char> list2 = new CustomList<char>();
            list1.Add('a');
            list1.Add('a');
            list1.Add('a');
            list1.Add('b');
            list1.Add('b');
            list2.Add('a');
            list2.Add('b');
            list2.Add('b');
            list2.Add('c');
            CustomList<char> result = list1 - list2;
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
    }
}
