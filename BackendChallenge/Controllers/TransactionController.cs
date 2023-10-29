using BackendChallenge.core.Commands.Notification;
using BackendChallenge.core.Commands.Transaction;
using BackendChallenge.core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackendChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(IMediator mediator, ITransactionRepository transactionRepository)
        {
            _mediator = mediator;
            _transactionRepository = transactionRepository;
        }

        [HttpGet("{id:GUID}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var tranction = await _transactionRepository.FindByIdAsync(id);

            if (tranction == null) return NotFound();

            return Ok(tranction);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTransactionCommand command)
        {
            var transactionId = await _mediator.Send(command);
            await _mediator.Send(new NotifyReceiverCommand(transactionId));

            return Created($"api/transaction/{transactionId}", null);
        }

    }
}
