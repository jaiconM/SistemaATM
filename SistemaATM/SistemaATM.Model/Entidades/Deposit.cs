using SistemaATM.Model.MockDataBase;

namespace SistemaATM.Model.Entidades
{
    internal class Deposit : Transaction
    {
        private IDepositSlot _depositSlot;
        private IKeypad _keypad;

        public Deposit(int currentAccountNumber, IScreen screen, BankDatabase bankDatabase, IKeypad keypad, IDepositSlot depositSlot)
        : base(screen, currentAccountNumber, bankDatabase)
        {
            _keypad = keypad;
            _depositSlot = depositSlot;
        }

        public override void Execute()
        {
            var amount = PromptForDepositAmount();
            if (PromptForDepositSlot())
            {
                BankDatabase.Credit(CurrentAccountNumber, amount);
                Screen.ClearDisplay();
                Screen.DisplayMessageLine($"Operação realizada com sucesso.\nValor de {amount:C} será disponibilizado na sua conta após conferência.\n");
                return;
            }
            Screen.ClearDisplay();
            Screen.DisplayMessageLine("Operação cancelada.\nEnvelope não recebido.\n");
            return;
        }

        private decimal PromptForDepositAmount()
        {
            try
            {
                Screen.DisplayMessage("Digite o valor que está depositando: ");
                return _keypad.GetInput();
            }
            catch
            {
                Screen.ClearDisplay();
                Screen.DisplayMessageLine("Você não digitou uma opção de valor válida.\nValores numéricos sem centavos são válidos.\nTente novamente.\n");
                return PromptForDepositAmount();
            }
        }

        private bool PromptForDepositSlot()
        {
            try
            {
                Screen.DisplayMessageLine("\nInsira o envelope com o valor no local indicado");
                Screen.DisplayMessageLine("Digite:\n1 - Confirmar \t2 - Cancelar");
                if (_keypad.GetInput() == 1)
                {
                    return _depositSlot.IsDepositEnvelopeReceived();
                }
                return false;
            }
            catch
            {
                Screen.ClearDisplay();
                Screen.DisplayMessageLine("Opção Inválida.\n Tente novamente.\n");
                return PromptForDepositSlot();
            }

        }
    }
}