using System;
namespace Domain.Material
{
    public class MaterialB : Material
    {
        public MaterialB(MaterialId id,
                         MaterialName name,
                         TypeAndSize typesize,
                         Weight weight,
                         Length length,
                         Consumption consumption = null)
                         : base(id, name, MaterialType.B, typesize, consumption, length, weight)
        {

        }

        public override bool ValidateConsumption(Consumption value)
        {
            // 部材Bではチェックしない
            return true;
        }

        public override bool ValidateLength(Length value)
        {
            return value != null;
        }

        public override bool ValidateName(MaterialName value)
        {
            return value != null;
        }

        public override bool ValidateTypeAndSize(TypeAndSize value)
        {
            return value != null;
        }

        public override bool ValidateWeight(Weight value)
        {
            return value != null;
        }
    }
}
