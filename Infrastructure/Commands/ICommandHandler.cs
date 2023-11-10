﻿namespace Infrastructure.Commands;

public interface ICommandHandler<TCommand,TResult>
    where TCommand : ICommand
{
    Task<TResult> HandleAsync(TCommand command);
}
