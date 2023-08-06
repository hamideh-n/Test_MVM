

namespace Mvm.Framework.Extention
{
    public abstract class CustomerException: Exception
    {
        protected CustomerException(string message):base(message)
        {}
    }
}
