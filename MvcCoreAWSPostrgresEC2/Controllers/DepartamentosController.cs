using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSPostrgresEC2.Models;
using MvcCoreAWSPostrgresEC2.Repositories;

namespace MvcCoreAWSPostrgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> deptos = await
                this.repo.GetDepartamentosAsync();
            return View(deptos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento dept = await
                this.repo.FindDepartamentoAsync(id);
            return View(dept);
        }

        public IActionResult InsertDepartamento()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertDepartamento
            (Departamento departamento)
        {
            await this.repo.IsertDepartamentoAsync
                (departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }
    }
}
