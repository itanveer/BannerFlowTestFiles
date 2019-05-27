using System.Collections.Generic;
using System.Threading.Tasks;
using BannerFlow.Model;
using Microsoft.AspNetCore.Mvc;

namespace BannerFlow.Repository
{
    public interface IBannerRepository
    {
        Task<IEnumerable<Banner>> GetAllBanners();
        Task<Banner> GetBanner(int bannerId);
        Task Create(Banner banner);
        Task<bool> Update(Banner banner);
        Task<bool> Delete(int bannerId);
        ContentResult GetHtmlById(int bannerId);
    }
}