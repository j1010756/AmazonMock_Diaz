namespace AmazonMock.Models
{
    public interface IBookRepository
    {
        // set up interface to get books
        public IQueryable<Book> Books { get; }
    }
}
