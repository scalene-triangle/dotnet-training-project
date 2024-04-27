using MediatR;
using mediatr_and_cqrs_training.Models;

namespace mediatr_and_cqrs_training.Commands.AddBook
{
    public class AddBookCommand : IRequest
    {
        public Book Book { get; set; }

        public AddBookCommand(Book book)
        {
            Book = book;
        }
    }
}
