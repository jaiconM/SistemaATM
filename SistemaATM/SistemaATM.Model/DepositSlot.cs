using SistemaATM.Model.Interface;

namespace SistemaATM.Model
{
    public class DepositSlot : IDepositSlot
    {
        public bool IsEnvelopeReceived()
        {
            return true;
        }
    }
}
