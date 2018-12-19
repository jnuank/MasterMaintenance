using System;
namespace Domain.Material
{
    // 部材バリデートポリシー
    public interface IMaterilValidatePolicy
    {
        bool ValidateName(MaterialName value);
        bool ValidateTypeAndSize(TypeAndSize value);
        bool ValidateConsumption(Consumption value);
        bool ValidateWeight(Weight value);
        bool ValidateLength(Length value);
    }
}
