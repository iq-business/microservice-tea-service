using System;

namespace Tea.Dal
{
    public class EarlGrey : ITea
    {
        public decimal Price { get; set; }
        public string Name { get ; set; }
        public string Description { get; set; }
    }
}
