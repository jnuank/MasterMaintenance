using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Domain.Material
{
    /// <summary>
    /// トレッドパターンオブジェクト
    /// </summary>
    public class ProductType
    {
        public string Value { get; }

        public ProductType(string TypeName)
        {
            if(string.IsNullOrEmpty(TypeName))
            {
                throw new ArgumentException("空白を入れることはできません");
            }

            // パターン名が6文字を超えていたら、エラーにする
            if (TypeName.Length > 6)
            {
                throw new ArgumentException("パターン名は6文字までです");
            }

            // パターン名は半角アルファベット大文字と数字とする
            if(!Regex.IsMatch(TypeName, "^[A-Z0-9]*$"))
            {
                throw new ArgumentException("大文字のアルファベット、数字の組み合わせで入力して下さい");
            }

            Value = TypeName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;

            if (this.Value.Equals(((ProductType)obj).Value))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
        }
    }
}
