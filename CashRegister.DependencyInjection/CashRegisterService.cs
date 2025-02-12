using CashRegister.Application.UseCases;
using CashRegister.Core.Repositories;
using CashRegister.Infrastructure;
using CashRegister.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.DependencyInjection
{
    public static class CashRegisterService
    {
        public static IServiceCollection AddCashRegisterServices(this IServiceCollection services)
        {
            services.AddDbContext<CashRegisterContext>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockMovementRepository, StockMovementRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<ITaxRepository, TaxRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<EmployeeUseCase>();
            services.AddScoped<ProductUseCase>();
            services.AddScoped<StockUseCase>();
            services.AddScoped<TaxUseCase>();

            return services;
        }
    }
}
