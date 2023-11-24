using Microsoft.EntityFrameworkCore;
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Domain.Services.Communication;

namespace Akira.API.Akira.Services;

/// <remarks>
/// This class was developed by Marcelo Scerpella
/// </remarks>
/// <summary>
/// This is the implementation of the interface IEventService, which contains the
/// methods that will be used to perform actions in the API. In this case, the
/// only method that is implemented is how to create a Event
/// </summary>
public class CardService: ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Constructor of the class. It requests for an event repository, and the unit of work implementation
    /// </summary>
    /// <param name="cardRepository">Repository of the events to work with in the future</param>
    /// <param name="unitOfWork">Default unit of work implementation to work with in the future</param>
    public CardService(ICardRepository cardRepository, IUnitOfWork unitOfWork)
    {
        _cardRepository = cardRepository;
        _unitOfWork = unitOfWork;
    } 
    public async Task<IEnumerable<Card>> ListAsync()
    {
        var cards = await _cardRepository.ListAsync();
        return cards;
    }

    public Task<Card> SaveAsync(Card card)
    {
        throw new NotImplementedException();
    }

    public async Task<Card> UpdateAsync(int id, Card card)
    {
        await _cardRepository.UpdateAsync(card);
        return card;
    }

    public async Task<Card> GetCardByIdAsync(int id)
    {
        var card = await _cardRepository.FindByIdAsync(id);
        return card;
    }
    
}