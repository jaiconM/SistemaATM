using SistemaATM.Model.MockDataBase;

namespace SistemaATM.Model.Entidades
{
    public abstract class Transaction
    {
        protected IScreen _screen;
        protected IKeypad _keypad;
        protected IDepositSlot _depositSlot;
        protected int _currentAccountNumber;
        protected BankDatabase _bankDatabase;

        public abstract void Execute();
    }
}