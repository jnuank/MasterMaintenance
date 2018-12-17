using System;
namespace Domain.Material
{
    public class MaterialA : Material
    {
        public MaterialA(MaterialId id,
                         Consumption consumption,
                         Weight weight,
                         Length length,
                         TypeAndSize ptnWidth=null) 
                         : base(id, MaterialType.A, ptnWidth, consumption, length, weight)
        {
            
        }
    }
}
