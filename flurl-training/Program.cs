using Flurl;
using Flurl.Http;

namespace flurl_training
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            const string baseUrl = "https://jsonplaceholder.typicode.com";

            var url = "https://jsonplaceholder.typicode.com:8080"
                .AppendPathSegment("posts");

            url.SetQueryParams(new
            {
                api_key = "somekey",
                client = "weiss.net",
                sometext = "this is some text that get's encoded correctly!"
            });

            url.SetQueryParam("paging", new[] { 1, 2, 3 });

            //foreach (var item in url.QueryParams)
            //{
            //    Console.WriteLine($"{item.Name} = {item.Value}");
            //}

            // flurl http
            var result = await baseUrl.AppendPathSegment("posts").GetAsync();
            Console.WriteLine(result.StatusCode);

            //foreach (var item in result.Headers)
            //{
            //    Console.WriteLine($"{item.Name} = {item.Value}");
            //}

            //Console.WriteLine(await result.GetStringAsync());

            var posts = await result.GetJsonAsync<IEnumerable<Post>>();

            //foreach (var post in posts)
            //{
            //    Console.WriteLine(post);
            //}

            var todos = await baseUrl
                .AppendPathSegment("todos")
                .AppendPathSegment("1")
                .AppendPathSegment("todos")
                .GetJsonAsync<IEnumerable<Todo>>();

            //foreach (var item in todos)
            //{
            //    Console.WriteLine($"Id: {item.Id} \nTitle: {item.Title}, {item.Completed}");
            //}

            var patchResult = await baseUrl
               .AppendPathSegment("posts")
               .AppendPathSegment("1")
               .PatchJsonAsync(new
               {
                   title = "foo",
                   completed = "True"
               });

            Console.WriteLine(patchResult.StatusCode);
            Console.WriteLine(await patchResult.GetStringAsync());
        }
    }
}
