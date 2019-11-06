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
            Console.WriteLine(list.ToString());
            Console.WriteLine(list[5]);
            Console.ReadLine();
        }
    }
}
