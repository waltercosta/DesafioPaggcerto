using System.ComponentModel.DataAnnotations;

namespace DesafioPaggCerto.Models.EntityModel.Shopkeepers
{
    public class Shopkeeper
    {
        [Required]
        public long? Id { get; set; }
        public string Name { get; set; }
    }
}
