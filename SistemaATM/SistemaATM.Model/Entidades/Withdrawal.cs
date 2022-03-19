using SistemaATM.Model.MockDataBase;

namespace SistemaATM.Model.Entidades
{
    public class Withdrawal : Transaction
    {
        private CashDispenser _cashDispenser;

        public Withdrawal(int currentAccountNumber, IScreen screen, BankDatabase bankDatabase, IKeypad keypad, CashDispenser cashDispenser)
        {
            _currentAccountNumber = currentAccountNumber;
            _screen = screen;
            _bankDatabase = bankDatabase;
            _keypad = keypad;
            _cashDispenser = cashDispenser;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
