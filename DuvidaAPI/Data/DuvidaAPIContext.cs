using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DuvidaAPI.Data
{
    public class DuvidaAPIContext : DbContext
    {
        public DuvidaAPIContext (DbContextOptions<DuvidaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Duvidas> Duvidas { get; set; } = default!;
    }
}
