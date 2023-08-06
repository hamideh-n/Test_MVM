using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Mvm.Core.ApplicationServices.Customers.Commands;
using Mvm.Core.ApplicationServices.Customers.Queries;
using Mvm.Core.Domain.Customers.Commands;
using Mvm.Core.Domain.Customers.Entities;
using Mvm.Core.Domain.Customers.Queries;
using Mvm.Core.Domain.Customers.Repositories;
using Mvm.Core.Domain.UnitOfWork;
using Mvm.Framework.Commands;
using Mvm.Framework.Exeptions;
using Mvm.Framework.Queries;
using Mvm.Infrastructures.Data.SqlServer;
using Mvm.Infrastructures.Data.SqlServer.Customers.Repositories;
using Mvm.Infrastructures.Data.SqlServer.UnitOfWork;

namespace Mvm.Endpoints.WebAPI
{
    public static class HostingExtentions
    {

        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
           
            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
           
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();
            //app.UseMiddleware<ExceptionMiddleware>();


            return app;
        }
    }
}
