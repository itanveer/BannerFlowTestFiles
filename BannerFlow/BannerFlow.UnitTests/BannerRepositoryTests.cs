using BannerFlow.Model;
using BannerFlow.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BannerFlow.UnitTests
{
    [TestClass]
    public class BannerRepositoryTests
    {
        Mock<IBannerContext> _bannerContextMock = new Mock<IBannerContext>();
        Mock<BannerRepository> _bannerRepositoryMock = new Mock<BannerRepository>();

        [TestMethod]
        public async void TestCreateBanner()
        {
            // Arrange
            BannerRepository br = new BannerRepository(_bannerContextMock.Object);
            Banner b = new Banner() {
                BannerId = 1,
                Html = "<html><head><meta charset='UTF-8'><title>Page Title</title></head><body><h1>BannerFlow</h1><p>BannerFlow Modified Ad</p></body></html>",
                Created = DateTime.Now
            };

            // Act
            await br.Create(b);

            //ASSERT
            _bannerRepositoryMock.VerifyAll();
            _bannerRepositoryMock.Verify(_ => _.Create(b), Times.AtLeast(1));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Html is not Valid!")]
        public async void TestCreateBannerValidate()
        {
            // Arrange
            BannerRepository br = new BannerRepository(_bannerContextMock.Object);
            Banner b = new Banner()
            {
                BannerId = 1,
                Html = "<html>headmeta charset='UTF-8'><title>Page Title</title></head><body><h1>BannerFlow</h1><p>BannerFlow Modified Ad</p></body></html>",
                Created = DateTime.Now
            };

            // Act
            await br.Create(b);

            //ASSERT
            _bannerRepositoryMock.Verify(_ => _.Create(b), Times.AtLeast(0));
        }

        [TestMethod]
        public async void TestGetBanners()
        {
            // Arrange
            BannerRepository br = new BannerRepository(_bannerContextMock.Object);
            
            // Act
            await br.GetAllBanners();

            //ASSERT
            _bannerRepositoryMock.Verify(_ => _.GetAllBanners(), Times.AtLeast(1));
        }
    }
}
