using SistemaATM.Model.MockDataBase;

namespace SistemaATM.Model.Entidades
{
    public abstract class Transaction
    {
        protected IScreen Screen { get; private set; }
        protected int CurrentAccountNumber { get; private set; }
        protected BankDatabase BankDatabase { get; private set; }

        protected Transaction(IScreen screen, int currentAccountNumber, BankDatabase bankDatabase)
        {
            Screen = screen;
            CurrentAccountNumber = currentAccountNumber;
            BankDatabase = bankDatabase;
        }

        public abstract void Execute();
    }
}