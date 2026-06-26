using Exame.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Exame.Domain.Interfaces;
using Exame.Infrastructure.Repositories;
using Exame.Application.Interfaces;
using Exame.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoCosifRepository, ProdutoCosifRepository>();
builder.Services.AddScoped<IMovimentoManualRepository, MovimentoManualRepository>();
builder.Services.AddScoped<IProdutoAppService, ProdutoAppService>();
builder.Services.AddScoped<IMovimentoAppService, MovimentoAppService>();

const string AngularPolicy = "AngularPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(AngularPolicy, policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors(AngularPolicy);

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();