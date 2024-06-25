using System.Transactions;
using Kolokwium2.DTOs;
using Kolokwium2.Models;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IDbService _dbService;
    public ClientsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetOrdersData(int clientId)
    {
        var client = await _dbService.GetClientRentals(clientId);

        if (client == null)
        {
            return NotFound("No such client");
        }
        
        return Ok(client);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddClientAndRental(AddClientAndRentalDto addClientAndRentalDto)
    {
        if (!await _dbService.DoesCarExist(addClientAndRentalDto.CarID))
        {
            return NotFound("car not found");
        }

        if (addClientAndRentalDto.DateFrom >= addClientAndRentalDto.DateTo)
        {
            return BadRequest("wrong dates");
        }
        var client = new Client()
        {
            FirstName = addClientAndRentalDto.Client.FirstName,
            LastName = addClientAndRentalDto.Client.LastName,
            Address = addClientAndRentalDto.Client.Address
        };
        
        var rentalDays = (addClientAndRentalDto.DateTo - addClientAndRentalDto.DateFrom).Days;
        var car = await _dbService.GetCarById(addClientAndRentalDto.CarID);
        var totalPrice = rentalDays * car.PricePerDay;
        
        var carRental = new CarRental()
        {
            CarID = addClientAndRentalDto.CarID,
            DateFrom = addClientAndRentalDto.DateFrom,
            DateTo = addClientAndRentalDto.DateTo,
            TotalPrice = totalPrice,
            Client = client
        };
        
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddNewClient(client);
            await _dbService.AddCarRental(carRental);
    
            scope.Complete();
        }
        return Created();
    }
    
}