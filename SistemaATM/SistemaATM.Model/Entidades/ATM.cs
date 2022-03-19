using SistemaATM.Model.MockDataBase;

namespace SistemaATM.Model.Entidades
{
    public class ATM
    {
        private bool _userAuthenticated;
        private int _currentAccountNumber;
        private IScreen _screen;
        private IKeypad _keypad;
        private IDepositSlot _depositSlot;
        private CashDispenser _cashDispenser;
        private BankDatabase _bankDatabase;

        private enum MenuOption
        {
            BALANCE_INQUIRY = 1,
            WITHDRAWAL = 2,
            DEPOSIT = 3,
            EXIT_ATM = 4
        }

        public ATM(IScreen screen, IKeypad keypad, IDepositSlot depositSlot)
        {
            _userAuthenticated = false;
            _currentAccountNumber = 0;
            _screen = screen;
            _keypad = keypad;
            _depositSlot = depositSlot;
            _cashDispenser = new CashDispenser();
            _bankDatabase = new BankDatabase();
        }

        public void Run()
        {
            while (true)
            {
                while (!_userAuthenticated)
                {
                    _screen.DisplayMessageLine("\nBem-vindo!");
                    AuthenticateUser();
                }

                PerformTransactions();
                _userAuthenticated = false;
                _currentAccountNumber = 0;
                _screen.DisplayMessageLine("\nObrigado! Até a próxima!");
            }
        }

        private void AuthenticateUser()
        {
            _screen.DisplayMessage("\nPor favor, informe o número da sua conta: ");
            int accountNumber = _keypad.GetInput();

            _screen.DisplayMessage("\nInforme seu PIN: ");
            int pin = _keypad.GetInput();

            _userAuthenticated = _bankDatabase.AuthenticateUser(accountNumber, pin);

            if (_userAuthenticated)
                _currentAccountNumber = accountNumber;
            else
                _screen.DisplayMessageLine("Número da conta ou PIN inválidos. Tente novamente.");
        }

        private void PerformTransactions()
        {
            Transaction currentTransaction;
            bool userExited = false;

            while (!userExited)
            {
                int mainMenuSelection = DisplayMainMenu();

                switch ((MenuOption)mainMenuSelection)
                {
                    case MenuOption.BALANCE_INQUIRY:
                    case MenuOption.WITHDRAWAL:
                    case MenuOption.DEPOSIT:
                        currentTransaction = CreateTransaction(mainMenuSelection);
                        currentTransaction.Execute();
                        break;
                    case MenuOption.EXIT_ATM:
                        _screen.DisplayMessageLine("\nSaíndo do sistema...");
                        userExited = true;
                        break;
                    default:
                        _screen.DisplayMessageLine("\nVocê não digitou uma opção válida. Tente novamente.");
                        break;
                }
            }
        }

        private int DisplayMainMenu()
        {
            try
            {
                _screen.DisplayMessageLine("\nMenu Principal:");
                _screen.DisplayMessageLine("1 - Saldo");
                _screen.DisplayMessageLine("2 - Sacar");
                _screen.DisplayMessageLine("3 - Depositar");
                _screen.DisplayMessageLine("4 - Sair\n");
                _screen.DisplayMessage("Digite uma opção: ");
                return _keypad.GetInput();
            }
            catch
            {
                _screen.DisplayMessageLine("\nVocê não digitou uma opção válida. Tente novamente.");
                return DisplayMainMenu();
            }
        }

        private Transaction CreateTransaction(int type)
        {
            Transaction temp = null;

            switch ((MenuOption)type)
            {
                case MenuOption.BALANCE_INQUIRY:
                    temp = new BalanceInquiry(_currentAccountNumber, _screen, _bankDatabase);
                    break;
                case MenuOption.WITHDRAWAL:
                    temp = new Withdrawal(_currentAccountNumber, _screen, _bankDatabase, _keypad, _cashDispenser);
                    break;
                case MenuOption.DEPOSIT:
                    temp = new Deposit(_currentAccountNumber, _screen, _bankDatabase, _keypad, _depositSlot);
                    break;
            }

            return temp;
        }
    }
}
