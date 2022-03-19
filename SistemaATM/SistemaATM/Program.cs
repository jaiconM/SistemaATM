using SistemaATM.Model.MockDataBase;

Console.WriteLine("================ SISTEMA ATM ================");
AccountList.GetAccounts().ForEach(Console.WriteLine);