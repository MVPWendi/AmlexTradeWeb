using System.ComponentModel.DataAnnotations;

namespace AmlexTradeWeb.Models
{
    public interface ITradeGood
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double Cost { get; set; }
        public ulong OwnerID { get; set; }

        public bool Bought { get; set; }
    }
}
