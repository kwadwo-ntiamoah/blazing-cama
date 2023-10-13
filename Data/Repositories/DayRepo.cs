using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DayRepo
    {
        private readonly AppDbContext _context;

        public DayRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Day>> Days()
        {
            return await _context.Days
                .Include(x => x.Programmes)
                .ToListAsync();
        }
    }
}
