using MediatR;
using mediatr_and_cqrs_training.Models;

namespace mediatr_and_cqrs_training.Queries.GetBook
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, Book>
    {
        public Task<Book> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
