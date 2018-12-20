using System;
using System.Linq;

namespace Domain.Material
{
    /// <summary>
    /// 部材区分クラス
    /// </summary>
    public abstract class MaterialType : Enumeration
    {
        // 部材区分オブジェクト
        public static MaterialType A = new MaterialTypeA();
        public static MaterialType B = new MaterialTypeB();

        protected MaterialType(int id, string name) : base(id, name){ }

        // バリデーションメソッドを抽象メソッドとして用意しておく
        public abstract bool ValidateConsumption(Consumption consumption);
        public abstract bool ValidateLength(Length length);
        public abstract bool ValidateName(MaterialName name);
        public abstract bool ValidateTypeAndSize(TypeAndSize typesize);
        public abstract bool ValidateWeight(Weight weight);

        public static MaterialType GetMaterialType(int id)
        {
            var materialTypes = Enumeration.GetAll<MaterialType>().Cast<MaterialType>();

            return materialTypes.FirstOrDefault(x => x.Id == id);
        }

        // 部材区分A
        private class MaterialTypeA : MaterialType
        {
            public MaterialTypeA() : base(0, "部材A") { }

            public override bool ValidateConsumption(Consumption consumption)
            {
                return consumption.Value != null;
            }

            public override bool ValidateLength(Length length)
            {
                return length.Value != null;
            }

            public override bool ValidateName(MaterialName name)
            {
                return name.Value != null;
            }

            public override bool ValidateTypeAndSize(TypeAndSize typesize)
            {
                // 部材Aでは特にチェックしない
                return true;
            }

            public override bool ValidateWeight(Weight weight)
            {
                return weight.Value != null;
            }
        }

        // 部材区分B
        private class MaterialTypeB : MaterialType, IMaterilValidatePolicy
        {
            public MaterialTypeB() : base(1, "部材B") { }
            public override bool ValidateConsumption(Consumption consumption)
            {
                // 部材Bではチェックしない
                return true;
            }

            public override bool ValidateLength(Length length)
            {
                return length.Value != null;
            }

            public override bool ValidateName(MaterialName name)
            {
                return name.Value != null;
            }

            public override bool ValidateTypeAndSize(TypeAndSize typesize)
            {
                bool validateOk = (typesize.Size.Value != null && typesize.Type.Value != null);
                return validateOk;
            }

            public override bool ValidateWeight(Weight weight)
            {
                return weight.Value != null;
            }
        }
    }
}
