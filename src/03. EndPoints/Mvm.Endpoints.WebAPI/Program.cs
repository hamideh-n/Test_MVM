
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
using Mvm.Endpoints.WebAPI;
using Mvm.Framework.Commands;
using Mvm.Framework.Exeptions;
using Mvm.Framework.Queries;
using Mvm.Infrastructures.Data.SqlServer;
using Mvm.Infrastructures.Data.SqlServer.Customers.Repositories;
using Mvm.Infrastructures.Data.SqlServer.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MvmDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<QueryDispatcher>();
builder.Services.AddTransient<CommandDispatcher>();
builder.Services.AddTransient<ICustomerCommandRepository, CustomerCommandRepository>();
builder.Services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
builder.Services.AddTransient<IQueryHandler<GetAllCustomerQuery, List<Customer>>, GetAllCustomerQueryHandler>();
builder.Services.AddTransient<CommandHandler<CreateCustomerCommand>, CreateCustomerCommandHandler>();
builder.Services.AddTransient<CommandHandler<EditCustomerCommand>, EditCustomerCommandHandler>();
builder.Services.AddTransient<CommandHandler<DeleteCustomerCommand>, DeleteCustomerCommandHandler>();

builder.Services.AddTransient<IQueryHandler<GetByIdQuery, Customer>, GetByIdQueryHandler>();
builder.Services.AddScoped<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
//app.UseMiddleware<ExceptionMiddleware>();
app.Run();