using MassTransit;
using MediatR;
using MessagesAndEvents.Events;
using Microsoft.AspNetCore.Mvc;
using Order.API.Commands;
using Order.API.Models;
using Order.API.Queries;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndPoint;
        private readonly IMediator _mediator;

        public OrderController(IPublishEndpoint publishEndPoint, IMediator mediator)
        {
            _publishEndPoint = publishEndPoint;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest createOrderRequest)
        {
            // DB Processes
            var order = _mediator.Send(new CreateOrderCommand(new Models.Order { CustomerId = createOrderRequest.CustomerId}));

            // throw an event of OrderCreated
            var orderCreated = new OrderCreated
            {
                CustomerId = createOrderRequest.CustomerId,
                OrderId = 8,
                OrderItems = createOrderRequest?.OrderItems?.Select(x => new OrderItemMessage { Price = x.Price, Quantity = x.Quantity, ProductId = x.BookId }).ToList(),
                TotalPrice = createOrderRequest?.OrderItems?.Sum(x => x.Price * x.Quantity)
            };
            await _publishEndPoint.Publish(orderCreated); 
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var query = new GetOrdersQuery();
            return Ok(await _mediator.Send(query));
        }
    }
}
