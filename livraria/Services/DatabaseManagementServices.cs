using livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace livraria.Services;

public static class DatabaseManagementService
{

    //quando a aplicação for criada esse método será executado, com isso o banco de dados e a tabela serão criados
    public static void MigrationInitialisation(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            //obtento uma instancia do serviço do contexto e aplicanto um Migration
            var serviceDb = serviceScope.ServiceProvider
                            .GetService<AppDbContext>();

            //cria o banco de dados e as tabelas caso eles não existam
            if (serviceDb != null)
            {
                serviceDb.Database.Migrate();
            }
        }

    }
}








