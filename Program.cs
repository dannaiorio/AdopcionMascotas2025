using AdopcionMascotas.Data; // namespace de tu AppDbContext
using Microsoft.EntityFrameworkCore;

namespace AdopcionMascotas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Cargar .env (credenciales admin)
            LoadEnvFile();
            
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            //Detalles de la sesion
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Duracion de la sesión
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDbConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static void LoadEnvFile()
        {
            try
            {
                var envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
                if (File.Exists(envPath))
                {
                    var lines = File.ReadAllLines(envPath);
                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                            continue;

                        var parts = line.Split('=', 2);
                        if (parts.Length == 2)
                        {
                            Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
                            Console.WriteLine($"Cargado env: {parts[0].Trim()} = {parts[1].Trim()}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(".env no encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar .env: {ex.Message}");
            }
        }
    }
}
