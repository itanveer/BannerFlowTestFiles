using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BannerFlow.Model;
using BannerFlow.Repository;

namespace BannerFlow.Controllers
{
    [Produces("application/json")]
    [Route("api/Banner")]
    public class BannerController : Controller
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerController(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        // GET: api/Banner
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _bannerRepository.GetAllBanners());
        }

        // GET: api/Banner/bannerId
        [HttpGet("{bannerId}", Name = "Get")]
        public async Task<IActionResult> Get(int bannerId)
        {
            var banner = await _bannerRepository.GetBanner(bannerId);

            if (banner == null)
                return new NotFoundResult();

            return new ObjectResult(banner);
        }

        // POST: api/Banner
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Banner banner)
        {
            await _bannerRepository.Create(banner);
            return new OkObjectResult(banner);
        }

        // PUT: api/Banner/5
        [HttpPut("{bannerId}")]
        public async Task<IActionResult> Put(int bannerId, [FromBody]Banner banner)
        {
            var bannerFromDb = await _bannerRepository.GetBanner(bannerId);

            if (bannerFromDb == null)
                return new NotFoundResult();

            banner.Id = bannerFromDb.Id;

            await _bannerRepository.Update(banner);

            return new OkObjectResult(banner);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{bannerId}")]
        public async Task<IActionResult> Delete(int bannerId)
        {
            var bannerFromDb = await _bannerRepository.GetBanner(bannerId);

            if (bannerFromDb == null)
                return new NotFoundResult();

            await _bannerRepository.Delete(bannerId);

            return new OkResult();
        }

    }
}
