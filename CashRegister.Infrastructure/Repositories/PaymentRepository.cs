using CashRegister.Core.Entities;
using CashRegister.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Infrastructure.Repositories
{
    public class PaymentRepository(CashRegisterContext cashRegisterContext) : IPaymentRepository
    {
        public async Task CreatePayment(Payment payment)
        {
            cashRegisterContext.Payment.Add(payment);
            await cashRegisterContext.SaveChangesAsync();
        }

        public async Task<Payment?> GetPaymentById(int id)
        {
            return await cashRegisterContext.Payment.FindAsync(id);
        }
    }
}
