using CashRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Core.Repositories
{
    public interface IPaymentRepository
    {
        public Task<Payment?> GetPaymentById(int id);

        public Task CreatePayment(Payment payment);
    }
}
