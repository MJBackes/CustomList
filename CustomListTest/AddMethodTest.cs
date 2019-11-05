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
    public class AddMethodTest
    {
        [TestMethod]
        public void AddMethod_ObjectIsAdded_CountIncreasesByOne()
        {
            //arrange
            int expected = 1;
            int actual;
            int numberToBeAdded = 0;
            CustomList<int> list = new CustomList<int>();

            //act
            list.Add(numberToBeAdded);
            actual = list.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddMethod_ObjectIsAddedBelowCapacity_CapacityIsUnchanged()
        {
            //arrange
            int expected = 4;
            int actual;
            int numberToBeAdded = 0;
            CustomList<int> list = new CustomList<int>();
            //act
            list.Add(numberToBeAdded);
            actual = list.Capacity;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddMethod_ObjectIsAddedToBringCountEqualToCapacity_CapacityIsUnchanged()
        {
            //arrange
            int expected = 4;
            int actual;
            int numberToBeAdded0 = 0;
            int numberToBeAdded1 = 1;
            int numberToBeAdded2 = 2;
            int numberToBeAdded3 = 3;
            CustomList<int> list = new CustomList<int>();
            //act
            list.Add(numberToBeAdded0);
            list.Add(numberToBeAdded1);
            list.Add(numberToBeAdded2);
            list.Add(numberToBeAdded3);
            actual = list.Capacity;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddMethod_ObjectIsAddedWhenAtCapacity_CapacityIsDoubled()
        {
            //arrange
            int expected = 8;
            int actual;
            int numberToBeAdded0 = 0;
            int numberToBeAdded1 = 1;
            int numberToBeAdded2 = 2;
            int numberToBeAdded3 = 3;
            int numberToBeAdded4 = 4;
            CustomList<int> list = new CustomList<int>();
            //act
            list.Add(numberToBeAdded0);
            list.Add(numberToBeAdded1);
            list.Add(numberToBeAdded2);
            list.Add(numberToBeAdded3);
            list.Add(numberToBeAdded4);
            actual = list.Capacity;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddMethod_ObjectIsAddedWhenAtCapacity_CountIsIncreasedByOne()
        {
            //arrange
            int expected = 5;
            int actual;
            int numberToBeAdded0 = 0;
            int numberToBeAdded1 = 1;
            int numberToBeAdded2 = 2;
            int numberToBeAdded3 = 3;
            int numberToBeAdded4 = 4;
            CustomList<int> list = new CustomList<int>();
            //act
            list.Add(numberToBeAdded0);
            list.Add(numberToBeAdded1);
            list.Add(numberToBeAdded2);
            list.Add(numberToBeAdded3);
            list.Add(numberToBeAdded4);
            actual = list.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
