using CRUD_MVC_EF.Datos;
using CRUD_MVC_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUD_MVC_EF.Controllers
{
    public class InicioController : Controller
    {
        private readonly DBContext _dbContext;
        public InicioController(DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Contacto.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
