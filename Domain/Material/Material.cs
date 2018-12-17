using System;
namespace Domain.Material
{
    /// <summary>
    /// 部材クラス
    /// </summary>
    public class Material
    {
        public MaterialId Id { get; private set; }
        public MaterialName Name { get; private set; }
        public MaterialType Type { get; private set; }
        public TypeAndSize TypeAndSize { get; private set; }
        public Consumption Consumption { get; private set; }
        public Length Length { get; private set; }
        public Weight Weight { get; private set; }

        // コンストラクタはprivateにしておき、外部からインスタンス化させない
        private Material(MaterialId id,
                        MaterialName name,
                        MaterialType type,
                        TypeAndSize typesize,
                        Consumption consumption,
                        Length length,
                        Weight weight)
        {
            if (id == null) throw new ArgumentNullException(nameof(MaterialId));
            if (name == null) throw new ArgumentNullException(nameof(MaterialName));
            if (type == null) throw new ArgumentNullException(nameof(MaterialType));
            if (length == null) throw new ArgumentNullException(nameof(Length));
            if (weight == null) throw new ArgumentNullException(nameof(Weight));

            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.TypeAndSize = typesize;
            this.Consumption = consumption;
            this.Length = length;
            this.Weight = weight;
        }

        // 部材Aを生成する
        public static Material CreateMaterialA(MaterialId id,
                                               MaterialName name,
                                               Consumption consumption,
                                               Weight weight,
                                               Length length)
        {
            return new Material(id, name, MaterialType.A, null, null, length, weight);
        }

        // 部材Bを生成する
        public static Material CreateMaterialB(MaterialId id,
                                               MaterialName name,
                                               TypeAndSize typesize,
                                               Weight weight,
                                               Length length,
                                               Consumption consumption=null)
        {
            if(typesize == null) throw new ArgumentNullException(nameof(Domain.Material.TypeAndSize));

            return new Material(id, name, MaterialType.B, typesize, consumption, length, weight);
        }

        public void ChangeType(ProductType type)
        {
            this.TypeAndSize = new TypeAndSize(type, this.TypeAndSize.Width);
        }

        public void ChangeWidth(Size size)
        {
            this.TypeAndSize = new TypeAndSize(this.TypeAndSize.Type, size);
        }

        public void ChangeConsumption(Consumption consumption)
        {
            this.Consumption = consumption;
        }

        public void ChangWeight(Weight weight)
        {
            this.Weight = weight;
        }

        public void ChangeLength(Length length)
        {
            this.Length = length;
        }

    }
}
