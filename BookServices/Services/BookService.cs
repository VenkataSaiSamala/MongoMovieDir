using MongoBookStore.Core.Models;
using MongoDB.Driver;

namespace MongoBookStore.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<Book> _books;
        public BookService(IDbClient dbClient) { _books = dbClient.GetBooksCollection(); }
        public List<Book> GetBooks()
        {
            return _books.Find(book => true).ToList();
        }
    }
}