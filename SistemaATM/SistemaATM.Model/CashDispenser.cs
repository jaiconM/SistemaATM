using SistemaATM.Model.Interface;
using System;

namespace SistemaATM.Model
{
    public class CashDispenser : ICashDispenser
    {
        private int _billCount = 500;

        public void DispenseCash(int value)
        {
            if (IsSufficientCashAvailable(value))
            {
                _billCount -= value;
            }
        }

        public bool IsSufficientCashAvailable(int value)
        {
            return _billCount >= value;
        }
    }
}
