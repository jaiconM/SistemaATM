using SistemaATM.Model.MockDataBase;

namespace SistemaATM.Model.Entidades
{
    internal class Deposit : Transaction
    {
        public Deposit(int currentAccountNumber, IScreen screen, BankDatabase bankDatabase, IKeypad keypad, IDepositSlot depositSlot)
        {
            _currentAccountNumber = currentAccountNumber;
            _screen = screen;
            _bankDatabase = bankDatabase;
            _keypad = keypad;
            _depositSlot = depositSlot;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}