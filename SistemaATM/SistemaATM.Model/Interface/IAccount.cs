namespace SistemaATM.Model.Interface
{
    public interface IAccount
    {
        decimal AvailableBalance { get; }
        decimal TotalBalance { get; }

        void Credit(decimal value);
        void Debit(decimal value);
        bool ValidatePin(int pin);
    }
}