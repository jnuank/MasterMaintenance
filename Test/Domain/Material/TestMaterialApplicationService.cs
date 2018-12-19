using NUnit.Framework;
using System;
using Domain.Material;
using Domain;
using Infrastructure;
using System.Collections.Generic;

namespace Test
{
    [TestFixture()]
    public class TestMaterialApplicationService
    {
        IMaterialRepository repository = new InMemoryMaterialRepository();

        [SetUp()]
        public void Setup()
        {
            var app = new MaterialApplicationService(repository);

            var id = new MaterialId("12345678");
            var name = new MaterialName("mat1");
            var consumption = new Consumption(55.591f);
            var weight = new Weight(30.0f);
            var length = new Length(40.1f);
            var material = Material.CreateMaterialA(id, name, consumption, weight, length);

            app.Save(material);

            var id2 = new MaterialId("00001111");
            var name2 = new MaterialName("mate2");
            var consumption2 = new Consumption(10.1f);
            var weight2 = new Weight(11.2f);
            var length2 = new Length(59.9f);
            var material2 = Material.CreateMaterialA(id2, name2, consumption2, weight2, length2);

            app.Save(material2);


            var id3 = new MaterialId("11112222");
            var name3 = new MaterialName("mate3");
            var pattern3 = new ProductType("M040");
            var width3 = new Size(23.92f);

            var ptnAndWidth3 = new TypeAndSize(pattern3, width3);

            var weight3 = new Weight(20.2f);
            var length3 = new Length(9.2f);
            var material3 = Material.CreateMaterialB(id3, name3, ptnAndWidth3, weight3, length3);

            app.Save(material3);

        }

        [Test()]
        public void 部材を登録する()
        {
            var app = new MaterialApplicationService(repository);

            var id = new MaterialId("19878768");
            var name = new MaterialName("mat1");
            var consumption = new Consumption(55.591f);
            var weight = new Weight(30.0f);
            var length = new Length(40.1f);
            var material = Material.CreateMaterialA(id, name, consumption, weight, length);

            app.Save(material);

            Assert.AreEqual(app.Find(material.Id.Value), material);
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
        public void パターンと幅の組み合わせがイコールになること()
        {
            var pattern = new ProductType("M000");
            var width = new Size(23.92f);

         
            var ptnAndWidth = new TypeAndSize(pattern, width);

            var ptnAndWidth2 = new TypeAndSize(pattern, width);

            Assert.IsTrue(ptnAndWidth.Equals(ptnAndWidth2));

        }

        [Test()]
        public void パターンと幅の組み合わせが一致しないこと()
        {
            var pattern = new ProductType("M000");
            var width = new Size(23.92f);

            var pattern2 = new ProductType("R981");
            var width2 = new Size(12.2f);

            var ptnAndWidth = new TypeAndSize(pattern, width);
            var ptnAndWidth2 = new TypeAndSize(pattern, width2);
            var ptnAndWidth3 = new TypeAndSize(pattern2, width);
            var ptnAndWidth4 = new TypeAndSize(pattern2, width2);

            Assert.IsFalse(ptnAndWidth.Equals(ptnAndWidth2));
            Assert.IsFalse(ptnAndWidth.Equals(ptnAndWidth3));
            Assert.IsFalse(ptnAndWidth.Equals(ptnAndWidth4));
        }

        [Test()]
        public void Idが重複していたらTrueを返す()
        {
            var service = new MaterialService(repository);
            var app = new MaterialApplicationService(repository);

            var id = new MaterialId("12345678");
            var name = new MaterialName("m1");
            var consumption = new Consumption(55.591f);
            var weight = new Weight(30.0f);
            var length = new Length(40.1f);
            var material = Material.CreateMaterialA(id, name, consumption, weight, length);

            var id2 = new MaterialId("12345678");
            var name2 = new MaterialName("m2");
            var consumption2 = new Consumption(10.1f);
            var weight2 = new Weight(11.2f);
            var length2 = new Length(59.9f);
            var material2 = Material.CreateMaterialA(id2, name2, consumption2, weight2, length2);

            app.Save(material);

            bool result = service.IsDuplicatedId(material2.Id);

            Assert.IsTrue(result);
            
        }

        [Test()]
        public void パターンと幅が2つ以上重複していたらTrueを返す()
        {
            var service = new MaterialService(repository);
            var app = new MaterialApplicationService(repository);

            var id = new MaterialId("01010101");
            var name = new MaterialName("m1");
            var ptnWidth = new TypeAndSize(new ProductType("M000"), new Size(23.92f));
            var weight = new Weight(20.2f);
            var length = new Length(9.2f);
            var material = Material.CreateMaterialB(id, name, ptnWidth, weight, length);

            var id2 = new MaterialId("25478900");
            var name2 = new MaterialName("m2");
            var ptnWidth2 = new TypeAndSize(new ProductType("M000"), new Size(23.92f));
            var weight2 = new Weight(12.2f);
            var length2 = new Length(8.2f);
            var material2 = Material.CreateMaterialB(id2, name2, ptnWidth2, weight2, length2);

            app.Save(material);
            app.Save(material2);

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
            app.Save(material);

            // 変更後
            Assert.AreEqual("BUZAI1", app.Find("12345678").Name.Value);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void 消費量を変更する時にnullを渡してエラーする()
        {
            var app = new MaterialApplicationService(repository);
            var material = app.Find("12345678");
            
            material.ChangeConsumption(null);

            app.Save(material);
        }
    }

}
