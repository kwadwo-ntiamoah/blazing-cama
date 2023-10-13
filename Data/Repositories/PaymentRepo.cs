using Data.Enums;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PaymentRepo
    {
        private readonly AppDbContext _context;

        public PaymentRepo(AppDbContext context)
        {
            _context = context;   
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            var pmnt = await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();

            return pmnt.Entity;
        }

        public async Task<Payment> UpdatePayment(string TransRef, PaymentStatus status)
        {
            var payment = await _context.Payments.Where(x => x.TransRef == TransRef).FirstOrDefaultAsync();

            if (payment != null)
            {
                await _context.Payments.ExecuteUpdateAsync(s => s.SetProperty(x => x.Status, status));
            }

            return payment;
        }

        public async Task<List<Payment>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }
    }
}
