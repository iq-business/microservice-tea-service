using System;

namespace Tea.Dal
{
    public class DalTea
    {
        public ITea GetTea()
        {
            ITea tea = new EarlGrey() { Price = GetRandomPrice(), Name="Tea", Description="Naboo Green Tea" };
            LogToConsole(tea);
            return tea;
        }

        private decimal GetRandomPrice()
        {
            Random random = new Random(Environment.TickCount);
            return (decimal)(random.Next(10, 30));
        }

        private void LogToConsole(ITea tea) {
            Console.WriteLine("      Tea: {\"name\":\"" + tea.Name + "\", \"description\":\"" + tea.Description + "\", \"price\":\"" + tea.Price + "\"}");
        }
    }
}
