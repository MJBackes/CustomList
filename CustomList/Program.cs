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
            CustomList<int> list = new CustomList<int>() { 8, 3, 7, 1, 2, 5, 4, 9, 6, 8, 3, 5, 6, 3, 2, 4, 6, 7, 3, 3, 5, 6, 7, 6, 4, 4 };
            Console.WriteLine(list.ToString());
            list.Sort();
            Console.WriteLine(list.ToString());
            CustomList<char> list2 = new CustomList<char>() { 'c', 'k', 't', 'c', 'f', 'a', 'w', 'b','y','u','r','e','s','g',
                'o','d','j','n','p','z','x','h','i','q','m','l','v','c', 'k', 't', 'c', 'f', 'a', 'w', 'b','y','u','r','e','s','g',
                'o','d','j','n','p','z','x','h','i','q','m','l','v','c', 'k', 't', 'c', 'f', 'a', 'w', 'b','y','u','r','e','s','g',
                'o','d','j','n','p','z','x','h','i','q','m','l','v'};
            Console.WriteLine(list2.ToString());
            list2.Sort();
            Console.WriteLine(list2.ToString());
            CustomList<int> list3 = new CustomList<int>() { 7, 3, 7, 1, 2, 5, 4, 9, 6, 2, 8, 3, 7, 1, 2, 5, 4, 9, 6, 8, 3, 5, 6, 3, 2, 4, 6, 7, 3, 3, 5, 6, 7, 6, 4, 4, 8, 3, 7, 1, 2, 5, 4, 9, 6, 8, 3, 5, 6, 3, 2, 4, 6, 7, 3, 3, 5, 6, 7, 6, 4, 4, 8, 3, 7, 1, 2, 5, 4, 9, 6, 8, 3, 5, 6, 3, 2, 4, 6, 7, 3, 3, 5, 6, 7, 6, 4, 4 };
            Console.WriteLine(list3.ToString());
            list3.Sort();
            Console.WriteLine(list3.ToString());
            Console.ReadLine();
        }
    }
}
