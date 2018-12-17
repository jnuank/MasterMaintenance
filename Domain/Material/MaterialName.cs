using System;
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
                throw new ArgumentException("大文字のアルファベット、数字の組み合わせで入力して下さい");
            }

            Value = value;
        }
    }
}
