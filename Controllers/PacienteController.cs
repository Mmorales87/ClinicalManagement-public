using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace turnos.Controllers
{
    public class PacienteController : Controller
    {
        private readonly TurnosContext _context;

        public PacienteController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Paciente.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.IdPaciente == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }


        
        public IActionResult Create()
        {
            return View();
        }


[HttpPost]
[ValidateAntiForgeryToken]  /* Esta propiedad lo que hace es que nuestro metodo Create() ha sido 
ejecutado a traves del formulario, y que no ha sido ejecutado mediante la URL del navegador.
Esto lo que previene es ataques desde fuera de nuestra aplicacion, es decir usuarios malintencionados
que quieren modificar nuestros datos de la aplicacion pero no lo estan haciendo a traves del formulario
de la vista del usuario, si no que lo estan haciendo cambiando los parametros en la URL de nuestra
aplicacion. Para evitar estos ataques malintencionados colocamos estra propiedad. */
        public async Task<IActionResult> Create([Bind("IdPaciente,Nombre,Apellido,Direccion,Telefono,Email")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }


        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null)
            {
                return NotFound();  /*Con el metodo notfound lo que devolvemos es un error 404 a la vista del usuario*/
            }

            var paciente = await _context.Paciente.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }


         [HttpPost]
         [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaciente,Nombre,Apellido,Direccion,Telefono,Email")] Paciente paciente)
        {
            if (id != paciente.IdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var paciente = await _context.Paciente.FirstOrDefaultAsync(e => e.IdPaciente == id);

            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }


[HttpPost, ActionName("Delete")] /* ActionName Coloca un alias al metodo, para no tener que cambiar el
nombre del metodo en la vista */
[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}