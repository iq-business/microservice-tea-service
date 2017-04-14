using TeaDal;
using Xunit;

namespace Tea.Test
{
    public class MyTeaTest
    {
        [Fact]
        public void TeaPriceShouldBe()
        {
            ITea tea = new DalTea().GetTea(21.95M);
            var expectedPrice = 21.95M;
            Assert.Equal(expectedPrice, tea.Price);
        }
    }
}
