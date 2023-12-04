using Discount.API.Extensions;
using Discount.API.Grpc;
using Discount.API.Repositories;
using Discount.API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.MigrateDatabase<Program>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddGrpc();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapGrpcService<DiscountService>();
app.MapControllers();

app.Run();
