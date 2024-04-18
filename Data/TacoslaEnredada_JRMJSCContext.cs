using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TacoslaEnredada_JRMJSC.Models;

namespace TacoslaEnredada_JRMJSC.Data
{
    public class TacoslaEnredada_JRMJSCContext : DbContext
    {
        public TacoslaEnredada_JRMJSCContext (DbContextOptions<TacoslaEnredada_JRMJSCContext> options)
            : base(options)
        {
        }

        public DbSet<TacoslaEnredada_JRMJSC.Models.Usuario> Usuario { get; set; } = default!;
    }
}
