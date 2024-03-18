namespace AmazonMock.Models.ViewModels
{
    public class PaginationInfo
    {
        // total number of records
        public int TotalItems { get; set; }

        // how many records per page
        public int ItemsPerPage { get; set; }

        // current page number
        public int CurrentPage { get; set; }

        // get total number of pages by dividing total items by items per page
        public int TotalNumPages => (int)(Math.Ceiling((decimal)TotalItems / ItemsPerPage));
    }
}
