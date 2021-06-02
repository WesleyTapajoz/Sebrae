using Microsoft.EntityFrameworkCore;
using SebraeWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SebraeWebApi
{
    public class AspnetCore_EFCoreInMemory
    {
        public class ApiContext : DbContext
        {
            public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
            public DbSet<Conta> Contas { get; set; }
        }
    }
}
