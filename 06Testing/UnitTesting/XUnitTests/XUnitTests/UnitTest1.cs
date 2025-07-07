namespace XUnitTests
{
    public sealed class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [InlineData(true)]
        [Theory]
        public void Test2(bool setbit)
        {
            return false;
        }
    }
}
