using MediatR;

namespace mediatr_and_cqrs_training.Commands.AddBook
{
    public class AddBookCommandHandler : IRequest<AddBookCommand>
    {
        public Task<Unit> Handler(AddBookCommand request, CancellationToken cancellationToken)
        {
            // todo

            return Unit.Task;
        }
    }
}
