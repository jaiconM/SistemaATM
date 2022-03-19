namespace SistemaATM.UserInterface
{
    public class Keypad : IKeypad
    {
        public int GetInput() => Convert.ToInt32(Console.ReadLine());
    }

}
