using Assignment_CS5_Share._1_Models;
using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Assignment_Context>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IFoodServices, FoodServices>();
builder.Services.AddTransient<IExpress_DeliveryServices, Express_DeliveryServices>();
builder.Services.AddTransient<IComboServices, ComboServices>();
builder.Services.AddTransient<IRoleServices, RoleServices>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddTransient<ICouponServices, CouponServices>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderDetailService, OrderDetailService>();
builder.Services.AddTransient<IBillServices, BillServices>();
builder.Services.AddTransient<IBillDetailServices, BillDetailServices>();

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