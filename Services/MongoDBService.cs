using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace Fibonacci
{
    public class MongoDBService
    {
          private readonly IMongoCollection<Fibonacci> _playlistCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _playlistCollection = database.GetCollection<Fibonacci>(mongoDBSettings.Value.CollectionName);
    }

  //  public async Task<List<Fibonacci>> GetAsync() { }
    public async Task CreateAsync(Fibonacci fibonacci) { }
    public async Task AddToPlaylistAsync(string id, string movieId) {}
    public async Task DeleteAsync(string id) { }


    }
}