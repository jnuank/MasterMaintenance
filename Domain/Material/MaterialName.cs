using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Domain.Material
{
    public class MaterialName
    {
        public string Value { get; }

        public MaterialName(string value)
        {
            if (!Regex.IsMatch(value, "^[a-zA-Z0-9]*$"))
            {
                throw new ArgumentException("アルファベット、数字の組み合わせで入力して下さい");
            }

            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;

            if (this.Value.Equals(((MaterialName)obj).Value))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
        }
    }
}
