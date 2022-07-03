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
                    FilePath = builder.Configuration.GetValue<string>("FilePath"),
                    RequireHTTPS = builder.Configuration.GetValue<bool>("RequireHTTPS")
                };
            });
            builder.Services.AddMediatR(typeof(CalculateFeature));
            builder.Services.AddSingleton<Interfaces.ILogger, Logger>();
            builder.Services.AddSingleton<ICalculator, Calculator>();
            builder.Services.AddSingleton<IFileStorage, FileStorage>();

            var app = builder.Build();

            var appConfig = app.Services.GetService<IApplicationConfiguration>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            if (appConfig.RequireHTTPS)
            {
                app.UseHttpsRedirection();
            }

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