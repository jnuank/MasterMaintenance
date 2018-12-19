using System;
using System.Linq;

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

        // 部材IDが重複しているか
        public bool IsDuplicatedId(MaterialId id)
        {
            Material material = repository.Find(id);

            return material != null;
        }

        // 部材区分Aが2件以上登録されているか
        public bool IsOverAddedMaterialA()
        {
            var materials = repository.Find(MaterialType.A);

            return materials.Count >= 2;
        }

        // 製品種類とサイズの組み合わせが2件以上登録されているか
        public bool IsOverAddedTypeAndSize(TypeAndSize typeAndWidth)
        {
            // 製品種類とサイズの組み合わせが登録されているのは部材区分Bのみ
            var materials = repository.Find(MaterialType.B);

            var count = materials.Count(x => x.TypeAndSize.Equals(typeAndWidth));

            return count >= 2;
        }
    }
}
