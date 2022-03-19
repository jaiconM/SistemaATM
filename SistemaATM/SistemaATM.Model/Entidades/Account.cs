namespace SistemaATM.Model.Entidades
{
    public class Account
    {
        private int _accountNumber;
        private int _pin;
        private decimal _availableBalance;
        private decimal _totalBalance;

        public Account(int accountNumber, int pin, decimal availableBalance, decimal totalBalance)
        {
            _accountNumber = accountNumber;
            _pin = pin;
            _availableBalance = availableBalance;
            _totalBalance = totalBalance;
        }

        public int AccountNumber => _accountNumber;

        public decimal AvailableBalance => _availableBalance;

        public decimal TotalBalance => _totalBalance;

        public bool ValidatePIN(int userPIN) => (userPIN == _pin);

        public void Credit(decimal amount) => _totalBalance += amount;

        public void Debit(decimal amount)
        {
            _availableBalance -= amount;
            _totalBalance -= amount;
        }
    }
}
