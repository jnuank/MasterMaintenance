using System;
namespace Domain.Material
{
    // 部材バリデートポリシー
    public interface IMaterilValidatePolicy
    {
        bool Validate();
    }
}
