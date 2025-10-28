using Microsoft.AspNetCore.Identity;
using MesaListo.Models;

namespace MesaListo.Data
{
    public static class IdentitySeed
    {
        public static async Task SeedDataAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "Restaurante", "Cliente" };

            // Crear roles si no existen
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Usuario Admin
            var adminEmail = "admin@mesalisto.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Nombre = "Administrador General"
                };
                var result = await userManager.CreateAsync(admin, "Admin123!");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "Admin");
            }

            // Usuario Restaurante por defecto
            var restEmail = "tacosAyAyAy@email.com";
            if (await userManager.FindByEmailAsync(restEmail) == null)
            {
                var restaurante = new ApplicationUser
                {
                    UserName = restEmail,
                    Email = restEmail,
                    Nombre = "TacosAyAyAy",
                    Direccion = "La Guadalupana Zona 15",
                    Telefono = "74004141"
                };
                var result = await userManager.CreateAsync(restaurante, "Rest123!");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(restaurante, "Restaurante");
            }
        }
    }
}
