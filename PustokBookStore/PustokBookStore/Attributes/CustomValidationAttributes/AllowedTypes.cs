using System.ComponentModel.DataAnnotations;

namespace PustokBookStore.Attributes.CustomValidationAttributes
{
    public class AllowedTypes:ValidationAttribute
    {
        private readonly string[] _types;
        public AllowedTypes(params string[] types)
        {
            _types = types;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value is IFormFile)
            {
                var type = (IFormFile)value;

                foreach (var item in _types)
                {
                    if (type.ToString() != item)
                    {
                        return new ValidationResult($"ImageFile must be {item}");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
