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
            CustomList<string> stringList = new CustomList<string>();
            stringList.Add("Test");
            stringList.Add("to be removed.");
            stringList.Add("");
            stringList.Add("Test");
            stringList.Add("test");
            Console.WriteLine(stringList.Remove("test"));
            Console.ReadLine();
        }
    }
}
