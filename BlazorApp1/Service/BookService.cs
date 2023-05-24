using BlazorApp1.Data;
using BlazorApp1.Iservice;
using MongoDB.Driver;
using BlazorApp1.Iservice;
using System.Xml.Linq;

namespace BlazorApp1.Service
{
    public class BookService : IBookService
    {
        
        private MongoClient MongoClient = null;
        private IMongoDatabase Database = null;
        private IMongoCollection<Book> Book_table = null;
        public BookService()
        {
            MongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
            Database = MongoClient.GetDatabase("BookStore");
            Book_table = Database.GetCollection<Book>("Books");
        }
        public string Delete(string bookId)
        {
            Book_table.DeleteOne(x => x.ID == bookId);
            return "Deleted";
        }

        public Book GetBook(string bookId)
        {
            return Book_table.Find(x => x.ID == bookId).FirstOrDefault();
        }

        public List<Book> GetBooks()
        {
            return Book_table.Find(FilterDefinition<Book>.Empty).ToList();
        }
        public async Task<List<Book>> GetBooks1()
        {
            return await Task.FromResult(Book_table.Find(FilterDefinition<Book>.Empty).ToList());
        }


        public void SaveOrUpdate(Book book)
        {
            var bookObj = Book_table.Find(x=>x.ID==book.ID).FirstOrDefault();
            if (bookObj == null) {
                Book_table.InsertOne(book);
            }
            else
            {
                Book_table.ReplaceOne(x => x.ID == book.ID, book);
            }
        }
    }

}
