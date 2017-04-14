using TeaDal;
using Xunit;

namespace Tea.Test
{
    public class MyTeaTest
    {
        [Fact]
        public void TeaPriceShouldBe()
        {
            var tea = new DalTea().GetTea();
            const decimal expectedPrice = 22.65M;
            Assert.IsType<TeaDal.Tea>(tea);
            Assert.Equal(expectedPrice, tea.Price);
        }
    }
}
