using MultiShop.Discount.Context;
using MultiShop.Discount.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<DapperContext>();
builder.Services.AddTransient<IDiscountService, DiscountService>();


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
