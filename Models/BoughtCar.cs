using System.ComponentModel.DataAnnotations;

namespace AmlexTradeWeb.Models
{
    public class BoughtCar
    {
        [Key]
        public int ID { get; set; }

        public int CarKey { get; set; }


        public ulong OwnerID { get; set; }

        public ulong SellerID { get; set; }
        public bool Taken { get; set; }

    }

}
