using MongoBookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoBookStore.Core.Services
{
    public interface IBookService
    {
        List<Book> GetBooks();
    }
}
