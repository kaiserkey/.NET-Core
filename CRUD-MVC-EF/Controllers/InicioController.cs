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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Contacto.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid) {

                contacto.FechaCreacion = DateTime.Now;
                _dbContext.Contacto.Add(contacto);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }


        public IActionResult Editar(int id)
        {
            if (id == 0 || id == null) {
                return NotFound();
            }

            var contacto = _dbContext.Contacto.Find(id);

            if (contacto == null) {
                return NotFound();
            }

            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid)
            {

                _dbContext.Contacto.Update(contacto);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var contacto = _dbContext.Contacto.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        public IActionResult Borrar(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var contacto = _dbContext.Contacto.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(Contacto contacto)
        {

            //var contacto = _dbContext.Contacto.FindAsync(IdContacto);
            
            if (contacto == null)
            {
                return View();
            }

            _dbContext.Remove(contacto);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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
