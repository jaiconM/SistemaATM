namespace SistemaATM.Model.Interface
{
    public interface IBankDatabase
    {
        bool AuthenticateUser(int accountNumber, int pin);
        void Credit(decimal value);
        void Debit(decimal value);
        decimal GetAvailableBalance();
        decimal GetTotalBalance();
    }
}