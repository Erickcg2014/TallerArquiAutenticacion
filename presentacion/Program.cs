var builder = WebApplication.CreateBuilder(args);

// ============================================
// Servicios necesarios para Razor Pages
// ============================================
builder.Services.AddRazorPages();

// Para consumir el backend vía HttpClient
builder.Services.AddHttpClient();

var app = builder.Build();

// ============================================
// Middlewares del pipeline
// ============================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); 
app.UseRouting();

// app.UseAuthorization();

// ============================================
// Mapear Razor Pages 
// ============================================
app.MapRazorPages();

app.Run();
