
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvm.Framework.Commands;
using Mvm.Framework.Queries;

namespace Mvm.Framework.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class BaseController: ControllerBase
    {
        public readonly CommandDispatcher _commandDispatcher;
        public readonly QueryDispatcher _queryDispatcher;
       
        public BaseController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
           
        }
    }
}
