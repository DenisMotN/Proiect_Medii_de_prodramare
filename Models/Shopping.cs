using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Proiect_Medii_de_prodramare.Models
{
    public class Shopping
    {
        public int ID { get; set; }
        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }
        public int? GameID { get; set; }
        public Game? Game { get; set; }

        [DataType(DataType.Date)]
        public DateTime SellDate { get; set; }

    }
}
