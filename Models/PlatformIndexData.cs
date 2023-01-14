using System.Security.Policy;

namespace Proiect_Medii_de_prodramare.Models
{
    public class PlatformIndexData
    {
        public IEnumerable<Platform> Platforms { get; set; }
        public IEnumerable<Game> Games { get; set; }

    }
}
