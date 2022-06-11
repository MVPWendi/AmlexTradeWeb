using System.ComponentModel.DataAnnotations;

namespace AmlexTradeWeb.Models
{
    public class Car : ITradeGood
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set ; }
        public double Cost { get; set; }
        public string Description { get; set; }
        public ulong OwnerID { get; set; }
        public ushort VehicleID { get; set; }

        public uint VehicleInstanceID {get; set;}
        public bool Bought { get; set; }
    }
}
