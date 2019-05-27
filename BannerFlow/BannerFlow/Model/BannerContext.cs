using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BannerFlow.Model
{
    public class BannerContext : IBannerContext
    {
        private readonly IMongoDatabase _db;

        public BannerContext(IOptions<DatabaseSettings> options, IMongoClient client)
        {
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Banner> Banners => _db.GetCollection<Banner>("Banners");
    }
}