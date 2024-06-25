namespace Kolokwium2.DTOs;

public class GetClientDto
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public List<GetCarRentalsDto> rentals { get; set; }
}

public class GetCarRentalsDto
{
    public string VIN { get; set; }
    public string Color { get; set; }
    public string Model { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int TotalPrice { get; set; }

}