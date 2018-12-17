using System;
namespace Domain.Material
{
    /// <summary>
    /// 幅オブジェクト
    /// </summary>
    public class Width
    {
        public float Value { get; }

        public Width(float value)
        {
            if(value < 0.0 || value > 999.9)
            {
                throw new ArgumentException("0.0から999.9の間で入力して下さい");
            }
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;

            if (this.Value.Equals(((Width)obj).Value))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return -1937169414 + Value.GetHashCode();
        }
    }
}
