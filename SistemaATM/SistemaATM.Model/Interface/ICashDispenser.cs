namespace SistemaATM.Model.Interface
{
    public interface ICashDispenser
    {
        void DispenseCash(int value);

        bool IsSufficientCashAvailable(int value);
    }
}