namespace Tea.Dal
{
    public class DalTea
    {
        public ITea GetTea()
        {
            return new EarlGrey() { Price = 18.50M, Name="Tea", Description="Naboo Green Tea" };
            }
    }
}
