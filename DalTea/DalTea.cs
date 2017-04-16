namespace Tea.Dal
{
    public class DalTea
    {
        public ITea GetTea()
        {
            return new EarlGrey() { Price = 23.65M, Name="Earl Grey", Description="A tea blend which has been flavoured with the addition of oil of bergamot." };
            }
    }
}
