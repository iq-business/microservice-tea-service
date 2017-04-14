namespace TeaDal
{
    public class DalTea
    {
        public Tea GetTea(decimal price)
        {
            return new Tea {Price = price};
        }

        public Tea GetTea()
        {
            return new Tea { Price = 22.65M };
        }
    }
}
