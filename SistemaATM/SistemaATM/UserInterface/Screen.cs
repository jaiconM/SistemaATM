namespace SistemaATM.UserInterface
{
    public class Screen : IScreen
    {
        public void DisplayMessage(string message) => Console.Write(message);

        public void DisplayMessageLine(string message) => Console.WriteLine(message);

        public void DisplayCurrencyAmount(decimal amount) => Console.WriteLine("{0:C}", amount);

        public void ClearDisplay()
        {
            Console.Clear();
            Console.WriteLine("================ SISTEMA ATM ================\n");
        }
    }
}
