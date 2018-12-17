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

        // 何かプロパティが必要なら、ここに記載しておくことができる。


        protected MaterialType(int id, string name) : base(id, name)
        {
            // do nothing
        }

        private class MaterialTypeA : MaterialType
        {
            public MaterialTypeA() : base(0, "部材A") { }
        }

        private class MaterialTypeB : MaterialType
        {
            public MaterialTypeB() : base(1, "部材B") { }
        }
    }
}
