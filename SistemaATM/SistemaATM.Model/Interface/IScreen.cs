namespace SistemaATM
{
    public interface IScreen
    {
        void DisplayCurrencyAmount(decimal amount);
        void DisplayMessage(string message);
        void DisplayMessageLine(string message);
        void ClearDisplay();
    }
}