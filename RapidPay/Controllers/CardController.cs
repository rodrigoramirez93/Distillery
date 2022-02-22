using BusinessLogic.Dtos;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RapidPay.Controllers
{
    [ApiController]
    public class CardController : Controller
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        [Route("Card")]
        public IActionResult Create(CardDto cardDto)
        {
            var id = _cardService.Create(cardDto);
            return Ok(new { CardId = id });
        }

        [HttpPost]
        [Route("Card/{cardId}/Payment")]
        public IActionResult Pay(int cardId, PaymentDto paymentDto)
        {
            var result = _cardService.Pay(cardId, paymentDto);
            return result ? Ok() : BadRequest();
        }

        [HttpGet]
        [Route("Card/{cardId}/Balance")]
        public IActionResult GetBalance(int cardId)
        {
            var balance = _cardService.GetBalance(cardId);
            return Ok(new { Balance = balance });
        }
    }
}
