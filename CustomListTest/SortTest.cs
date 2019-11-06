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
    public class SortTest
    {
        [TestMethod]
        public void SortMethod_CollectionOfRandomInts_SortedLowToHigh()
        {
            CustomList<int> list = new CustomList<int>() { 8, 3, 7, 1, 2, 5, 4, 9, 6 };
            string expected = "123456789";
            string actual;

            list.Sort();
            actual = list.ToString();

            Assert.AreEqual(expected, actual);
            
        }
        [TestMethod]
        public void SortMethod_CollectionPreSortedChars_OrderUnchanged()
        {
            CustomList<char> list = new CustomList<char>() { 'a','b','c','d','e','f' };
            string expected = "abcdef";
            string actual;

            list.Sort();
            actual = list.ToString();

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void SortMethod_CollectionOfRandomIntsWithRepeats_SortedLowToHigh()
        {
            CustomList<int> list = new CustomList<int>() { 8, 3, 6, 7, 1, 2, 5, 4, 2, 9, 6 };
            string expected = "12234566789";
            string actual;

            list.Sort();
            actual = list.ToString();

            Assert.AreEqual(expected, actual);

        }
    }
}
