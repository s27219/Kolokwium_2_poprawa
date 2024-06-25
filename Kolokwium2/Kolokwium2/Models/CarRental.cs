using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("car_rentals")]
public class CarRental
{
    [Key]
    public int ID { get; set; }
    public int ClientID { get; set; }
    public int CarID { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int TotalPrice { get; set; }
    public int? Discount { get; set; }
    
    [ForeignKey(nameof(ClientID))]
    public Client Client { get; set; }
    [ForeignKey(nameof(CarID))]
    public Car Car { get; set; }
}