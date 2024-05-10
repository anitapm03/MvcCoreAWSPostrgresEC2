using Microsoft.EntityFrameworkCore;
using MvcCoreAWSPostrgresEC2.Data;
using MvcCoreAWSPostrgresEC2.Models;

namespace MvcCoreAWSPostrgresEC2.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            return await this.context.Departamentos.
                FirstOrDefaultAsync(x => x.IdDepartamento == id);
        }

        public async Task IsertDepartamentoAsync
            (int id, string nombre, string localidad)
        {
            Departamento dept = new Departamento
            {
                IdDepartamento = id,
                Nombre = nombre,
                Localidad = localidad
            };
            this.context.Departamentos.Add(dept);
            await this.context.SaveChangesAsync();
        }
    }
}
