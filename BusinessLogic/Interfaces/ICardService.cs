using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICardService
    {
        int Create(CardDto cardDto);
        bool Pay(int cardId, PaymentDto paymentDto);
        decimal GetBalance(int cardId);
    }
}
