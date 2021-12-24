using System;
namespace proj.BLL.Infastructure
{
    public class ValidationExceptions:Exception
    {
        public string Property { get; set; }
        public ValidationExceptions(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
