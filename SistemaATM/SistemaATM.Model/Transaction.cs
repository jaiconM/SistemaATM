using SistemaATM.Model.Interface;

namespace SistemaATM.Model
{
    public abstract class Transaction : ITransaction
    {
        private readonly int _accountNumber;
        public int AccountNumber => _accountNumber;

        protected Transaction(int accountNumber)
        {
            _accountNumber = accountNumber;
        }

        public abstract void Execute();
    }
}
