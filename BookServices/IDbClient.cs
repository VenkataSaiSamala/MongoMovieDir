using MongoBookStore.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoBookStore.Core
{
    public interface IDbClient
    {
        IMongoCollection<Book> GetBooksCollection();
    }
}
