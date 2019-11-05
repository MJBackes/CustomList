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
    public class AdditionOperatorOverloadTest
    {
        [TestMethod]
        public void PlusOperator_TwoIntListsAdded_ResultHasTheFullContentsOfBothLists()
        {
            //arrange
            CustomList<int> expected = new CustomList<int>();
            expected.Add(1);
            expected.Add(3);
            expected.Add(5);
            expected.Add(2);
            expected.Add(4);
            expected.Add(6);
            CustomList<int> actual;
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(1);
            list1.Add(3);
            list1.Add(5);
            list2.Add(2);
            list2.Add(4);
            list2.Add(6);
            //act
            actual = list1 + list2;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());

        }
        [TestMethod]
        public void PlusOperator_LargerListAddedToSmallerList_ResultantListHasFullContentsOfBothLists()
        {
            //arrange
            CustomList<char> expected = new CustomList<char>();
            expected.Add('a');
            expected.Add('B');
            expected.Add('C');
            expected.Add('D');
            expected.Add('E');
            expected.Add('F');
            CustomList<char> actual;
            CustomList<char> list1 = new CustomList<char>();
            CustomList<char> list2 = new CustomList<char>();
            list1.Add('a');
            list2.Add('B');
            list2.Add('C');
            list2.Add('D');
            list2.Add('E');
            list2.Add('F');
            //act
            actual = list1 + list2;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
