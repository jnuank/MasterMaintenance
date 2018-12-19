using System;
using System.Collections.Generic;

namespace Domain.Material
{
    public class MaterialApplicationService
    {
        private IMaterialRepository repository;

        public MaterialApplicationService(IMaterialRepository repository)
        {
            this.repository = repository;
        }

        public Material Find(string id)
        {
            var Id = new MaterialId(id);
            return repository.Find(Id);
        }

        public List<Material> FindTypeA()
        {
            return repository.Find(MaterialType.A);
        }

        public List<Material> FindTypeB()
        {
            return repository.Find(MaterialType.B);
        }

        public void Delete(MaterialId id)
        {
            repository.Delete(id);
        }

        public void Save(string id,
                    string name,
                    int materialTypeId,
                    string productType,
                    float? size,
                    float? consumption,
                    float? length,
                    float? weight)
        {
            var Id = new MaterialId(id);
            var Name = new MaterialName(name);
            var Type = MaterialType.GetMaterialType(materialTypeId);
            var ProductType = new ProductType(productType);
            var Size = new Size(size);
            var TypeAndSize = new TypeAndSize(ProductType, Size);
            var Consumption = new Consumption(consumption);
            var Length = new Length(length);
            var Weight = new Weight(weight);

            // 値個別のバリデーションは、エンティティを生成する時に行う
            var target = new Material(Id, Name, Type, TypeAndSize, Consumption, Length, Weight);

            var service = new MaterialService(repository);

            if (service.IsDuplicatedId(target.Id))
            {
                throw new Exception("IDが重複しています");
            }

            if(Type.Id == MaterialType.A.Id && service.IsOverAddedMaterialA())
            {
                throw new Exception("部材区分Aが2件登録されています"); 
            }

            if(Type.Id == MaterialType.B.Id && service.IsOverAddedTypeAndSize(TypeAndSize))
            {
                throw new Exception(nameof(TypeAndSize.Type.Value) + "と" +
                                    nameof(TypeAndSize.Size.Value) + "の組み合わせは2件登録されています");
            }

            repository.Save(target);
        }

        public void Modify(string id,
              string name,
              int materialTypeId,
              string productType,
              float? size,
              float? consumption,
              float? length,
              float? weight)
        {
            var Id = new MaterialId(id);
            var Name = new MaterialName(name);
            var Type = MaterialType.GetMaterialType(materialTypeId);
            var ProductType = new ProductType(productType);
            var Size = new Size(size);
            var TypeAndSize = new TypeAndSize(ProductType, Size);
            var Consumption = new Consumption(consumption);
            var Length = new Length(length);
            var Weight = new Weight(weight);

            var target = new Material(Id, Name, Type, TypeAndSize, Consumption, Length, Weight);

            var service = new MaterialService(repository);
            if (!service.IsDuplicatedId(target.Id))
            {
                throw new Exception("IDが存在しません");
            }

            if (Type.Id == MaterialType.A.Id && service.IsOverAddedMaterialA())
            {
                throw new Exception("部材区分Aが2件登録されています");
            }

            if (Type.Id == MaterialType.B.Id && service.IsOverAddedTypeAndSize(TypeAndSize))
            {
                throw new Exception(nameof(TypeAndSize.Type.Value) + "と" +
                                    nameof(TypeAndSize.Size.Value) + "の組み合わせは2件登録されています");
            }

            repository.Save(target);
        }
    }
}
