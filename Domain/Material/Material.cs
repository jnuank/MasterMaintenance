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
            // 先にMaterialTypeがnullで無いことをチェックしないと、
            // 後続のValidationが出来なくなる。(Typeがnullなので、nullReferenceErrorとかになるはず)
            if (id == null) throw new ArgumentException(nameof(MaterialId));
            if (type == null) throw new ArgumentException(nameof(MaterialType));

            this.Id = id;
            this.Type = type;

            if (!Type.ValidateName(name)) throw new ArgumentException(nameof(name));
            if (!Type.ValidateLength(length)) throw new ArgumentException(nameof(Length));
            if (!Type.ValidateWeight(weight)) throw new ArgumentException(nameof(Weight));
            if (!Type.ValidateTypeAndSize(typesize)) throw new ArgumentException(nameof(typesize));
            if (!Type.ValidateConsumption(consumption)) throw new ArgumentException(nameof(consumption));

            this.Name = name;
            this.Length = length;
            this.Weight = weight;
            this.TypeAndSize = typesize;
            this.Consumption = consumption;
        }


        public static Material CreateMaterialA(MaterialId id,
                                             MaterialName name,
                                             Consumption consumption,
                                             Weight weight,
                                             Length length)
        {
            return new Material(id, name, MaterialType.A, null, consumption, length, weight);
        }

        public static Material CreateMaterialB(MaterialId id,
                                               MaterialName name,
                                               TypeAndSize typesize,
                                               Weight weight,
                                               Length length,
                                               Consumption consumption = null)
        {
            return new Material(id, name, MaterialType.B, typesize, consumption, length, weight);
        }


        // 各プロパティの変更メソッド。変更の中にバリデーションも含めてしまっているけど、
        // これはどうなんだろうか。
        public void ChangeMaterilType(MaterialType materialType)
        {
            // 新しい部材区分に設定されているバリデーションルールに則って、
            // いまのエンティティのプロパティのチェックをする
            if(!materialType.ValidateName(this.Name)
               && !materialType.ValidateLength(this.Length)
               && !materialType.ValidateWeight(this.Weight)
               && !materialType.ValidateTypeAndSize(this.TypeAndSize)
               && !materialType.ValidateConsumption(this.Consumption))
            {
                throw new ArgumentException("値が不正です");
            }

            this.Type = materialType;
        }

        public void ChangeType(ProductType type)
        {
            var value = new TypeAndSize(type, this.TypeAndSize.Width);
            if (!Type.ValidateTypeAndSize(value))
                throw new ArgumentException(nameof(type)+"の値が不正です");

            this.TypeAndSize = value;
        }

        public void ChangeSize(Size size)
        {
            var value = new TypeAndSize(this.TypeAndSize.Type, size);
            if(!Type.ValidateTypeAndSize(value))
                throw new ArgumentException(nameof(size) + "の値が不正です");

            this.TypeAndSize = value;
        }

        public void ChangeConsumption(Consumption consumption)
        {
            if (!Type.ValidateConsumption(consumption))
                throw new ArgumentException(nameof(consumption) + "の値が不正です");

            this.Consumption = consumption;
        }

        public void ChangeName(MaterialName name)
        {
            if(!Type.ValidateName(name))
                throw new ArgumentException(nameof(name) + "の値が不正です");

            this.Name = name;
        }

        public void ChangWeight(Weight weight)
        {
            if (!Type.ValidateWeight(weight))
                throw new ArgumentException(nameof(weight) + "の値が不正です");

            this.Weight = weight;
        }

        public void ChangeLength(Length length)
        {
            if (!Type.ValidateLength(length))
                throw new ArgumentException(nameof(length) + "の値が不正です");

            this.Length = length;
        }
    }
}
