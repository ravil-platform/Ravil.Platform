//using Application.Features.Blog.Queries.GetAll;
//using Application.UnitTest.Constans;
//using Application.UnitTest.Fixtures.Shared;
//using FluentAssertions;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Caching.Memory;
//using MockQueryable;
//using NSubstitute;
//using ViewModels.QueriesResponseViewModel.Blog;

//namespace Application.UnitTest.Features.Blog.GetAll;
//[Collection(CollectionDefinition.SharedFixture)]
//public class GetAllBlogsQueryHandlerTests
//{
//    private readonly SharedFixture _sharedFixture;
//    private readonly IMemoryCache _memoryCache;
//    private readonly GetAllBlogsQueryHandler _handler;

//    public GetAllBlogsQueryHandlerTests(SharedFixture sharedFixture)
//    {
//        _sharedFixture = sharedFixture;
//        _memoryCache = new MemoryCache(new MemoryCacheOptions());

//        _handler = new GetAllBlogsQueryHandler(
//            _sharedFixture.UnitOfWork,
//            _sharedFixture.Mapper,
//            _memoryCache);

//        _sharedFixture.UnitOfWork.BlogRepository.ClearReceivedCalls();
//        _sharedFixture.Mapper.ClearReceivedCalls();
//    }

//    [Fact]
//    public async Task Should_ReturnBlogsFromCache_IfCacheHasValue()
//    {
//        // Arrange
//        var cachedBlogs = new List<BlogViewModel>
//        {
//            new() { Id = 1, Title = "Cached Blog" }
//        };

//        _memoryCache.Set(nameof(GetAllBlogsQuery), cachedBlogs);

//        var query = new GetAllBlogsQuery();

//        // Act
//        var result = await _handler.Handle(query, CancellationToken.None);

//        // Assert
//        result.Should().NotBeNull();
//        result.Value.Should().BeEquivalentTo(cachedBlogs);


//        await _sharedFixture.UnitOfWork.BlogRepository.DidNotReceiveWithAnyArgs().GetAllAsync();
//        _sharedFixture.Mapper.DidNotReceive().Map<List<BlogViewModel>>(Arg.Any<List<Domain.Entities.Blog.Blog>>());
//    }

//    [Fact]
//    public async Task Should_CallRepositoryAndCache_WhenCacheIsEmpty()
//    {
//        // Arrange
//        _memoryCache.Remove(nameof(GetAllBlogsQuery));

//        var blogEntities = new List<Domain.Entities.Blog.Blog>
//        {
//            new() { Id = 1, Title = "Repo Blog" }
//        };

//        var blogViewModels = new List<BlogViewModel>
//        {
//            new() { Id = 1, Title = "Repo Blog" }
//        };

//        _sharedFixture.UnitOfWork.BlogRepository.GetAllAsync()!.Returns(Task.FromResult((ICollection<Domain.Entities.Blog.Blog>)blogEntities));

//        _sharedFixture.Mapper
//            .Map<List<BlogViewModel>>(blogEntities)
//            .Returns(blogViewModels);

//        var query = new GetAllBlogsQuery();

//        // Act
//        var result = await _handler.Handle(query, CancellationToken.None);

//        // Assert
//        result.Should().NotBeNull();
//        result.Value.Should().HaveCount(1);
//        result.Value[0].Title.Should().Be("Repo Blog");

//        _memoryCache.TryGetValue(nameof(GetAllBlogsQuery), out List<BlogViewModel> cached).Should().BeTrue();
//        cached.Should().BeEquivalentTo(blogViewModels);

//        _sharedFixture.UnitOfWork.BlogRepository.Received(1).GetAllAsync();
//        _sharedFixture.Mapper.Received(1).Map<List<BlogViewModel>>(blogEntities);
//    }
//}