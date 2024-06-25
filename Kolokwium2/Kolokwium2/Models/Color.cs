using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("colors")]
public class Color
{
    [Key]
    public int ID { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public ICollection<Car> Cars { get; set; }
}