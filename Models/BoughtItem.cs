using System.ComponentModel.DataAnnotations;

namespace AmlexTradeWeb.Models
{
    public class BoughtItem
    {
        [Key]
        public int ID { get; set; }

        public int ItemKey { get; set; }

        public ulong OwnerID { get; set; }

        public ulong SellerID { get; set; }
        public bool Taken { get; set; }

    }



    public enum ItemType
    {
        Vehicle,
        Item
    }
}
