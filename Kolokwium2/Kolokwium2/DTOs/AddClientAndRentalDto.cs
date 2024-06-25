using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.DTOs;

public class AddClientAndRentalDto
{
    public AddClientDto Client { get; set; }
    public int CarID { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}

public class AddClientDto
{
    [MaxLength(50)]
    [MinLength(4)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    [MinLength(4)]
    public string LastName { get; set; }
    [MaxLength(100)]
    [MinLength(4)]
    public string Address { get; set; }
}