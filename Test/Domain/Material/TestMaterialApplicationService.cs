using NUnit.Framework;
using System;
using Domain.Material;
using Domain;
using Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestFixture()]
    public class TestMaterialApplicationService
    {
        IMaterialRepository repository = new InMemoryMaterialRepository();

        [TestFixtureSetUp()]
        public void Setup()
        {
            var app = new MaterialApplicationService(repository);

            app.Save("12345678", "mat1", 0, null, null, 55.591f, 40.1f, 30.0f);
            app.Save("00001111", "mate2", 0, null, null, 10.1f, 59.9f, 11.2f);
            app.Save("11112222", "mate3", 1, "M040", 23.92f, null, 9.2f, 20.0f);
        }

        [Test()]
        public void 部材を登録する()
        {
            var app = new MaterialApplicationService(repository);

            app.Save("19878768", "mat1", 0, null, 0.0f, 55.591f, 40.1f, 30.0f);

            Assert.AreEqual("mat1", app.Find("19878768").Name.Value);
        }

        [Test()]
        public void 部材区分Aをすべて取得する()
        {
            var app = new MaterialApplicationService(repository);

            List<Material> result = app.FindTypeA();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("12345678", result[0].Id.Value);
            Assert.AreEqual("00001111", result[1].Id.Value);
        }

        [Test()]
        public void 部材区分Bをすべて取得する()
        {
            var app = new MaterialApplicationService(repository);

            List<Material> result = app.FindTypeB();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("11112222", result[0].Id.Value);
        }

        [Test()]
        [ExpectedException(typeof(Exception))]
        public void Idが重複していたらExceptionを返す()
        {
            var service = new MaterialService(repository);
            var app = new MaterialApplicationService(repository);

            app.Save("12345678", "m1", 0, null, null, 55.591f, 40.1f, 30.0f);
        }

        [Test()]
        public void パターンと幅が2つ以上重複していたらTrueを返す()
        {
            var service = new MaterialService(repository);
            var app = new MaterialApplicationService(repository);

            app.Save("01010101", "m1", 1, "M000", 23.92f, null, 9.2f, 20.2f);
            app.Save("25478900", "m2", 1, "M000", 23.92f, null, 8.2f, 12.2f);

            var ptn = new ProductType("M000");
            var wid = new Size(23.92f);

            bool result = service.IsOverAddedTypeAndSize(new TypeAndSize(ptn ,wid));

            Assert.IsTrue(result);
        }

        [Test()]
        public void 部材Aが2つ以上あったらTrueを返す()
        {
            var app = new MaterialApplicationService(repository);
            var service = new MaterialService(repository);

            bool result = service.IsOverAddedMaterialA();

            Assert.IsTrue(result);
        }

        [Test()]
        public void 部材の名称を変更する()
        {
            var app = new MaterialApplicationService(repository);
            var material = app.Find("12345678");

            // 変更前
            Assert.AreEqual("mat1", material.Name.Value);

            var name = new MaterialName("BUZAI1");
            material.ChangeName(name);
            app.Modify(material.Id.Value,
                   "BUZAI1",
                   material.Type.Id,
                   material.TypeAndSize.Type.Value,
                   material.TypeAndSize.Size.Value,
                   material.Consumption.Value,
                   material.Length.Value,
                   material.Weight.Value);

            // 変更後
            Assert.AreEqual("BUZAI1", app.Find("12345678").Name.Value);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void 消費量を変更する時にnullを渡してエラーする()
        {
            var app = new MaterialApplicationService(repository);
            // ↓これはおかしいのか。
            var material = app.Find("12345678");

            app.Modify(material.Id.Value,
                    material.Name.Value,
                    material.Type.Id,
                    material.TypeAndSize.Type.Value,
                    material.TypeAndSize.Size.Value,
                    null,
                    material.Length.Value,
                    material.Weight.Value);
        }

        [Test()]
        public void 部材を削除する()
        {
            var app = new MaterialApplicationService(repository);
            var id = new MaterialId("12345678");

            app.Delete(id);

            Assert.AreEqual(null, app.Find("12345678"));
        }
    }
}
