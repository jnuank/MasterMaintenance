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

        public void Save(Material target)
        {
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

    }
}
