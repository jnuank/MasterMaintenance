using System;
namespace Domain.Material
{
    /// <summary>
    /// 部材クラス
    /// </summary>
    public abstract class Material
    {
        public MaterialId Id { get; protected set; }
        public MaterialType Type { get; protected set; }
        public TreadPatternAndWidth PatternAndWidth { get; protected set; }
        public Consumption Consumption { get; protected set; }
        public Length Length { get; protected set; }
        public Weight Weight { get; protected set; }

        public Material(MaterialId id,
                        MaterialType type,
                        TreadPatternAndWidth ptnWidth,
                        Consumption consumption,
                        Length length,
                        Weight weight)
        {
            this.Id = id;
            this.Type = type;
            this.PatternAndWidth = ptnWidth;
            this.Consumption = consumption;
            this.Length = length;
            this.Weight = weight;
        }

        public static Material CreateMaterialA()

        
        public void ChangePattern(TreadPattern pattern)
        {
            this.PatternAndWidth = new TreadPatternAndWidth(pattern, this.PatternAndWidth.Width);
        }

        public void ChangeWidth(Width width)
        {
            this.PatternAndWidth = new TreadPatternAndWidth(this.PatternAndWidth.Pattern, width);
        }

        public void ChangeConsumption(Consumption consumption)
        {
            this.Consumption = consumption;
        }

        public void ChangWeight(Weight weight)
        {
            this.Weight = weight;
        }

        public void ChangeLength(Length length)
        {
            this.Length = length;
        }

    }
}
