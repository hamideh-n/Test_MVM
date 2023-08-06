using Microsoft.AspNetCore.Mvc;
using Mvm.Core.Domain.Customers.Commands;
using Mvm.Core.Domain.Customers.Entities;
using Mvm.Core.Domain.Customers.Queries;
using Mvm.Framework.API;
using Mvm.Framework.Commands;
using Mvm.Framework.Queries;


namespace Mvm.Endpoints.WebAPI.Controllers
{
    public class CustomerController : BaseController
    { 
        public CustomerController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher) : base
            (commandDispatcher, queryDispatcher)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] GetAllCustomerQuery query)
        {
            
           
            var result=await _queryDispatcher.Dispatch<List<Customer>>(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetById(GetByIdQuery query)
        {
            var result = await _queryDispatcher.Dispatch<Customer>(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerCommand command)
        {

            var result = await _commandDispatcher.Dispatch(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] EditCustomerCommand command)
        {
            var result = await _commandDispatcher.Dispatch(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand command)
        {
            var result = await _commandDispatcher.Dispatch(command);
            return Ok(result);
        }

    }
}
