using MediatR;
using ReactAccurateCalculator.Features;
using ReactAccurateCalculator.Interfaces;
using ReactAccurateCalculator.Services;

namespace ReactAccurateCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IApplicationConfiguration>((sp) =>
            {
                
                return new ApplicationConfiguration
                {
                    FilePath = builder.Configuration["FilePath"]
                };
            });
            builder.Services.AddMediatR(typeof(CalculateFeature));
            builder.Services.AddSingleton<Interfaces.ILogger, Logger>();
            builder.Services.AddSingleton<ICalculator, Calculator>();
            builder.Services.AddSingleton<IFileStorage, FileStorage>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(configuration =>
            {
                configuration.AllowAnyHeader();
                configuration.AllowAnyMethod();
                configuration.AllowAnyOrigin();
            });

            app.MapControllers();
            app.Services.GetService<Interfaces.ILogger>().Log(nameof(ReactAccurateCalculator), $"Started {nameof(ReactAccurateCalculator)}");
            app.Run();
        }
    }
}