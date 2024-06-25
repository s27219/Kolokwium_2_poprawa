using Kolokwium2.DTOs;
using Kolokwium2.Models;

namespace Kolokwium2.Services;

public interface IDbService
{
    public Task<GetClientDto?> GetClientRentals(int clientId);
    public Task<bool> DoesCarExist(int carId);
    public Task AddNewClient(Client client);
    public Task<Car?> GetCarById(int carId);
    public Task AddCarRental(CarRental carRental);
}