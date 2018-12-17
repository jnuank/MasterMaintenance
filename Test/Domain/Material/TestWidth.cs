using NUnit.Framework;
using System;
using Domain.Material;
namespace Test.Domain.Material
{
    [TestFixture()]
    public class TestWidth
    {
        [Test()]
        public void 正しく値が作成されること()
        {
            var width = new Width(10.0f);
            Assert.AreEqual(10.0, width.Value);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void マイナスの値を入力したらエラーとなること()
        {
            var width = new Width(-0.1f);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void 上限を超える入力をしたらエラーとなること()
        {
            var width = new Width(999.91f);
        }

    }
}
