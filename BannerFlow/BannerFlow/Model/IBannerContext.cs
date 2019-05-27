using MongoDB.Driver;

namespace BannerFlow.Model
{
    public interface IBannerContext
    {
        IMongoCollection<Banner> Banners { get; }
    }
}