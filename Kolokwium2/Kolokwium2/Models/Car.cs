using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("cars")]
public class Car
{
    [Key]
    public int ID { get; set; }
    [MaxLength(17)]
    public string VIN { get; set; }
    [MaxLength(100)] 
    public string Name { get; set; }
    public int Seats { get; set; }
    public int PricePerDay { get; set; }
    public int ModelID { get; set; }
    public int ColorID { get; set; }
    
    [ForeignKey(nameof(ModelID))]
    public Model Model { get; set; }
    [ForeignKey(nameof(ColorID))]
    public Color Color { get; set; }
    public ICollection<CarRental> CarRentals { get; set; }
}