using System;
namespace Domain.Material
{
    public class MaterialB : Material
    {
        public MaterialB(MaterialId id, 
                         TypeAndSize ptnWidth,
                         Weight weight,
                         Length length, 
                         Consumption consumption=null) 
                         : base(id, MaterialType.B, ptnWidth, consumption, length, weight)
        {

        }
    }
}
