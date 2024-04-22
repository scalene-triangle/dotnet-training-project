# dotnet-training-project
This project is for .net core training


### AutoMapper
**Steps:**

1 Install packages
`AutoMapper` & `AutoMapper.Extensions.Microsoft.DependencyInjection`

2 Register in `program.cs` 
````
builder.Services.AddAutoMapper(typeof(Program).Assembly);
````

3 Create Model `SuperHero` and Dto `SuperHeroDto`

3 Create AutoMapper Profile
````
public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SuperHero, SuperHeroDto>();
        CreateMap<SuperHeroDto, SuperHero>();
    }
}
````

4 Inject the mapper into controller and use it
````
 var data = _mapper.Map<SuperHero>(superHeroDto);
 var dto = _mapper.Map<SuperHeroDto>(superHero);
````

### MediatR and CQRS

CQRS: command and query responsibility segregation

Mediator Pattern: a publisher and a subscriber
- publisher would be commands and queries
- subscriber would be command handlers and query handler
**Steps:**

1 Install packages
`MediatR` & `MediatR.Extensions.Microsoft.DependencyInjection`

2 Register in `program.cs` 
````
using MediatR;

// ...
builder.Services.AddMediatR(typeof(Program));
````

3. Create `[feature name]Command.cs` and `[feature name]AddBookCommandHandler.cs`
- root directory
    - Commands folder
        - AddBook folder
            - AddBookCommand.cs
            - AddBookCommandController.cs

`AddBookCommand.cs`
````
public class AddBookCommand : IRequest
{
    public Book Book { get; set; }

    public AddBookCommand(Book book)
    {
        Book = book;
    }
}
````

`AddBookCommandHandler.cs`
````
public class AddBookCommandHandler : IRequest<AddBookCommand>
{
    public Task<Unit> Handler(AddBookCommand request, CancellationToken cancellationToken)
    {
        // todo

        return Unit.Task;
    }
}
````

4. Create `[feature name]Query.cs` and `[feature name]GetBookQueryHandler.cs`
- root directory
    - Queries folder
        - GetBook folder
            - GetBookQuery.cs
            - GetBookQueryHandler.cs

`GetBookQuery.cs`
````
public class GetBookQuery : IRequest<Book>
{
    public string Name { get; set; }

    public GetBookQuery(string name)
    {
        Name = name;
    }
}
````

`GetBookQueryHandler.cs`
````
public class GetBookQueryHandler : IRequestHandler<GetBookQuery, Book>
{
    public Task<Book> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
````
