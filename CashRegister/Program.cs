using AutoMapper;
using CashRegister.DependencyInjection;
using CashRegister.DependencyInjection.Profiles;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCashRegisterServices();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cash Register API", Version = "v1" });
    c.EnableAnnotations();
});

var mapperConfiguration = new MapperConfiguration(cfg => { 
    cfg.AddProfile<EmployeeProfile>();
    cfg.AddProfile<TaxProfile>();
    cfg.AddProfile<ProductProfile>();
    cfg.AddProfile<StockProfile>();
    cfg.AddProfile<TransactionProfile>();
});
mapperConfiguration.AssertConfigurationIsValid();

var mapper = new Mapper(mapperConfiguration);

builder.Services.AddScoped<IMapper,Mapper>(_ => mapper);

builder.Services.AddAutoMapper(typeof(EmployeeProfile));
builder.Services.AddAutoMapper(typeof(TaxProfile));
builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddAutoMapper(typeof(StockProfile));
builder.Services.AddAutoMapper(typeof(TransactionProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cash Register V1");

    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
