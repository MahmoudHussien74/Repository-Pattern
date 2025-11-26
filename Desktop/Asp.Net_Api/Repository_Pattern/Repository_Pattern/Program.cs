using Microsoft.EntityFrameworkCore;
using Repository_Pattern.Core;
using Repository_Pattern.Core.Interfaces;
using Repository_Pattern.EF;
using Repository_Pattern.EF.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ApplicationDbcontext>(option =>
        {
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });


        //builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

     


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}