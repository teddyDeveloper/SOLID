using Solid.DeveloperTest.Types;

namespace Solid.DeveloperTest.PayementInterfaces
{
    public interface IChapsPayment
    {
        bool isAllowedPayementScheme(Account account);
    }
}