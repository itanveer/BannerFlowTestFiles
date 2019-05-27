using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using BannerFlow.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BannerFlow.Repository
{
    public class BannerRepository : IBannerRepository
    {
        private readonly IBannerContext _context;

        public BannerRepository(IBannerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get all the banners
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Banner>> GetAllBanners()
        {
            return await _context
                            .Banners
                            .Find(_ => true)
                            .ToListAsync();
        }

        /// <summary>
        /// get the banner by BannerId
        /// </summary>
        /// <param name="bannerId"></param>
        /// <returns></returns>
        public Task<Banner> GetBanner(int bannerId)
        {
            FilterDefinition<Banner> filter = Builders<Banner>.Filter.Eq(m => m.BannerId, bannerId);

            return _context
                    .Banners
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

       /// <summary>
       /// Create a new Banner
       /// </summary>
       /// <param name="banner"></param>
       /// <returns></returns>
        public async Task Create(Banner banner)
        {
            var result = ValidateBanner.CheckValidHtml(banner.Html);
            if (!result) throw new System.Exception("Html is not Valid!");

            await _context.Banners.InsertOneAsync(banner);
        }

        /// <summary>
        /// update an existing banner based on Banner Id
        /// </summary>
        /// <param name="banner"></param>
        /// <returns></returns>
        public async Task<bool> Update(Banner banner)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Banners
                        .ReplaceOneAsync(
                            filter: g => g.Id == banner.Id,
                            replacement: banner);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        /// <summary>
        /// delete a Banner
        /// </summary>
        /// <param name="bannerId"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int bannerId)
        {
            FilterDefinition<Banner> filter = Builders<Banner>.Filter.Eq(m => m.BannerId, bannerId);

            DeleteResult deleteResult = await _context
                                                .Banners
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        /// <summary>
        /// get banner Html contant based on banner Id
        /// </summary>
        /// <param name="bannerId"></param>
        /// <returns></returns>
        public ContentResult GetHtmlById(int bannerId)
        {
            FilterDefinition<Banner> filter = Builders<Banner>.Filter.Eq(m => m.BannerId, bannerId);
            var banner = _context
                    .Banners
                    .Find(filter)
                    .FirstOrDefault();

            var result = ValidateBanner.CheckValidHtml(banner.Html);
            if (!result) throw new System.Exception("Html is not Valid!");

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = banner.Html
            };
        }
    }
}