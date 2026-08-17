using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uc_10_Ryan_00003_Razor.Models;

namespace Uc_10_Ryan_00003_Razor.Data
{
    public class Uc_10_Ryan_00003_RazorContext : DbContext
    {
        public Uc_10_Ryan_00003_RazorContext (DbContextOptions<Uc_10_Ryan_00003_RazorContext> options)
            : base(options)
        {
        }

        public DbSet<Uc_10_Ryan_00003_Razor.Models.Coffe> Coffe { get; set; } = default!;
    }
}
