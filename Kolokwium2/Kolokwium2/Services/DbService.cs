using Kolokwium2.Data;
using Kolokwium2.DTOs;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<GetClientDto?> GetClientRentals(int clientId)
    {
        var client = await _context.Clients
            .Include(c => c.CarRentals)
            .ThenInclude(cr => cr.Car)
            .ThenInclude(c => c.Color)
            .Include(c => c.CarRentals)
            .ThenInclude(cr => cr.Car)
            .ThenInclude(c => c.Model)
            .Where(c => c.ID == clientId)
            .FirstOrDefaultAsync();

        if (client == null)
        {
            return null;
        }

        return new GetClientDto
        {
            ID = client.ID,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Address = client.Address,
            rentals = client.CarRentals.Select(cr => new GetCarRentalsDto
            {
                VIN = cr.Car.VIN,
                Color = cr.Car.Color.Name,
                Model = cr.Car.Model.Name,
                DateFrom = cr.DateFrom,
                DateTo = cr.DateTo,
                TotalPrice = cr.TotalPrice
                
            }).ToList()
        };
    }
    
    public async Task<bool> DoesCarExist(int carId)
    {
        return await _context.Cars.AnyAsync(e => e.ID == carId);
    }
    
    public async Task AddNewClient(Client client)
    {
        await _context.AddAsync(client);
        await _context.SaveChangesAsync();
    }
    public async Task<Car?> GetCarById(int carId)
    {
        return await _context.Cars.FirstOrDefaultAsync(e => e.ID == carId);
    }
    public async Task AddCarRental(CarRental carRental)
    {
        await _context.AddAsync(carRental);
        await _context.SaveChangesAsync();
    }

}