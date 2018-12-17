using System;
using System.Collections.Generic;

namespace Domain.Material
{
    public class TreadPatternAndWidth
    {
        public TreadPattern Pattern { get; }
        public Width Width { get; }

        public TreadPatternAndWidth(TreadPattern pattern, Width width)
        {
            this.Pattern = pattern;
            this.Width = width;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != this.GetType())
                return false;

            var other = obj as TreadPatternAndWidth;

            return this.Pattern.Equals(other.Pattern) && this.Width.Equals(other.Width);            
        }

        public override int GetHashCode()
        {
            var hashCode = 102817008;
            hashCode = hashCode * -1521134295 + EqualityComparer<TreadPattern>.Default.GetHashCode(Pattern);
            hashCode = hashCode * -1521134295 + EqualityComparer<Width>.Default.GetHashCode(Width);
            return hashCode;
        }
    }
}
