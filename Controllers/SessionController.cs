using Microsoft.AspNetCore.Mvc;
using Tratamento.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
namespace Tratamento.Controllers
{
    public class SessionController: Controller
    {
        private static IList<Usuario> usuarios = new List<Usuario>();
        public IActionResult Index()
        {
            var acesso = HttpContext.Session.GetString("usuario_session");
            if (acesso != null)
                return View(usuarios);
            else
                return View("Login");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            usuarios.Add(usuario);
            usuario.UsuarioId = usuarios.Select(u => u.UsuarioId).Max() + 1 ;
            return RedirectToAction ("Index");
        }
        //Login
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var confirma = usuarios.Where(u => u.EmailAddress.Equals(email) && u.Password.Equals(senha)).FirstOrDefault();
            if (confirma != null)
            {
                HttpContext.Session.SetString("usuario_session", confirma.UserName);
                return RedirectToAction("Correto");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Correto()
        {
            return View();
        }
    }
}
