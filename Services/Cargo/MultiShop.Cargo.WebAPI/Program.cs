using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Cargo.WebAPI.Context;
using MultiShop.Cargo.WebAPI.Entities;
using MultiShop.Cargo.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCargo";
    opt.RequireHttpsMetadata = false;
});
builder.Services.AddDbContext<CargoContext>();
builder.Services.AddScoped<IRepository<CargoCompany>, Repository<CargoCompany>>();
builder.Services.AddScoped<IRepository<CargoCustomer>, Repository<CargoCustomer>>();
builder.Services.AddScoped<IRepository<CargoDetail>, Repository<CargoDetail>>();
builder.Services.AddScoped<IRepository<CargoOperation>, Repository<CargoOperation>>();
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

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();