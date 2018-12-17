using System;
using System.Collections.Generic;

namespace Domain.Material
{
    public class TypeAndSize
    {
        public ProductType Type { get; }
        public Size Width { get; }

        public TypeAndSize(ProductType type, Size width)
        {
            this.Type = type;
            this.Width = width;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != this.GetType())
                return false;

            var other = obj as TypeAndSize;

            return this.Type.Equals(other.Type) && this.Width.Equals(other.Width);            
        }

        public override int GetHashCode()
        {
            var hashCode = 102817008;
            hashCode = hashCode * -1521134295 + EqualityComparer<ProductType>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<Size>.Default.GetHashCode(Width);
            return hashCode;
        }
    }
}
