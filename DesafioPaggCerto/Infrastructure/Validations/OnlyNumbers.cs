using System.ComponentModel.DataAnnotations;

namespace DesafioPaggCerto.Infrastructure.Validations
{
    public class OnlyNumbers : RegularExpressionAttribute
    {
        public OnlyNumbers() : base(@"^\d*$")
        {
            ErrorMessage = "{0}: Only numbers.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return base.IsValid(value);
        }
    }
}
