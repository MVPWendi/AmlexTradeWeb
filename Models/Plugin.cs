
using System.ComponentModel.DataAnnotations;

namespace AmlexTradeWeb.Models
{
    public class Plugin
    {
        [Key]
        public int PluginID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
