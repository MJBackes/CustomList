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
    public class ZipperTest
    {
        [TestMethod]
        public void ZipperMethod_TwoListsZipped_ContentsInterleaved()
        {
            //arrange
            string expected = "1A2B3C";
            CustomList<char> actual;
            CustomList<char> list1 = new CustomList<char>();
            CustomList<char> list2 = new CustomList<char>();
            list1.Add('1');
            list1.Add('2');
            list1.Add('3');
            list2.Add('A');
            list2.Add('B');
            list2.Add('C');
            //act
            actual = list1.Zip(list2);
            //assert
            Assert.AreEqual(expected, actual.ToString());
        }
        [TestMethod]
        public void ZipperMethod_TwoListsOfUnequalLengthZipped_ContentsInterleavedWithNoEmptySpaces()
        {
            //arrange
            string expected = "1A2B34";
            CustomList<char> actual;
            CustomList<char> list1 = new CustomList<char>();
            CustomList<char> list2 = new CustomList<char>();
            list1.Add('1');
            list1.Add('2');
            list1.Add('3');
            list1.Add('4');
            list2.Add('A');
            list2.Add('B');
            //act
            actual = list1.Zip(list2);
            //assert
            Assert.AreEqual(expected, actual.ToString());
        }
        [TestMethod]
        public void ZipperMethod_PopulatedListZippedWithEmptyList_ReturnsPopulatedListWithNoEmptySpaces()
        {
            //arrange
            string expected = "123";
            CustomList<char> actual;
            CustomList<char> list1 = new CustomList<char>();
            CustomList<char> list2 = new CustomList<char>();
            list1.Add('1');
            list1.Add('2');
            list1.Add('3');
            //act
            actual = list1.Zip(list2);
            //assert
            Assert.AreEqual(expected, actual.ToString());
        }
    }
    }
}
