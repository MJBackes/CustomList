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
            CustomList<int> list = new CustomList<int>() { 8, 3, 7, 1, 2, 5, 4, 9, 6 };
            Console.WriteLine(list.ToString());
            list.MoveLargerElementsToTheRightOf(6);
            Console.WriteLine(list.ToString());
            CustomList<char> list2 = new CustomList<char>() { 'c','k','t','c','f','a','w' };
            Console.WriteLine(list2.ToString());
            list2.MoveLargerElementsToTheRightOf(4);
            Console.WriteLine(list2.ToString());
            CustomList<int> list3 = new CustomList<int>() { 7, 3, 7, 1, 2, 5, 4, 9, 6 ,2};
            Console.WriteLine(list3.ToString());
            list3.MoveLargerElementsToTheRightOf(5);
            Console.WriteLine(list3.ToString());
            Console.ReadLine();
        }
    }
}
