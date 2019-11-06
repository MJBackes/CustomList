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
            CustomList<char> list = new CustomList<char>();
            list.Add('h');
            list.Add('e');
            list.Add('l');
            list.Add('l');
            list.Add('o');
            list.Add('e');
            list.Remove('e');
            Console.WriteLine(list.Capacity);
            list.Capacity = 12;
            Console.WriteLine(list.Capacity);
            list.Capacity = 2;
            Console.WriteLine(list.Capacity);
            Console.ReadLine();
        }
    }
}
