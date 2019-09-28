using Its.Onix.Core.Commons.Model;

namespace Its.Onix.Erp.Models
{
    public class MMatrix : BaseModel
    {
        public int Value { get; set; }

        public bool IsKeyIdentifiable()
        {
            bool isError = string.IsNullOrEmpty(Key);
            return !isError;
        }
    }
}