using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;

    public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.OrderDate = request.OrderDate;
        value.UserId = request.UserId;
        value.TotalPrice = request.TotalPrice;
        await _repository.UpdateAsync(value);
    }
}