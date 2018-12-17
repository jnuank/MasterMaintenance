using System;
namespace Domain.Material
{
    /// <summary>
    /// 消費量オブジェクト
    /// </summary>
    public class Consumption
    {
        public float Value { get; }

        public Consumption(float value)
        {
            if (value < 0.0 || value > 99.9)
            {
                throw new ArgumentException("0.0から99.9の間で入力して下さい");
            }
            Value = value;
        }
    }
}
