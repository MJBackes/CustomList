using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCustomList;
namespace CustomListTest
{
    [TestClass]
    public class IterableTest
    {
        [TestMethod]
        public void GetEnumerator_ForEachLoopIsUsedOnCustomList_LoopsThroughCorrectly()
        {
            //arrnge
            CustomList<int> list1 = new CustomList<int>() { 1, 3, 5, 7 };
            CustomList<int> list2 = new CustomList<int>();
            string expected = "1357";
            string actual;
            //act
            foreach(int i in list1)
            {
                list2.Add(i);
            }
            actual = list2.ToString();
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
