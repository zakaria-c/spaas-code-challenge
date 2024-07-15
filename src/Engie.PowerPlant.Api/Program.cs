using Engie.PowerPlant.Api.Validators;
using Engie.PowerPlant.Application.Mappings;
using Engie.PowerPlant.Application.Usecases.GenerateProductionPlan;
using Engie.PowerPlant.Core.Services.Implementations;
using Engie.PowerPlant.Core.Services.Interfaces;
using FluentValidation;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();


try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddSerilog();

    builder.Services.AddScoped<IMapper, Mapper>();
    builder.Services.AddScoped<IPowerPlanCombinationGenerator, PowerPlanCombinationGenerator>();
    builder.Services.AddScoped<IProductionPlanService, ProductionPlanService>();
    builder.Services.AddScoped<IProductionPlanGenerator, ProductionPlanGenerator>();
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GenerateProductionPlanRequestHandler>());

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddValidatorsFromAssemblyContaining<ProductionPlanValidator>();

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
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}


