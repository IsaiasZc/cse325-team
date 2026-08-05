using MarketInventoryApplication.Components;
using MarketInventoryApplication.Data;
using MarketInventoryApplication.Controllers;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(sp.GetRequiredService<NavigationManager>().BaseUri) });
builder.Services.AddSqlite<MarketInventoryContext>("Data Source=market.db");

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();
app.MapControllers();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MarketInventoryContext>();
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    SeedData.Initialize(db);
}

app.Run();
