using MediatR;
using mediatr_and_cqrs_training.Models;

namespace mediatr_and_cqrs_training.Queries.GetBook
{
    public class GetBookQuery : IRequest<Book>
    {
        public string Name { get; set; }

        public GetBookQuery(string name)
        {
            Name = name;
        }
    }
}
