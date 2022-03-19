using SistemaATM.Model.Interface;
using System;

namespace SistemaATM.Model
{
    public class Keypad : IKeypad
    {
        public int GetInput()
        {
            Console.WriteLine("Digite algo: ");
            return Console.Read();
        }
    }
}
