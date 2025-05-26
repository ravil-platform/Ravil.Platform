using NSubstitute;

namespace Application.UnitTest.Helpers
{
    public static class SubstituteHelper
    {
        public static T Create<T>() where T : class
        {
            return Substitute.For<T>();
        }
    }
}
