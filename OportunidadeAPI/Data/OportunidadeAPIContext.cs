using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace OportunidadeAPI.Data
{
    public class OportunidadeAPIContext : DbContext
    {
        public OportunidadeAPIContext (DbContextOptions<OportunidadeAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Oportunidade> Oportunidade { get; set; } = default!;
    }
}
