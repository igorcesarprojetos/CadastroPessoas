using CadastroPessoas.Domain.Service;
using CadastroPessoas.Domain.Interface.Service;
using Microsoft.EntityFrameworkCore;
using CadastroPessoas.Domain.Interface.Repository;
using CadastroPessoas.Repository;
using CadastroPessoas.Repository.Context;


namespace CadastroPessoas.View
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //contexto Db
            builder.Services.AddDbContext<RepositoryPatternContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //injeção de dependência
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IPessoaService<>), typeof(PessoaService<>));

            //swagger
            builder.Services.AddMvc();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x.WithOrigins("https://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseHttpsRedirection();            

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
