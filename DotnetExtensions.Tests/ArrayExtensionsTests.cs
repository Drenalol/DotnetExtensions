using System.Linq;
using Xunit;

namespace DotnetExtensions.Tests
{
    public class ArrayExtensionsTests
    {
        [Theory]
        [InlineData(150, 15, 10)]
        [InlineData(1500, 15, 100)]
        [InlineData(15000, 15, 1000)]
        [InlineData(150, 8, 19)]
        [InlineData(150, 1, 150)]
        [InlineData(150, 150, 1)]
        public void SkipTakeTest(int elements, int takeEvery, int expectedLength)
        {
            var array = Enumerable.Range(0, elements).ToArray();
            var skipTake = array.TakeEvery(takeEvery);
            Assert.NotEmpty(skipTake);
            Assert.Equal(expectedLength, skipTake.Length);
        }
    }
}