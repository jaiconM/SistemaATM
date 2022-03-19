using SistemaATM.Model.Interface;

namespace SistemaATM.Model
{
    public class Screen : IScreen
    {
        public void DisplayMessage(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
