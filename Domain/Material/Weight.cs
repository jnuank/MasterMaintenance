using System;
namespace Domain.Material
{
    public class Weight
    {
        public float Value { get; }

        public Weight(float value)
        {
            if (value < 0.0 || value > 999.9)
            {
                throw new ArgumentException("0.0から999.9の間で入力して下さい");
            }
            Value = value;

        }
    }
}
