using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersList : IRequest<List<OrderDTO>>
    {
        public string UserName { get; set; }

        public GetOrdersList(string userName)
        {
            UserName = userName;
        }
    }
}