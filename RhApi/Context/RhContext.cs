using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RhApi.Models;

namespace RhApi.Context
{
    public class RhContext : DbContext
    {
        public RhContext(DbContextOptions<RhContext> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionario { get; set; }
    }
}