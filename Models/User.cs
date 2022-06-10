using System.ComponentModel.DataAnnotations;

namespace AmlexTradeWeb.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public ulong SteamID { get; set; }
        public double MoneyAmount { get; set; }
    }
}
