namespace LibraryService.Models.Dto
{
    public class BookDto
    {
        public Guid? Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
    }
}
