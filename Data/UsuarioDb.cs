using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TacoslaEnredada_JRMJSC.Models;

    public class UsuarioDb : DbContext
    {
        public UsuarioDb (DbContextOptions<UsuarioDb> options)
            : base(options)
        {
        }

        public DbSet<TacoslaEnredada_JRMJSC.Models.Usuario> Usuario { get; set; } = default!;

public DbSet<TacoslaEnredada_JRMJSC.Models.Productos> Productos { get; set; } = default!;
    }
