namespace TeaDal
{
    public class DalTea
    {
        public ITea GetTea(decimal price)
        {
            return new Tea {Price = price};
        }
    }
}
