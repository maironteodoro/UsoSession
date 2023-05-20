using Microsoft.EntityFrameworkCore;

namespace Tratamento.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            Context context = app.ApplicationServices.GetRequiredService<Context>();
            context.Database.Migrate();
            if (!context.Usuarios.Any())
            {
                context.Usuarios.AddRange(
                    new Usuario { Password = "1234", UserName = "Mairon", EmailAddress = "maironteodoro@gmail.com" },
                    new Usuario { Password = "1234", UserName = "Ph", EmailAddress = "ph@gmail.com" },
                    new Usuario { Password = "1234", UserName = "davi", EmailAddress = "davi@gmail.com" });
                    

                context.SaveChanges();
            }
        }
    }
}
