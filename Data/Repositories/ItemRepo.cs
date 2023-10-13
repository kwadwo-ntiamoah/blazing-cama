using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ItemRepo
    {
        private readonly AppDbContext _context;
        public ItemRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetItems()
        {
            return await _context.Items
                .Include(x => x.Category)
                .ToListAsync();
        }

        public Item GetItem(int itemId)
        {
            return _context.Items.Where(x => x.Id == itemId).FirstOrDefault();
        }
    }
}
