using System;
namespace Domain.Material
{
    /// <summary>
    /// 部材区分クラス
    /// </summary>
    public abstract class MaterialType : Enumeration
    {
        public static MaterialType A = new MaterialTypeA();
        public static MaterialType B = new MaterialTypeB();

        protected MaterialType(int id, string name) : base(id, name)
        {
            // do nothing
        }

        private class MaterialTypeA : MaterialType
        {
            public MaterialTypeA() : base(0, "A") { }
        }

        private class MaterialTypeB : MaterialType
        {
            public MaterialTypeB() : base(1, "B") { }
        }
    }

}
