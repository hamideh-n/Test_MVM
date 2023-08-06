
using FluentValidation;
using Mvm.Core.Domain.Customers.Commands;

namespace Mvm.Core.ApplicationServices.Customers.Commands
{
    public class CreateCustomerCommandValidator: AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c=>c.Firstname).NotEmpty().WithMessage("نام نمیتواند خالی باشد").MaximumLength(50).WithMessage("نام نمیتواند بیشتر از 50  کاراکتر باشد");

            RuleFor(c => c.Lastname).NotEmpty().WithMessage("نام خانوادگی نمیتواند خالی باشد").MaximumLength(50).WithMessage("نام خانوادگی نمیتواند بیشتر از50کاراکتر باشد");

            RuleFor(c => c.Email).NotEmpty().WithMessage(" ایمیل  نمیتواند خالی باشد").EmailAddress().WithMessage(" ایمیل صحیح نیست");

            RuleFor(c => c.BankAccountNumber).NotEmpty().WithMessage(" شماره حساب بانکی  نمیتواند خالی باشد").MaximumLength(50).WithMessage("شماره حساب بانکی نمیتواند بیشتر از 50 کاراکتر باشد ").CreditCard().WithMessage("شماره حساب بانکی  صحیح نیست ");

            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage(" شماره موبایل  نمیتواند خالی باشد").MaximumLength(11).WithMessage("شماره موبایل نمیتواند بیشتر از 11 باشد ").Matches(@"^(098|0098|98|\+98|0)?9(0[0-5]|[1 3]\d|2[0-3]|9[0-9]|41)\d{7}$").WithMessage("شماره موبایل صحیح نیست  ");


        }

    }
}
