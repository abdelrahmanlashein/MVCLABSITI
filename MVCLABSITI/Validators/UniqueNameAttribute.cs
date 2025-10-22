using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MVCLABSITI.Context;
using System.ComponentModel.DataAnnotations;

namespace MVCLABSITI.Validators
{
    public class UniqueNameAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var name = value as string;
            if (string.IsNullOrWhiteSpace(name))
                return ValidationResult.Success;

            var db = validationContext.GetService(typeof(SchoolContext)) as SchoolContext;

            if (db == null)
                return ValidationResult.Success;

            var currentCourse = (dynamic)validationContext.ObjectInstance;
            int currentId = 0;

            try
            {
                currentId = currentCourse.CourseId;
            }
            catch { }

            var course = db.Courses.FirstOrDefault(c => c.Name == name && c.CourseId != currentId);

            if (course != null)
            {
                return new ValidationResult("Name must be unique.");
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-uniquename", ErrorMessage ?? "Name must be unique.");
        }
    }
}