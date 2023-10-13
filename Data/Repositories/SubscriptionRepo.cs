using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SubscriptionRepo
    {
        private readonly AppDbContext _context;

        public SubscriptionRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Subscription> AddSubscription(Subscription subscription)
        {
            var sub = await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();

            return sub.Entity;
        }

        public async Task<List<Subscription>> GetSubscriptions()
        {
            return await _context.Subscriptions.ToListAsync();
        }
    }
}
