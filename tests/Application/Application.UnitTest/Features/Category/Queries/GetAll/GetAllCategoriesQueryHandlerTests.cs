using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using Application.Features.Category.Queries.GetAll;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Constants.Caching;
using FluentAssertions;
using Microsoft.Extensions.Caching.Distributed;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Category;

namespace Application.UnitTest.Features.Category.Queries.GetAll
{
    [Collection(CollectionDefinition.SharedDistributedCacheFixture)]
    public class GetAllCategoriesQueryHandlerTests
    {
        #region ( Setup Fixture )
        private readonly SharedFixture _sharedFixture;
        private readonly DistributedCacheFixture _cacheFixture;
        private readonly GetAllCategoryQueryHandler _handler;

        public GetAllCategoriesQueryHandlerTests(SharedFixture sharedFixture, DistributedCacheFixture cacheFixture)
        {
            _sharedFixture = sharedFixture;
            _cacheFixture = cacheFixture;

            _handler = new GetAllCategoryQueryHandler(
                _sharedFixture.Mapper,
                _sharedFixture.UnitOfWork,
                _cacheFixture.DistributedCache);

            _sharedFixture.UnitOfWork.CategoryRepository.ClearReceivedCalls();
            _sharedFixture.Mapper.ClearReceivedCalls();
            _cacheFixture.DistributedCache.ClearReceivedCalls();
        }
        #endregion

        #region ( Should Return Mapped Category List When Categories Exist And Cache Miss )
        [Fact]
        public async Task Should_ReturnMappedCategoryList_WhenCategoriesExist_AndCacheMiss()
        {
            // Arrange
            var categories = new List<Domain.Entities.Category.Category>
            {
                new() { Id = 1, Name = "Back" , IsActive = true },
                new() { Id = 2, Name = "Front", IsActive = true }
            };

            var viewModels = new List<CategoryListViewModel>
            {
                new() { Id = 1, Name = "Back" , IsActive = true },
                new() { Id = 2, Name = "Front", IsActive = true }
            };

            var cacheKey = CacheKeys.GetAllCategoriesQuery();

            _cacheFixture.DistributedCache
                .GetAsync(cacheKey, Arg.Any<CancellationToken>())
                .Returns((byte[])null);

            _sharedFixture.UnitOfWork.CategoryRepository
                .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Category.Category, bool>>>())
                .Returns(Task.FromResult((IList<Domain.Entities.Category.Category>)categories)!);

            _sharedFixture.Mapper
                .Map<List<CategoryListViewModel>>(categories)
                .Returns(viewModels);

            _cacheFixture.DistributedCache
                .SetAsync(cacheKey, Arg.Any<byte[]>(), Arg.Any<DistributedCacheEntryOptions>(), Arg.Any<CancellationToken>())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(new GetAllCategoriesQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(viewModels);

            await _sharedFixture.UnitOfWork.CategoryRepository.Received(1)
                .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Category.Category, bool>>>());

            _sharedFixture.Mapper.Received(1)
                .Map<List<CategoryListViewModel>>(categories);

            await _cacheFixture.DistributedCache.Received(1)
                .SetAsync(cacheKey, Arg.Any<byte[]>(), Arg.Any<DistributedCacheEntryOptions>(), Arg.Any<CancellationToken>());
        }
        #endregion

        #region ( Should Return Data From Cache When Cache Hit )
        [Fact]
        public async Task Should_ReturnDataFromCache_WhenCacheHit()
        {
            // Arrange
            var domainCategories = new List<Domain.Entities.Category.Category>
            {
                new() { Id = 1, Name = "Back", IsActive = true },
                new() { Id = 2, Name = "Front", IsActive = true }
            };

            var expectedViewModels = new List<CategoryListViewModel>
            {
                new() { Id = 1, Name = "Back"  , IsActive = true },
                new() { Id = 2, Name = "Front" , IsActive = true}
            };

            var cacheKey = CacheKeys.GetAllCategoriesQuery();
            var serialized = JsonSerializer.Serialize(domainCategories);
            var cachedBytes = Encoding.UTF8.GetBytes(serialized);

            _cacheFixture.DistributedCache
                .GetAsync(cacheKey, Arg.Any<CancellationToken>())
                .Returns(cachedBytes);

            _sharedFixture.Mapper
                .Map<List<CategoryListViewModel>>(Arg.Any<ICollection<Domain.Entities.Category.Category>>())
                .Returns(expectedViewModels);

            // Act 
            var result = await _handler.Handle(new GetAllCategoriesQuery(), CancellationToken.None);


            // Assert
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(expectedViewModels);

            await _sharedFixture.UnitOfWork.CategoryRepository.DidNotReceive()
                .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Category.Category, bool>>>());

            _sharedFixture.Mapper.Received(1)
                .Map<List<CategoryListViewModel>>(Arg.Is<List<Domain.Entities.Category.Category>>(l => l.Count == 2));
        }
        #endregion

        #region ( Should Return Empty List When No Active Categories Found )
        [Fact]
        public async Task Should_ReturnEmptyList_WhenNoActiveCategoriesFound()
        {
            // Arrange
            var emptyCategories = new List<Domain.Entities.Category.Category>();
            var emptyViewModels = new List<CategoryListViewModel>();
            var cacheKey = CacheKeys.GetAllCategoriesQuery();

            _cacheFixture.DistributedCache
                .GetAsync(cacheKey, Arg.Any<CancellationToken>())
                .Returns((byte[])null);

            _sharedFixture.UnitOfWork.CategoryRepository
                .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Category.Category, bool>>>())
                .Returns(Task.FromResult((IList<Domain.Entities.Category.Category>)emptyCategories)!);

            _sharedFixture.Mapper
                .Map<List<CategoryListViewModel>>(emptyCategories)
                .Returns(emptyViewModels);

            _cacheFixture.DistributedCache
                .SetAsync(cacheKey, Arg.Any<byte[]>(), Arg.Any<DistributedCacheEntryOptions>(), Arg.Any<CancellationToken>())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(new GetAllCategoriesQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().BeEmpty();

            await _sharedFixture.UnitOfWork.CategoryRepository.Received(1)
                .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Category.Category, bool>>>());

            _sharedFixture.Mapper.Received(1)
                .Map<List<CategoryListViewModel>>(emptyCategories);
        }
        #endregion

        #region ( Should Return Null When Repository Returns Null )
        [Fact]
        public async Task Should_ReturnNull_WhenRepositoryReturnsNull()
        {
            // Arrange
            var cacheKey = CacheKeys.GetAllCategoriesQuery();

            _cacheFixture.DistributedCache
                .GetAsync(cacheKey, Arg.Any<CancellationToken>())
                .Returns((byte[])null);

            _sharedFixture.UnitOfWork.CategoryRepository
                .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Category.Category, bool>>>())
                .Returns((IList<Domain.Entities.Category.Category>)null!);

            // Act
            var result = await _handler.Handle(new GetAllCategoriesQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeNull();
        }
        #endregion
    }
}

