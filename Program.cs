using api_portaria.ContextBase;
using api_portaria.Interface;
using api_portaria.service;
using api_portaria.service.Mapper.Entrada;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x => x.AddPolicy("corsPolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
//services
builder.Services.AddScoped<IResponsavelService, ResponsavelService>();
builder.Services.AddScoped<IEntradaService,EntradaService>();

//mapper
builder.Services.AddAutoMapper(x => 
    x.AddProfile(typeof(EntradaMapping))
) ;

//context
var connectionString = builder.Configuration.GetConnectionString("portaria_matriz");
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Context>(op =>
    {
        op.UseNpgsql(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
