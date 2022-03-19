
using SistemaATM.UserInterface;
using SistemaATM.Model.Entidades;

Console.WriteLine("================ SISTEMA ATM ================");
ATM theATM = new ATM(new Screen(), new Keypad(), new DepositSlot());
theATM.Run();
