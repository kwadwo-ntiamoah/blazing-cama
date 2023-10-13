using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserSubscriptionRepo
    {
        private readonly AppDbContext _context;

        public UserSubscriptionRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserSubscription> AddUserSubscription(UserSubscription userSubscription)
        {
            var sub = await _context.UserSubscriptions.AddAsync(userSubscription);
            await _context.SaveChangesAsync();

            return sub.Entity;
        }

        public async Task<UserSubscription> GetUserSubscription(string UserId)
        {
            return await _context.UserSubscriptions.Where(x => x.UserId == UserId).FirstOrDefaultAsync();
        }

        public async Task<List<UserSubscription>> GetUserSubscriptions()
        {
            return await _context.UserSubscriptions.ToListAsync();
        }
    }
}
