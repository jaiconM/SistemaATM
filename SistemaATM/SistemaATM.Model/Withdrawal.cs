using System;

namespace SistemaATM.Model
{
    public class Withdrawal : Transaction
    {
        private readonly decimal _amount;
        public Withdrawal(int accountNumber, decimal amount) : base(accountNumber)
        {
            _amount = amount;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
