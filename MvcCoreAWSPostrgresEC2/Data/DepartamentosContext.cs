using Microsoft.EntityFrameworkCore;
using MvcCoreAWSPostrgresEC2.Models;

namespace MvcCoreAWSPostrgresEC2.Data
{
    public class DepartamentosContext: DbContext
    {
        public DepartamentosContext
            (DbContextOptions<DepartamentosContext> options) 
        : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
