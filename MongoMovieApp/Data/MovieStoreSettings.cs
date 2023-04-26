namespace MongoMovieApp.Data
{
    public class MovieStoreSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string MoviesCollectionName { get; set; } = string.Empty;
    }
}
