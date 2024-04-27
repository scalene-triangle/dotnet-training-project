using MediatR;
using mediatr_and_cqrs_training.Commands.AddBook;
using mediatr_and_cqrs_training.Models;
using mediatr_and_cqrs_training.Queries.GetBook;
using Microsoft.AspNetCore.Mvc;

namespace mediatr_and_cqrs_training.Controllers
{
    [Route("api/training/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<Book> Get(string name)
        {
            var query = new GetBookQuery(name);
            return _mediator.Send(query);
        }

        [HttpPost]
        public Task Post([FromBody] Book book)
        {
            var command = new AddBookCommand(book);
            return _mediator.Send(command);
        }
    }
}
