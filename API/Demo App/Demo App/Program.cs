
using Demo_App.Database;
using Demo_App.Implementation;
using Demo_App.Services;
using Microsoft.EntityFrameworkCore;

namespace Demo_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //DB connection
            builder.Services.AddDbContext<DataContext>(option =>
                option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddCors(option =>
            {
                option.AddDefaultPolicy(bulider =>
                {
                    bulider.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSwaggerUI(configure => configure.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
            app.UseCors();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
