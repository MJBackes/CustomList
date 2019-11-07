using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCustomList;
namespace CustomListTest
{
    [TestClass]
    public class ReverseTest
    {
        [TestMethod]
        public void Reverse_ListOfInts_OrderIsReversed()
        {
            CustomList<int> list = new CustomList<int> { 8, 3, 5, 7, 1, 2, 5, 4, 9, 6, 5, 8, 3, 5, 6, 3, 2, 4, 6, 7, 3, 5 };
            string expected = "5376423653856945217538";
            string actual;

            list.Reverse();
            actual = list.ToString();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Reverse_ListOfInts_OrderOfSelectedRangeIsReversed()
        {
            CustomList<int> list = new CustomList<int> { 8, 3, 5, 7, 1, 2, 5, 4, 9, 6, 5, 8, 3, 5, 6, 3, 2, 4, 6, 7, 3, 5 };
            string expected = "8357125538569463246735";
            string actual;

            list.Reverse(6,13);
            actual = list.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
