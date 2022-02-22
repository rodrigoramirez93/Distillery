using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementations
{
    public class UniversalFeesExchangeService
    {
        static UniversalFeesExchangeService? _instance;

        private static int _hour;
        private static DateTime _date;
        private static decimal _fee;

        private UniversalFeesExchangeService(int hour, DateTime date, decimal fee) 
        {
            _hour = hour;
            _date = date;
            _fee = fee;
        }

        public static UniversalFeesExchangeService? GetInstance()
        {
            return _instance;
        }

        public static decimal CalculateFee(DateTime now)
        {
            if (_instance == null)
            {
                var initialFee = new decimal(new Random().NextDouble());
                _instance = new UniversalFeesExchangeService(DateTime.Now.Hour, DateTime.Now.Date, initialFee);
                return initialFee;
            }

            if (now.Date != _date || now.Hour != _hour)
            {
                var newFee = _fee * new decimal(new Random().NextDouble());
                _instance = new UniversalFeesExchangeService(now.Hour, now.Date, newFee);
                return newFee;
            }

            return _fee;
        }
    }
}
