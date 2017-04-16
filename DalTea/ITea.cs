namespace Tea.Dal
{
    public interface ITea
    {
        decimal Price { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}