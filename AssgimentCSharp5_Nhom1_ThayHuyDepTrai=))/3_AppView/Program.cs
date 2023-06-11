using _1_AppData._2_Treatment.Reponsitorys;
using _3_AppView.Call;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddMediatR(typeof(OrdelRepon).Assembly);
builder.Services.AddControllersWithViews();
builder.Services.AddRefitClient<IApiCallFood>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://localhost:7075/api"))/*.AddHttpMessageHandler<AuthorizationMessageHandler>()*/;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
