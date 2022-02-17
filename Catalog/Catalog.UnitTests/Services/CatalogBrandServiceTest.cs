using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Host.Data.Entities;
using Infrastructure.Services;

namespace Catalog.UnitTests.Services
{
    public class CatalogBrandServiceTest
    {
        private readonly ICatalogBrandService _catalogBrandService;

        private readonly Mock<ICatalogBrandRepository> _catalogBrandrepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogService>> _logger;

        private readonly CatalogBrand _testItem = new CatalogBrand()
        {
            Brand = "Abcdfg"
        };

        public CatalogBrandServiceTest()
        {
            _catalogBrandrepository = new Mock<ICatalogBrandRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(dbContextTransaction.Object);

            _catalogBrandService = new CatalogBrandService(_dbContextWrapper.Object, _logger.Object, _catalogBrandrepository.Object);
        }

        [Fact]
        public async Task AddAsync_Success()
        {
            // arrange
            var testResult = 1;

            _catalogBrandrepository.Setup(s => s.Add(
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogBrandService.AddAsync(_testItem.Brand);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task AddAsync_Failed()
        {
            // arrange
            int? testResult = null;

            _catalogBrandrepository.Setup(s => s.Add(
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogBrandService.AddAsync(_testItem.Brand);

            // assert
            result.Should().Be(testResult);
        }

        // [Fact]
        // public async Task Update_Success()
        // {
        //    // arrange

        // catalogBrandrepository.Setup(s => s.Update(
        //        It.IsAny<int>(),
        //        It.IsAny<string>())).ThrowsAsync();

        // // ac
        //   // var result = await _catalogBrandService.DeleteAsync(_testItem.Brand);

        // // assert
        //    // result.Should().Be(result);
        // }
    }
}
