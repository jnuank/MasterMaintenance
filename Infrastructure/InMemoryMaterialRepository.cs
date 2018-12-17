using System;
using System.Collections.Generic;
using Domain.Material;
using System.Linq;

namespace Infrastructure
{
    public class InMemoryMaterialRepository : IMaterialRepository
    {
        private readonly Dictionary<MaterialId, Material> dataStore = new Dictionary<MaterialId, Material>();

        public Material Find(MaterialId id)
        {
            // バリューオブジェクトにGetHashCode()無いと、ちゃんと機能しない。
            if(dataStore.TryGetValue(id, out var target))
            {
                return target;
            }
            else
            {
                return null;
            }
        }

        public List<Material> Find(MaterialType type)
        {
            return dataStore.Values.Where(x => x.Type == type).ToList();
        }

        public List<Material> Find(TreadPatternAndWidth ptnAndWidth)
        {
            return dataStore.Values.Where(x => x.PatternAndWidth.Equals(ptnAndWidth)).ToList();
        }

        public void Save(Material target)
        {
            dataStore[target.Id] = target;
        }
    }
}
