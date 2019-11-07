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
    public class RemoveAllTest
    {
        [TestMethod]
        public void RemoveAll_RemoveAll5sFromListOfIntegers_All5sRemoved()
        {
            CustomList<int> list = new CustomList<int> { 8, 3, 5, 7, 1, 2, 5, 4, 9, 6, 5, 8, 3, 5, 6, 3, 2, 4, 6, 7, 3, 5 };
            string expected = "83712496836324673";
            string actual;

            list.RemoveAll(5);
            actual = list.ToString();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveAll_RemoveAll5sFromListOfIntegers_ReturnValueIsCorrect()
        {
            CustomList<int> list = new CustomList<int> { 8, 3, 5, 7, 1, 2, 5, 4, 9, 6, 5, 8, 3, 5, 6, 3, 2, 4, 6, 7, 3, 5 };
            int expected = 5;
            int actual;


            actual = list.RemoveAll(5);

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void RemoveAll_RemoveAllBsFromListOfChars_CountValueIsCorrect()
        {
            CustomList<char> list2 = new CustomList<char>() { 'c', 'b', 'k', 't', 'b', 'c', 'f', 'a', 'w', 'b', 'y', 'b', 'u', 'r', 'e', 's', 'g' };
            int expected = 13;
            int actual;

            list2.RemoveAll('b');
            actual = list2.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
