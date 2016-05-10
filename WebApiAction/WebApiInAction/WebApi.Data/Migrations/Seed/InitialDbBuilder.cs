using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DynamicFilters;

namespace WebApi.Data.Migrations.Seed
{
    public class InitialDbBuilder
    {
        private readonly ApplicationDbContext _context;

        public InitialDbBuilder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();            

            _context.SaveChanges();
        }
    }
}
