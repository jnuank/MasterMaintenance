using NUnit.Framework;
using System;
using Domain.Material;
using Infrastructure;
using System.Collections.Generic;

namespace Test
{
    [TestFixture()]
    public class TestMaterialApplicationService
    {
        IMaterialRepository repository = new InMemoryMaterialRepository();

        [Test()]
        public void 部材を登録する()
        {
            var app = new MaterialApplicationService(repository);

            var id = new MaterialId("12345678");
            var consumption = new Consumption(55.591f);
            var weight = new Weight(30.0f);
            var length = new Length(40.1f);
            var material = Material.CreateMaterialA(id, consumption, weight, length);

            app.Save(material);

            Assert.AreEqual(app.Find(material.Id.Value), material);
        }

        [Test()]
        public void 部材区分Aをすべて取得する()
        {
            var app = new MaterialApplicationService(repository);

            var id = new MaterialId("12345678");
            var consumption = new Consumption(55.591f);
            var weight = new Weight(30.0f);
            var length = new Length(40.1f);
            var material = new MaterialA(id, consumption, weight, length);

            var id2 = new MaterialId("00001111");
            var consumption2 = new Consumption(10.1f);
            var weight2 = new Weight(11.2f);
            var length2 = new Length(59.9f);
            var material2 = new MaterialA(id2, consumption2, weight2, length2);

            var id3 = new MaterialId("11112222");
            var pattern3 = new TreadPattern("M000");
            var width3 = new Width(23.92f);

            var ptnAndWidth3 = new TreadPatternAndWidth(pattern3, width3);


            var weight3 = new Weight(20.2f);
            var length3 = new Length(9.2f);
            var material3 = new MaterialB(id3, ptnAndWidth3, weight3, length3);

            app.Save(material);
            app.Save(material2);
            app.Save(material3);

            List<Material> result = app.FindTypeA();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("12345678", result[0].Id.Value);
            Assert.AreEqual("00001111", result[1].Id.Value);
        }

        [Test()]
        public void 部材区分Bをすべて取得する()
        {
            var app = new MaterialApplicationService(repository);

            var id = new MaterialId("12345678");
            var consumption = new Consumption(55.591f);
            var weight = new Weight(30.0f);
            var length = new Length(40.1f);
            var material = new MaterialA(id, consumption, weight, length);

            var id2 = new MaterialId("00001111");
            var consumption2 = new Consumption(10.1f);
            var weight2 = new Weight(11.2f);
            var length2 = new Length(59.9f);
            var material2 = new MaterialA(id2, consumption2, weight2, length2);

            var id3 = new MaterialId("11112222");
            var pattern3 = new TreadPattern("M000");
            var width3 = new Width(23.92f);
            var ptnWidth3 = new TreadPatternAndWidth(pattern3, width3);
            var weight3 = new Weight(20.2f);
            var length3 = new Length(9.2f);
            var material3 = new MaterialB(id3, ptnWidth3, weight3, length3);

            app.Save(material);
            app.Save(material2);
            app.Save(material3);

            List<Material> result = app.FindTypeB();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("11112222", result[0].Id.Value);
        }

        [Test()]
        public void パターンと幅の組み合わせがイコールになること()
        {
            var pattern = new TreadPattern("M000");
            var width = new Width(23.92f);

         
            var ptnAndWidth = new TreadPatternAndWidth(pattern, width);

            var ptnAndWidth2 = new TreadPatternAndWidth(pattern, width);

            Assert.IsTrue(ptnAndWidth.Equals(ptnAndWidth2));

        }

        [Test()]
        public void パターンと幅の組み合わせが一致しないこと()
        {
            var pattern = new TreadPattern("M000");
            var width = new Width(23.92f);

            var pattern2 = new TreadPattern("R981");
            var width2 = new Width(12.2f);

            var ptnAndWidth = new TreadPatternAndWidth(pattern, width);
            var ptnAndWidth2 = new TreadPatternAndWidth(pattern, width2);
            var ptnAndWidth3 = new TreadPatternAndWidth(pattern2, width);
            var ptnAndWidth4 = new TreadPatternAndWidth(pattern2, width2);

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
            var consumption = new Consumption(55.591f);
            var weight = new Weight(30.0f);
            var length = new Length(40.1f);
            var material = new MaterialA(id, consumption, weight, length);

            var id2 = new MaterialId("12345678");
            var consumption2 = new Consumption(10.1f);
            var weight2 = new Weight(11.2f);
            var length2 = new Length(59.9f);
            var material2 = new MaterialA(id2, consumption2, weight2, length2);

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
            var ptnWidth = new TreadPatternAndWidth(new TreadPattern("M000"), new Width(23.92f));
            var weight = new Weight(20.2f);
            var length = new Length(9.2f);
            var material = new MaterialB(id, ptnWidth, weight, length);

            var id2 = new MaterialId("25478900");
            var ptnWidth2 = new TreadPatternAndWidth(new TreadPattern("M000"), new Width(23.92f));
            var weight2 = new Weight(12.2f);
            var length2 = new Length(8.2f);
            var material2 = new MaterialB(id2, ptnWidth2, weight2, length2);

            app.Save(material);
            app.Save(material2);

            var ptn = new TreadPattern("M000");
            var wid = new Width(23.92f);

            bool result = service.IsOverWidthAndPattern(new TreadPatternAndWidth(ptn ,wid));

            Assert.IsTrue(result);
        }

        [Test()]
        public void 部材Aが2つ以上あったらTrueを返す()
        {
            var app = new MaterialApplicationService(repository);
            var service = new MaterialService(repository);

            var id = new MaterialId("12345678");
            var consumption = new Consumption(55.591f);
            var weight = new Weight(30.0f);
            var length = new Length(40.1f);
            var material = new MaterialA(id, consumption, weight, length);

            var id2 = new MaterialId("00001111");
            var consumption2 = new Consumption(10.1f);
            var weight2 = new Weight(11.2f);
            var length2 = new Length(59.9f);
            var material2 = new MaterialA(id2, consumption2, weight2, length2);

            app.Save(material);
            app.Save(material2);
            

            bool result = service.IsOverMaterialA();

            Assert.IsTrue(result);
        }
    }

}
