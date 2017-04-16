using Tea.Dal;
using Xunit;

namespace Tea.Test
{
    public class MyTeaTest
    {
        [Fact]
        public void TeaPriceShouldBe()
        {
            var tea = new DalTea().GetTea();
            const decimal expectedPrice = 23.65M;
            Assert.IsType<EarlGrey>(tea);
            Assert.Equal(expectedPrice, tea.Price);
        }
    }
}
