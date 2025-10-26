using BlazorApp.Components;
using BlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5075/")
});

builder.Services.AddHttpClient<IUserService, HttpUserService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5075/");
});

builder.Services.AddHttpClient<IPostService, HttpPostService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5075/");
});

builder.Services.AddHttpClient<ICommentService, HttpCommentService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5075/");
});

builder.Services.AddScoped<IUserService, HttpUserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForErrors: true);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
