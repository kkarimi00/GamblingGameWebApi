using Infrastructure.Entities;
using System.Data;

namespace Infrastructure.EntityValidators;

public class EntityValidator<TEntity> : IEntityValidator<TEntity> where TEntity : Entity
{
    protected TEntity Entity { get; private set; }

    public async Task ValidateAsync(TEntity entity)
    {
        Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        ValidateEntityProperties();
        await ValidateNavigationPropertiesAsync();
    }

    private void ValidateEntityProperties()
    {
        ValidateId();
        ValidateRequiredProperties();
    }

    private void ValidateId()
    {
        if (Entity.Id == default)
            throw new MissingPrimaryKeyException($"Primary field of '{nameof(Entity)}' can not be null");
    }

    protected virtual void ValidateRequiredProperties()
    {
    }
    protected virtual Task ValidateNavigationPropertiesAsync()
    {
        return Task.CompletedTask;
    }
}
