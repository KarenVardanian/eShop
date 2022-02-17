using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Host.Data.Entities;

namespace Catalog.UnitTests.Services
{
    public class CatalogTypeServiceTest
    {
        private readonly ICatalogTypeService _catalogTypeService;

        private readonly Mock<ICatalogTypeRepository> _catalogTypeRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogService>> _logger;

        private readonly CatalogType _testItem = new CatalogType()
        {
            Type = "First"
        };

        public CatalogTypeServiceTest()
        {
            _catalogTypeRepository = new Mock<ICatalogTypeRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(dbContextTransaction.Object);
            _catalogTypeService = new CatalogTypeService(_dbContextWrapper.Object, _logger.Object, _catalogTypeRepository.Object);
        }

        [Fact]
        public async Task AddAsync_Success()
        {
            // arrange
            int testResult = 1;

            _catalogTypeRepository.Setup(s => s.Add(
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.AddAsync(_testItem.Type);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task AddAsyncFailed()
        {
            // arrange
            int? testResult = null;

            _catalogTypeRepository.Setup(s => s.Add(
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.AddAsync(_testItem.Type);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateFailed()
        {
            // arrange
            int? testResult = null;

            _catalogTypeRepository.Setup(s => s.Update(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.UpdateAsyncUpdate(_testItem.Id, _testItem.Type);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Update_Success()
        {
            // arrange
            int testResult = 5;

            _catalogTypeRepository.Setup(s => s.Update(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.UpdateAsyncUpdate(_testItem.Id, _testItem.Type);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Delete_Success()
        {
            // arrange
            _catalogTypeRepository.Setup(s => s.Delete(
                It.IsAny<int>()));

            // act
            var result = await _catalogTypeService.UpdateAsyncUpdate(_testItem.Id, _testItem.Type);

            // assert
        }
    }
}
