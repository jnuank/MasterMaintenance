using System;
namespace Domain.Material
{
    public class MaterialA : Material
    {
        public MaterialA(MaterialId id,
                         MaterialName name,
                         Consumption consumption,
                         Weight weight,
                         Length length) 
                         : base(id, name, MaterialType.A, null, consumption, length, weight)
        {

        }

        public override bool ValidateConsumption(Consumption value)
        {
            return value != null;
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
            // 部材Aでは特にチェックしない
            return true;
        }

        public override bool ValidateWeight(Weight value)
        {
            return value != null;
        }
    }
}
