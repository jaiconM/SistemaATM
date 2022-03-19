using SistemaATM.Model.MockDataBase;

namespace SistemaATM.Model.Entidades
{
    public class BalanceInquiry : Transaction
    {
        public BalanceInquiry(int currentAccountNumber, IScreen screen, BankDatabase bankDatabase)
        {
            _currentAccountNumber = currentAccountNumber;
            _screen = screen;
            _bankDatabase = bankDatabase;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}