using System;
namespace Domain.Material
{
    /// <summary>
    /// 部材クラス
    /// </summary>
    public abstract class Material
    {
        public MaterialId Id { get; private set; }
        public MaterialName Name { get; private set; }
        public MaterialType Type { get; private set; }
        public TypeAndSize TypeAndSize { get; private set; }
        public Consumption Consumption { get; private set; }
        public Length Length { get; private set; }
        public Weight Weight { get; private set; }

        // コンストラクタはprivateにしておき、外部からインスタンス化させない
        protected Material(MaterialId id,
                        MaterialName name,
                        MaterialType type,
                        TypeAndSize typesize,
                        Consumption consumption,
                        Length length,
                        Weight weight)
        {
            if (id == null) throw new ArgumentException(nameof(MaterialId));
            if (type == null) throw new ArgumentException(nameof(MaterialType));
            if (!ValidateName(name)) throw new ArgumentException(nameof(MaterialName));
            if (!ValidateLength(length)) throw new ArgumentException(nameof(Length));
            if (!ValidateWeight(weight)) throw new ArgumentException(nameof(Weight));
            if (!ValidateTypeAndSize(typesize)) throw new ArgumentException(nameof(typesize));
            if (!ValidateConsumption(consumption)) throw new ArgumentException(nameof(consumption));

            this.Id = id;
            this.Type = type;
            this.Name = name;
            this.Length = length;
            this.Weight = weight;
            this.TypeAndSize = typesize;
            this.Consumption = consumption;
        }


        // バリデーション関数
        public abstract bool ValidateName(MaterialName value);
        public abstract bool ValidateTypeAndSize(TypeAndSize value);
        public abstract bool ValidateConsumption(Consumption value);
        public abstract bool ValidateWeight(Weight value);
        public abstract bool ValidateLength(Length value);

        public void ChangeType(ProductType type)
        {
            var value = new TypeAndSize(type, this.TypeAndSize.Width);
            if (!ValidateTypeAndSize(value))
                throw new ArgumentException(nameof(type)+"の値が不正です");

            this.TypeAndSize = value;
        }

        public void ChangeSize(Size size)
        {
            var value = new TypeAndSize(this.TypeAndSize.Type, size);
            if(!ValidateTypeAndSize(value))
                throw new ArgumentException(nameof(size) + "の値が不正です");

            this.TypeAndSize = value;
        }

        public void ChangeConsumption(Consumption consumption)
        {
            if (!ValidateConsumption(consumption))
                throw new ArgumentException(nameof(consumption) + "の値が不正です");

            this.Consumption = consumption;
        }

        public void ChangeName(MaterialName name)
        {
            if(!ValidateName(name))
                throw new ArgumentException(nameof(name) + "の値が不正です");

            this.Name = name;
        }

        public void ChangWeight(Weight weight)
        {
            if (!ValidateWeight(weight))
                throw new ArgumentException(nameof(weight) + "の値が不正です");

            this.Weight = weight;
        }

        public void ChangeLength(Length length)
        {
            if (!ValidateLength(length))
                throw new ArgumentException(nameof(length) + "の値が不正です");

            this.Length = length;
        }
    }
}
