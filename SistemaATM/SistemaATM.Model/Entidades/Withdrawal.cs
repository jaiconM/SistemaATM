using SistemaATM.Model.MockDataBase;

namespace SistemaATM.Model.Entidades
{
    public class Withdrawal : Transaction
    {
        private CashDispenser _cashDispenser;
        private IKeypad _keypad;

        public Withdrawal(int currentAccountNumber, IScreen screen, BankDatabase bankDatabase, IKeypad keypad, CashDispenser cashDispenser)
        : base(screen, currentAccountNumber, bankDatabase)
        {
            _keypad = keypad;
            _cashDispenser = cashDispenser;
        }

        public override void Execute()
        {
            var finalizouSaque = false;
            while (finalizouSaque == false)
            {
                var option = DisplayMenuOfAmounts();
                var amount = 0;
                switch (option)
                {
                    case 1: amount = 20; break;
                    case 2: amount = 40; break;
                    case 3: amount = 60; break;
                    case 4: amount = 100; break;
                    case 5: amount = 200; break;
                    case 6: Screen.ClearDisplay(); return;
                }

                if (_cashDispenser.IsSufficientCashAvailable(amount) == false)
                {
                    Screen.ClearDisplay();
                    Screen.DisplayMessageLine("O ATM não tem dinheiro suficiente. Tente um valor menor ou outro equipamento.\n");
                }
                else
                {

                    if (BankDatabase.GetAvailableBalance(CurrentAccountNumber) < (amount))
                    {
                        Screen.ClearDisplay();
                        Screen.DisplayMessageLine("Saldo Insuficiente\n");
                    }
                    else
                    {
                        Screen.ClearDisplay();
                        _cashDispenser.DispenseCash(amount);
                        BankDatabase.Debit(CurrentAccountNumber, amount);
                        Screen.DisplayMessageLine("Saque realizado com $uce$$o. Retire suas notas no dispenser.");
                        finalizouSaque = true;
                    }
                }
            }
        }

        private int DisplayMenuOfAmounts()
        {
            try
            {
                Screen.DisplayMessageLine("Opções de Saque:\n");
                Screen.DisplayMessageLine("1 - R$ 20,00\t\t4 - $100,00");
                Screen.DisplayMessageLine("2 - R$ 40,00\t\t5 - $200,00");
                Screen.DisplayMessageLine("3 - R$ 60,00\t\t6 - Cancelar transação\n");
                Screen.DisplayMessage("Digite uma opção de saque: ");

                var option = _keypad.GetInput();
                if (option >= 1 && option <= 6)
                {
                    return option;
                }
                throw new Exception();
            }
            catch
            {
                Screen.ClearDisplay();
                Screen.DisplayMessageLine("Você não digitou uma opção válida. Tente novamente.\n");
                return DisplayMenuOfAmounts();
            }
        }
    }
}
