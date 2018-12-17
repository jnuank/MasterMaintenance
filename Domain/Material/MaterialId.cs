using System;
using System.Collections.Generic;

namespace Domain.Material
{
    /// <summary>
    /// 部材ID
    /// </summary>
    public class MaterialId 
    {
        public string Value { get; }

        public MaterialId(string id)
        {
            int result = 0;
            if (!int.TryParse(id, out result))
                throw new ArgumentException("数字を入れて下さい");

            // idの文字列が8文字ではなかったら、エラーにする
            if (id.Length != 8)
            {
                throw new ArgumentException("数字は8文字でお願いします");
            }

            Value = id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var otherValue = obj as MaterialId;

            var typeMatches = this.GetType().Equals(obj.GetType());
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;

        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
        }
    }
}
