using System;
namespace Domain.Material
{
    /// <summary>
    /// 部材クラス
    /// </summary>
    public class Material
    {
        public MaterialId Id { get; private set; }
        public MaterialType Type { get; private set; }
        public TypeAndSize TypeAndSize { get; private set; }
        public Consumption Consumption { get; private set; }
        public Length Length { get; private set; }
        public Weight Weight { get; private set; }

        public Material(MaterialId id,
                        MaterialType type,
                        TypeAndSize typesize,
                        Consumption consumption,
                        Length length,
                        Weight weight)
        {
            if (id == null) throw new ArgumentNullException(nameof(MaterialId));
            if (type == null) throw new ArgumentNullException(nameof(MaterialType));
            if (length == null) throw new ArgumentNullException(nameof(Length));
            if (weight == null) throw new ArgumentNullException(nameof(Weight));

            this.Id = id;
            this.Type = type;
            this.TypeAndSize = typesize;
            this.Consumption = consumption;
            this.Length = length;
            this.Weight = weight;
        }

        public static Material CreateMaterialA(MaterialId id,
                                               Consumption consumption,
                                               Weight weight,
                                               Length length)
        {
            return new Material(id, MaterialType.A, null, null, length, weight);
        }

        public static Material CreateMaterialB(MaterialId id,
                                               TypeAndSize typesize,
                                               Weight weight,
                                               Length length,
                                               Consumption consumption=null)
        {
            if(typesize == null) throw new ArgumentNullException(nameof(Domain.Material.TypeAndSize));

            return new Material(id, MaterialType.B, typesize, consumption, length, weight);
        }

        public void ChangePattern(ProductType type)
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
