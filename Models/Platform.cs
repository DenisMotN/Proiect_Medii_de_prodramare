namespace Proiect_Medii_de_prodramare.Models
{
    public class Platform
    {
        public int ID { get; set; }
        public string PlatformName { get; set; }
        public ICollection<Game>? Games { get; set; }
    }
}
