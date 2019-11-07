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
            CustomList<int> list = new CustomList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string expected = "123456789987654321123456789";
            string actual;

            list.Reverse(9,9);
            actual = list.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
