using System;
using System.Collections.Generic;

namespace Domain.Material
{
    public interface IMaterialRepository
    {
        Material Find(MaterialId id);
        List<Material> Find(MaterialType type);
        List<Material> Find(TypeAndSize ptnAndWidth);
        List<Material> FindAll();
        void Save(Material target);
    }
}
