using System;
using System.Collections.Generic;

namespace Domain.Material
{
    public interface IMaterialRepository
    {
        Material Find(MaterialId id);
        List<Material> Find(MaterialType type);
        List<Material> Find(TreadPatternAndWidth ptnAndWidth);
        void Save(Material target);
    }
}
