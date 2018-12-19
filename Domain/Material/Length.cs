using System;
namespace Domain.Material
{
    public class Length
    {
        public float? Value { get; }

        public Length(float? value)
        {
            if (value == null)
            {
                Value = null;
                return;
            }

            if (value < 0.0 || value > 999.9)
            {
                throw new ArgumentException("0.0から999.9の間で入力して下さい");
            }
            Value = value;
            
        }
    }
}
