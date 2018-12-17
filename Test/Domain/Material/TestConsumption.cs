using NUnit.Framework;
using System;
using Domain.Material;

namespace Test.Domain.Material
{
    [TestFixture()]
    public class TestConsumption
    {
        [Test()]
        public void 正しく値が入力されること()
        {
            var consumption = new Consumption(54.912f);
            Assert.AreEqual(54.912f, consumption.Value);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void ゼロより下回ったらエラーとなること()
        {
            var consumption = new Consumption(-0.1f);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void 上限を上回ったらエラーとなること()
        {
            var consumption = new Consumption(99.91f);
        }
    }
}
