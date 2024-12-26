using NotesApiWithUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавляем NoteService
builder.Services.AddSingleton<NoteService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();