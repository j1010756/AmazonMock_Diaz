namespace AmazonMock.Models
{
    public class EFBookRepository : IBookRepository
    {
        // get info from context file
        private BookstoreContext _context;

        // instance of ef repository receives info
        public EFBookRepository(BookstoreContext temp)
        {
            _context = temp;
        }

        // get book info
        public IQueryable<Book> Books => _context.Books;
    }
}
