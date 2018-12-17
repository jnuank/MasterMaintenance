using System;
namespace Domain.Material
{
    /// <summary>
    /// 部材ドメインサービス
    /// </summary>
    public class MaterialService
    {
        IMaterialRepository repository;

        public MaterialService(IMaterialRepository repository)
        {
            this.repository = repository;
        }

        public bool IsDuplicatedId(MaterialId id)
        {
            Material material = repository.Find(id);

            return material != null;
        }


        public bool IsOverMaterialA()
        {
            var materials = repository.Find(MaterialType.A);

            return materials.Count >= 2;
        }

        public bool IsOverWidthAndPattern(TreadPatternAndWidth ptnAndWidth)
        {
            var materials = repository.Find(ptnAndWidth);

            return materials.Count >= 2;
        }

    }
}
