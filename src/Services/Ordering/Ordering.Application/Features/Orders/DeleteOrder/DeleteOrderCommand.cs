using MediatR;

namespace Ordering.Application.Features.Orders.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
