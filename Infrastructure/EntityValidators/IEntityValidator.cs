using Infrastructure.Entities;

namespace Infrastructure.EntityValidators;

public interface IEntityValidator<T> where T : Entity
{
    Task ValidateAsync(T entity);
}
