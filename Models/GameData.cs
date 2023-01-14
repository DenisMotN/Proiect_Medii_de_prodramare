namespace Proiect_Medii_de_prodramare.Models
{
    public class GameData
    {
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<GameCategory> GameCategories { get; set; }

    }
}
