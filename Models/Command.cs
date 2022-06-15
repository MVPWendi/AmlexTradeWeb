using System.ComponentModel.DataAnnotations;

namespace AmlexTradeWeb.Models
{
    public class Command
    {
        [Key]
        public int CommandID { get; set; }
        // имя лпганиа
        public string PluginName{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Usage { get; set; }
    }
}
