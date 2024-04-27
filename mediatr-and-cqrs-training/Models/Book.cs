namespace mediatr_and_cqrs_training.Models
{
    public class Book
    {
        string Name { get; set; }

        public Book(string name)
        {
            Name = name;
        }
    }
}
