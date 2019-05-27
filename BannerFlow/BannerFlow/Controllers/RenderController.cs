using Microsoft.AspNetCore.Mvc;
using BannerFlow.Repository;

namespace BannerFlow.Controllers
{
    [Produces("application/json")]
    [Route("api/Render")]
    public class RenderController : Controller
    {
        private readonly IBannerRepository _bannerRepository;

        public RenderController(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        // GET: api/Render/bannerId
        [HttpGet("{bannerId}", Name = "GetHtmlById")]
        public ContentResult Get(int bannerId)
        {
            return _bannerRepository.GetHtmlById(bannerId);
        }
    }
}
