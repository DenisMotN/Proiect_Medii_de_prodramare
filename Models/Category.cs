namespace Proiect_Medii_de_prodramare.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<GameCategory>? GameCategories { get; set; }
    }
}
