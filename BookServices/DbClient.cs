using Microsoft.Extensions.Options;
using MongoBookStore.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoBookStore.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Book> _books;
        public DbClient(IOptions<BookstoreDbConfig> bookStoreDbConfig)
        {
           var client = new MongoClient(bookStoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(bookStoreDbConfig.Value.Database_Name);
            _books = database.GetCollection<Book>(bookStoreDbConfig.Value.Books_Collection_Name);
        }
        public IMongoCollection<Book> GetBooksCollection()
        {
            return _books;
        }
    }
}
