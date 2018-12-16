using System;
namespace Domain.Material
{
    /// <summary>
    /// 部材ID
    /// </summary>
    public class MaterialId
    {
        public string Value { get; }

        public MaterialId(string id)
        {
            int result = 0;
            if (!int.TryParse(id, out result))
                throw new ArgumentException("数字を入れて下さい");

            // idの文字列が8文字ではなかったら、エラーにする
            if (id.Length != 8)
            {
                throw new ArgumentException("数字は8文字でお願いします");
            }

        }
    }
}
