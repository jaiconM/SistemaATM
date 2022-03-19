using System;

namespace SistemaATM.Model
{
    public class BalanceInquiry : Transaction
    {
        public BalanceInquiry(int accountNumber) : base(accountNumber) { }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
