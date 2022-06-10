namespace AmlexTradeWeb.Models
{
    public class Item : ITradeGood
    {
        public int ID { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public ulong OwnerID { get; set; }
        public ushort ItemID { get; set; }
        public bool Bought { get; set; }
    }
}
