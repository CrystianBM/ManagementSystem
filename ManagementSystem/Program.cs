using ManagementSystem.Client.Services;
using ManagementSystem.Components;
using ManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=products.db"));

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddHttpClient<ProductApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7153/");
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ManagementSystem.Client._Imports).Assembly);

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.EnsureCreated();

    if (!db.Products.Any())
    {
        var products = new List<Product>
        {
            new("Notebook Dell", "SKU001", 3500, 10, "Eletrônicos"),
            new("Mouse Gamer", "SKU002", 120, 50, "Eletrônicos"),
            new("Teclado Mecânico", "SKU003", 300, 30, "Eletrônicos"),
            new("Monitor 24\"", "SKU004", 900, 15, "Eletrônicos"),
            new("Cadeira Escritório", "SKU005", 700, 20, "Móveis"),
            new("Mesa Gamer", "SKU006", 1200, 10, "Móveis"),
            new("Headset", "SKU007", 200, 40, "Eletrônicos"),
            new("Webcam HD", "SKU008", 180, 25, "Eletrônicos"),
            new("HD Externo", "SKU009", 400, 18, "Eletrônicos"),
            new("SSD 1TB", "SKU010", 550, 22, "Eletrônicos"),
            new("Camiseta Básica", "SKU011", 60, 100, "Roupas"),
            new("Calça Jeans", "SKU012", 150, 60, "Roupas"),
            new("Tênis Esportivo", "SKU013", 300, 35, "Roupas"),
            new("Jaqueta", "SKU014", 250, 20, "Roupas"),
            new("Boné", "SKU015", 40, 80, "Roupas"),
            new("Café 500g", "SKU016", 25, 200, "Alimentos"),
            new("Arroz 5kg", "SKU017", 35, 150, "Alimentos"),
            new("Feijão 1kg", "SKU018", 10, 180, "Alimentos"),
            new("Macarrão", "SKU019", 8, 170, "Alimentos"),
            new("Azeite", "SKU020", 30, 90, "Alimentos"),
            new("Livro C#", "SKU021", 90, 40, "Educação"),
            new("Curso Online", "SKU022", 200, 999, "Educação"),
            new("Caderno", "SKU023", 20, 120, "Educação"),
            new("Caneta", "SKU024", 5, 300, "Educação"),
            new("Mochila", "SKU025", 120, 45, "Educação"),
        };

        db.Products.AddRange(products);
        db.SaveChanges();
    }
}

app.Run();
