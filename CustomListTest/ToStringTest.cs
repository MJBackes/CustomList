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
    public class ToStringTest
    {
        [TestMethod]
        public void ToStringMethod_MethodIsCalled_ListElementsAreConcatenated()
        {
            //arrange
            string expected = "abcd ef";
            string actual;
            CustomList<string> list = new CustomList<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add(" ");
            list.Add("e");
            list.Add("f");
            //act
            actual = list.ToString();
            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
