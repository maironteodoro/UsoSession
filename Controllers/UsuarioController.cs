using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tratamento.Models;

namespace Tratamento.Controllers
{
    public class UsuarioController : Controller
    {
        public Context context;

        public UsuarioController(Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index(int pagina = 1)
        {
            //retorna todos os produtos cadastrados
            return View(context.Usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {
            context.Add(usuario);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(context.Usuarios.Where(m => m.UsuarioId == id).First());
        }

        public IActionResult Edit(int id)
        {
            return View(context.Usuarios.Where(m => m.UsuarioId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(context.Usuarios.Where(m => m.UsuarioId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Usuario usuario)
        {
            context.Remove(context.Usuarios.Where(f => f.UsuarioId == usuario.UsuarioId).FirstOrDefault());
            context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
