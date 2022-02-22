using BusinessLogic.Dtos;
using BusinessLogic.Interfaces;
using System.Linq;
using Domain;

namespace BusinessLogic.Implementations
{
    public class CardService : ICardService
    {
        private readonly Context _context;

        public CardService(
            Context context)
        {
            _context = context;
        }

        public int Create(CardDto cardDto)
        {
            var canParse = long.TryParse(cardDto.Digits, out long digits);
            if (!canParse)
                throw new ArgumentException($"Invalid digit: {cardDto.Digits}");

            var card = new Card(digits, cardDto.Balance);
            int result;

            _context.Add(card);
            _context.SaveChanges();
            result = _context?.Cards?.First(x => x.Digits == card.Digits)?.Id ?? throw new ArgumentException("Server error");

            return result;
        }

        public decimal GetBalance(int cardId)
        {
            var card = GetCard(cardId);
            if (card == null)
                throw new ArgumentException(CardNotFound(cardId));

            return decimal.Round(card.Balance, 2);
        }

        public bool Pay(int cardId, PaymentDto paymentDto)
        {
            var card = GetCard(cardId);
            if (card == null)
                throw new ArgumentException(CardNotFound(cardId));

            var platformFee = (paymentDto.PaymentAmount * UniversalFeesExchangeService.CalculateFee(DateTime.Now));

            card.Balance -= (paymentDto.PaymentAmount - platformFee);
            _context.Update(card);
            _context.SaveChanges();

            return true;
        }

        private string CardNotFound(int cardId)
            => $"There is no card with id = {cardId}";

        private Card? GetCard(int cardId)
            => _context?.Cards?.FirstOrDefault(x => x.Id == cardId);
    }
}
