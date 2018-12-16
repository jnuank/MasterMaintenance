using System;
namespace Domain.Material
{
    /// <summary>
    /// 部材区分クラス
    /// </summary>
    public abstract class MaterialType : Enumeration
    {
        public static MaterialType a = new A();
        public static MaterialType b = new B();

        protected MaterialType(int id, string name) : base(id, name)
        {
            // do nothing
        }

        private class A : MaterialType
        {
            public A() : base(0, "A") { }
        }

        private class B : MaterialType
        {
            public B() : base(1, "B") { }
        }
    }

}
