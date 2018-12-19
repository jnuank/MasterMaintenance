using System;
namespace Domain.Material
{
    /// <summary>
    /// 部材区分クラス
    /// </summary>
    public abstract class MaterialType : Enumeration,IMaterilValidatePolicy
    {
        public static MaterialType A = new MaterialTypeA();
        public static MaterialType B = new MaterialTypeB();

        // 何かプロパティが必要なら、ここに記載しておくことができる。
        

        protected MaterialType(int id, string name) : base(id, name)
        {
            // do nothing
        }

        public abstract bool ValidateConsumption(Consumption value);
        public abstract bool ValidateLength(Length value);
        public abstract bool ValidateName(MaterialName value);
        public abstract bool ValidateTypeAndSize(TypeAndSize value);
        public abstract bool ValidateWeight(Weight value);

        private class MaterialTypeA : MaterialType
        {
            public MaterialTypeA() : base(0, "部材A") { }

            public override bool ValidateConsumption(Consumption value)
            {
                return value != null;
            }

            public override bool ValidateLength(Length value)
            {
                return value != null;
            }

            public override bool ValidateName(MaterialName value)
            {
                return value != null;
            }

            public override bool ValidateTypeAndSize(TypeAndSize value)
            {
                // 部材Aでは特にチェックしない
                return true;
            }

            public override bool ValidateWeight(Weight value)
            {
                return value != null;
            }
        }

        private class MaterialTypeB : MaterialType, IMaterilValidatePolicy
        {
            public MaterialTypeB() : base(1, "部材B") { }
            public override bool ValidateConsumption(Consumption value)
            {
                // 部材Bではチェックしない
                return true;
            }

            public override bool ValidateLength(Length value)
            {
                return value != null;
            }

            public override bool ValidateName(MaterialName value)
            {
                return value != null;
            }

            public override bool ValidateTypeAndSize(TypeAndSize value)
            {
                return value != null;
            }

            public override bool ValidateWeight(Weight value)
            {
                return value != null;
            }
        }
    }
}
