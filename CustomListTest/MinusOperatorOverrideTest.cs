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
    public class MinusOperatorOverrideTest
    {
        [TestMethod]
        public void MinusOperator_TwoPopulatedLists_CommonElementsRemoved()
        {
            //arrange
            string expected = "1";
            CustomList<int> actual;
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(1);
            list1.Add(3);
            list1.Add(5);
            list2.Add(3);
            list2.Add(5);
            list2.Add(7);
            //act
            actual = list1 - list2;
            //assert
            Assert.AreEqual(expected, actual.ToString());
        }
        [TestMethod]
        public void MinusOperator_EmptyListSubtractedFromPopulatedList_PopulatedListUnchanged()
        {
            //arrange
            string expected = "ABC";
            CustomList<char> actual;
            CustomList<char> list1 = new CustomList<char>();
            CustomList<char> list2 = new CustomList<char>();
            list1.Add('A');
            list1.Add('B');
            list1.Add('C');
            //act
            actual = list1 - list2;
            //assert
            Assert.AreEqual(expected, actual.ToString());
        }
        [TestMethod]
        public void MinusOperator_PopulatedListSubtractedFromEmptyList_ReturnsEmptyList()
        {
            //arrange
            string expected = "";
            CustomList<char> actual;
            CustomList<char> list1 = new CustomList<char>();
            CustomList<char> list2 = new CustomList<char>();
            list2.Add('A');
            list2.Add('B');
            list2.Add('C');
            //act
            actual = list1 - list2;
            //assert
            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
