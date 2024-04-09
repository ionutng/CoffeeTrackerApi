using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeTrackerApi.Models;

public class Records
{
    public int Id { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Quantity { get; set; }

    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
}
