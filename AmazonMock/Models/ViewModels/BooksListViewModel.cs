namespace AmazonMock.Models.ViewModels
{
    public class BooksListViewModel
    {
        // get list of books
        public IQueryable<Book> Books { get; set;}

        // make public instance of Pagination Info, make new one if not one
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
    }
}
