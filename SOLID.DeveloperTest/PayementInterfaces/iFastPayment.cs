using Solid.DeveloperTest.Types;

namespace Solid.DeveloperTest.PayementInterfaces
{
    public interface iFastPayment
    {
        //bool CheckBalance(Account account, decimal requestAmount);
        //  

        bool isAllowedPayementScheme(Account account, decimal amount);
    }
}