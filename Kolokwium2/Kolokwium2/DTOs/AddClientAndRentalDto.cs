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
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}