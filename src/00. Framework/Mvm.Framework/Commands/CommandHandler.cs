

namespace Mvm.Framework.Commands
{
    public abstract class CommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly CommandResult _result = new CommandResult();
      
        public CommandHandler()
        {
           
        }
       
        protected CommandResult Ok()
        {
            SetOkData();
            return _result;
        }
       
        protected CommandResult Ok(string message)
        {
            SetOkData();
            _result.Message = "";
            return _result;
        }
       
        private void SetOkData()
        {
            _result.ClearErrors();
            _result.IsSuccess = true;
        }
        protected CommandResult Failure()
        {
            SetFailureData();
            return _result;
        }
        protected CommandResult Failure(string message)
        {
            SetFailureData();
            _result.Message = message;
            return _result;
        }
       
        private void SetFailureData()
        {
            _result.IsSuccess = false;
        }
        protected void AddError(string error)
        {
            _result.AddError(error);
        }
      
        public abstract Task<CommandResult> Handle(TCommand command);

    }
}
