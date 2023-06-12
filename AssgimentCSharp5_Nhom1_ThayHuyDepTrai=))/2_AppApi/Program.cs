using _1_AppData._1_DataProcessing.Context;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DBContext_Assgiment>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString(""));
});
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<IBillServices, BillServices>();
//builder.Services.AddTransient<IRoleServices, RoleServices>();
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
