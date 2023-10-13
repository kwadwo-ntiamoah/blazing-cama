using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProgrammeRepo
    {
        private readonly AppDbContext _context;

        public ProgrammeRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Programme> AddProgramme(int DayId, Programme programme)
        {
            var prog = await _context.Programmes.AddAsync(programme);
            await _context.SaveChangesAsync();

            return prog.Entity;
        }
    }
}
