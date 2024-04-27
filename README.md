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


### Flurl

FlurlClient is a lightweight wrapper around HttpClient and is tightly bound to its lifetime. It implements IDisposable , and when disposed will also dispose HttpClient . FlurlClient includes a BaseUrl property, as well as Headers , Settings , and many of the fluent methods you may already be familiar with.

HttpClient Sample:
````
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = "https://jsonplaceholder.typicode.com/posts/1";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"HTTP Error: {response.StatusCode}");
            }
        }
    }
}
````

FlurlClient Sameple:
````
using System;
using Flurl.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string url = "https://jsonplaceholder.typicode.com/posts/1";
            string content = await url.GetStringAsync();
            Console.WriteLine(content);
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"HTTP Error: {ex.Message}");
        }
    }
}
````

**区别**：
1. 语法风格：
- HttpClient 是 .NET 提供的标准库，使用起来需要创建 HttpClient 实例，然后调用其方法来发送请求。
- Flurl 是一个第三方库，使用起来采用了链式调用的 API 风格，更加简洁易读。
2. 异常处理：
- HttpClient 需要使用 try-catch 块来捕获异常。
- Flurl 通过抛出 FlurlHttpException 异常来处理 HTTP 请求的异常情况。
3. 配置选项：
- HttpClient 可以通过 HttpClientHandler 进行更详细的配置，如设置代理、SSL 策略等。
- Flurl 在更高的层次上提供了一些默认配置选项，但是不如 HttpClient 那样详细。

总的来说，使用 HttpClient 需要更多的样板代码和异常处理，而 Flurl 则提供了更简洁、更易用的 API，但在某些情况下可能会牺牲一些配置的灵活性。选择使用哪种方式取决于项目的具体需求和个人偏好。