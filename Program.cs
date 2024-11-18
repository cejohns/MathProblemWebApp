using MathProblemWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(); // Ensure Razor Pages services are registered
builder.Services.AddControllers(); // Optional, if you have API controllers
builder.Services.AddSingleton<MathProblemService>(); // Register your custom service

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers(); // Add this line to map API controllers

app.Run();
