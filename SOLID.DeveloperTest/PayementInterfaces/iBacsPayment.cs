using Solid.DeveloperTest.Types;

namespace Solid.DeveloperTest.Services
{
    public interface iBacsPayment
    {
        bool isAllowedPayementScheme( Account account);
    }
}