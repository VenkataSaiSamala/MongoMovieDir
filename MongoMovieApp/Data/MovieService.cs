using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Authentication;

namespace MongoMovieApp.Data
{
    public class MovieService
    {
        private readonly IMongoCollection<Movie> _movies;

        public MovieService(IOptions<MovieStoreSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _movies = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Movie>(options.Value.MoviesCollectionName);
        }

        public async Task<List<Movie>> Get() => 
            await _movies.Find(m => true).ToListAsync();

        public async Task<Movie> Get(string id) => 
            await _movies.Find(m => m.Id == id).FirstOrDefaultAsync();

        public async Task Create(Movie movie) => 
            await _movies.InsertOneAsync(movie);

        public async Task Update(string id, Movie movie) => 
            await _movies.ReplaceOneAsync(m => m.Id == id, movie);

        public async Task Remove(string id) =>
            await _movies.DeleteOneAsync(m => m.Id == id);
    }
}
