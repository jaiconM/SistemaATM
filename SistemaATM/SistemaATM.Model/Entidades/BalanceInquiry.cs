using SistemaATM.Model.MockDataBase;

namespace SistemaATM.Model.Entidades
{
    public class BalanceInquiry : Transaction
    {
        public BalanceInquiry(int currentAccountNumber, IScreen screen, BankDatabase bankDatabase)
            : base(screen, currentAccountNumber, bankDatabase) { }

        public override void Execute()
        {
            Screen.ClearDisplay();
            Screen.DisplayMessage("Seu saldo disponível é de:\t");
            Screen.DisplayCurrencyAmount(BankDatabase.GetAvailableBalance(CurrentAccountNumber));
            Screen.DisplayMessage("Seu saldo total é de:\t\t");
            Screen.DisplayCurrencyAmount(BankDatabase.GetTotalBalance(CurrentAccountNumber));
        }
    }
}