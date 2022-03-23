using SistemaATM.Model.Entidades;

namespace SistemaATM.Model.MockDataBase
{
    public class BankDatabase
    {
        private List<Account> _accounts;

        public BankDatabase()
        {
            _accounts = new List<Account>
            {
                new Account(12345, 54321, 1000.00M, 1200.00M),
                new Account(98765, 56789, 0200.00M, 0200.00M)
            };
        }

        public bool AuthenticateUser(int userAccountNumber, int userPIN)
        {
            var userAccount = GetAccount(userAccountNumber);

            if (userAccount != null)
                return userAccount.ValidatePIN(userPIN);
            else
                return false;
        }

        public decimal GetAvailableBalance(int userAccountNumber) => GetAccount(userAccountNumber).AvailableBalance;

        public decimal GetTotalBalance(int userAccountNumber) => GetAccount(userAccountNumber).TotalBalance;

        public void Credit(int userAccountNumber, decimal amount)
        {
            var userAccount = GetAccount(userAccountNumber);
            userAccount.Credit(amount);
        }

        public void Debit(int userAccountNumber, decimal amount)
        {
            var userAccount = GetAccount(userAccountNumber);
            userAccount.Debit(amount);
        }
        private Account GetAccount(int accountNumber) => _accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
    }
}
