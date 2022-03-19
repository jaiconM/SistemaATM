
using SistemaATM.UserInterface;
using SistemaATM.Model.Entidades;

Console.WriteLine("================ SISTEMA ATM ================");
var atm = new ATM(new Screen(), new Keypad(), new DepositSlot());
atm.Run();
