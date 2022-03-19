using SistemaATM.Model.Interface;

namespace SistemaATM.Model
{
    public class BankDatabase : IBankDatabase
    {
        
        public bool AuthenticateUser(int accountNumber, int pin)
        {
            return true;
        }

        public decimal GetAvailableBalance()
        {
            return 0;
        }

        public decimal GetTotalBalance()
        {
            return 0;
        }

        public void Credit(decimal value)
        {

        }

        public void Debit(decimal value)
        {

        }
    }
}
