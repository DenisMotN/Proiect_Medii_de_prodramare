using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Proiect_Medii_de_prodramare.Models
{
    public class Game
    {
        public int ID { get; set; }

        [Display(Name = "Game Name")]
        public string Name { get; set; }
        public string Developer{ get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int? PlatformID { get; set; }
        public Platform? Platform { get; set; }

        public ICollection<GameCategory>? GameCategories { get; set; }
    }
}
