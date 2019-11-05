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
    public class RemoveMethodTest
    {
        [TestMethod]
        public void RemoveMethod_ObjectIsRemoved_CountIsDecreasedByOne()
        {
            //arrange
            int expected = 0;
            int actual;
            int numberToBeAdded = 0;
            CustomList<int> list = new CustomList<int>();
            list.Add(numberToBeAdded);
            //act
            list.Remove(numberToBeAdded);
            actual = list.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveMethod_ObjectIsRemoved_ReturnValueIsCorrect()
        {
            //arrange
            bool expected = true;
            bool actual;
            int numberToBeAdded = 0;
            CustomList<int> list = new CustomList<int>();
            list.Add(numberToBeAdded);
            //act
            actual = list.Remove(0);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveMethod_ObjectIsStringAndRemoved_ReturnValueIsCorrect()
        {
            //arrange
            bool expected = true;
            bool actual;
            string stringToBeAdded = "Test string.";
            CustomList<string> list = new CustomList<string>();
            list.Add(stringToBeAdded);
            //act
            actual = list.Remove("Test string.");
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveMethod_ObjectToBeRemovedIsNotInList_ReturnValueIsCorrect()
        {
            //arrange
            bool expected = false;
            bool actual;
            int numberToBeAdded = 0;
            CustomList<int> list = new CustomList<int>();
            //act
            actual = list.Remove(5);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveMethod_ObjectIsRemovedFromListWithMultipleObjectsIdenticalToIt_OnlyOneObjectIsRemoved()
        {
            //arrange
            int expected = 3;
            int actual;
            int numberToBeAdded0 = 0;
            int numberToBeAdded1 = 1;
            int numberToBeAdded2 = 3;
            int numberToBeAdded3 = 3;
            CustomList<int> list = new CustomList<int>();
            //act
            list.Add(numberToBeAdded0);
            list.Add(numberToBeAdded1);
            list.Add(numberToBeAdded2);
            list.Add(numberToBeAdded3);
            list.Remove(3);
            actual = list.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveMethod_ObjectIsRemovedFromListWithMultipleObjectsIdenticalToIt_NoEmptySpaceWhereTheRemovedObjectWas()
        {
            //arrange
            int expected = 3;
            int actual;
            int numberToBeAdded0 = 0;
            int numberToBeAdded1 = 1;
            int numberToBeAdded2 = 3;
            int numberToBeAdded3 = 3;
            CustomList<int> list = new CustomList<int>();
            //act
            list.Add(numberToBeAdded0);
            list.Add(numberToBeAdded1);
            list.Add(numberToBeAdded2);
            list.Add(numberToBeAdded3);
            list.Remove(3);
            actual = list[2];
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveMethod_ObjectIsRemovedFromListWithMultpleObjectsIdenticalToIt_OnlyTheFirstInstanceIsRemoved()
        {
            //arrange
            int expected = 3;
            int actual;
            int numberToBeAdded0 = 3;
            int numberToBeAdded1 = 1;
            int numberToBeAdded2 = 2;
            int numberToBeAdded3 = 3;
            CustomList<int> list = new CustomList<int>();
            //act
            list.Add(numberToBeAdded0);
            list.Add(numberToBeAdded1);
            list.Add(numberToBeAdded2);
            list.Add(numberToBeAdded3);
            list.Remove(3);
            actual = list[2];
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
