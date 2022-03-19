namespace SistemaATM.Model.MockDataBase
{
    public static class AccountList
    {
        private static List<Account> _contas = new List<Account>()
        {
            new Account(1111, 1111),
            new Account(2222, 2222)
        };

        public static List<Account> GetAccounts()
        {
            foreach (var conta in _contas)
            {
                conta.SetAvailableBalance(500);
                conta.SetTotalBalance(1000);
            }

            return _contas;
        }
    }
}