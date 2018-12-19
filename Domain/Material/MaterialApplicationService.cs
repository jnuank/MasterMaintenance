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

        public void Modify(Material target)
        {
            var service = new MaterialService(repository);
            if (!service.IsDuplicatedId(target.Id))
            {
                throw new Exception("IDが存在しません");
            }
            repository.Save(target);
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

            var target = new Material(Id, Name, Type, TypeAndSize, Consumption, Length, Weight);

            var service = new MaterialService(repository);
            if (service.IsDuplicatedId(target.Id))
            {
                throw new Exception("IDが重複しています");
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
            repository.Save(target);
        }
    }
}
