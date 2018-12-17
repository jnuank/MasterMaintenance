using NUnit.Framework;
using System;
using Domain.Material;
using Domain;
using System.Runtime.InteropServices;

namespace Test
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            var data = MaterialType.A;
            var list = Enumeration.GetAll<MaterialType>();
            var list2 = list.GetEnumerator();
            list2.MoveNext();
            var test = (MaterialType)list2.Current;
            Console.WriteLine(test.Id);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void アルファベット大文字と数字のみであること()
        {
            var pattern = new ProductType("M01あ");
        }
    }
}
