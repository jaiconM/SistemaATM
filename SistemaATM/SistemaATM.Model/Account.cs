using SistemaATM.Model.Interface;

namespace SistemaATM.Model
{
    public class Account : IAccount
    {
        private readonly int _accountNumber;
        private readonly int _pin;

        public Account(int accountNumber, int pin)
        {
            _accountNumber = accountNumber;
            _pin = pin;
        }

        private decimal _availableBalance;

        public void SetAvailableBalance(decimal value)
        {
            _availableBalance = value;
        }
        public decimal AvailableBalance => _availableBalance;

        private decimal _totalBalance;
        public decimal TotalBalance => _totalBalance;

        public void SetTotalBalance(decimal value )
        {
            _totalBalance = value;
        }

        public bool ValidatePin(int pin)
        {
            return pin == _pin;
        }

        public void Credit(decimal value)
        {
            _availableBalance += value;
            _totalBalance += value;
        }

        public void Debit(decimal value)
        {
            _availableBalance -= value;
            _totalBalance -= value;
        }

        public override string ToString()
        {
            return
                $"AccountNumber:{_accountNumber} \nAvailableBalance:{_availableBalance}\nTotalBalance:{_totalBalance}";
        }
    }
}
