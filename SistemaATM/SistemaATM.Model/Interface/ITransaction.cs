namespace SistemaATM.Model.Interface
{
    public interface ITransaction
    {
        int AccountNumber { get; }

        void Execute();
    }
}