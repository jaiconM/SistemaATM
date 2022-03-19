using System;

namespace SistemaATM.Model
{
    public class Deposit : Transaction
    {
        private readonly decimal _amount;
        public Deposit(int accountNumber, decimal amount) : base(accountNumber)
        {
            _amount = amount;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
