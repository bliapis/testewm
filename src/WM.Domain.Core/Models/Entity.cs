using FluentValidation;
using FluentValidation.Results;

namespace WM.Domain.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public int Id { get; set; }
        public abstract bool IsValid();
    }
}