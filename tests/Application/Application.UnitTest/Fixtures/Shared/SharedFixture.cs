using Application.UnitTest.Helpers;
using AutoMapper;
using Persistence.Contracts;

namespace Application.UnitTest.Fixtures.Shared
{
    public class SharedFixture : IDisposable
    {
        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public SharedFixture()
        {
            UnitOfWork = SubstituteHelper.Create<IUnitOfWork>();
            Mapper = SubstituteHelper.Create<IMapper>();
        }

        public void Dispose()
        {
        }
    }
}
