
namespace Mvm.Framework.Commands
{
    public class CommandDispatcher
    {
        private readonly IServiceProvider _provider;

        public CommandDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<CommandResult> Dispatch(ICommand command)
        {
            Type type = typeof(CommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _provider.GetService(handlerType);
            CommandResult result =await handler.Handle((dynamic)command);
            return result;
        }
    }
}
