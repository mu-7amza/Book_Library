using BlazorApp1.Data;

namespace BlazorApp1.Iservice
{
    public interface IBookService
    {
        void SaveOrUpdate(Book book);
        Book GetBook(string bookId);
        List<Book> GetBooks();
        Task<List<Book>> GetBooks1();
        string Delete (string bookId);


    }
}
