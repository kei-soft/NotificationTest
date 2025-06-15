using NotificationTest.Components;

namespace NotificationTest;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // SignalR 서비스 추가
        builder.Services.AddSignalR();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddRazorPages();

        // 알림 서비스 추가
        builder.Services.AddScoped<NotificationService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        // SignalR Hub 매핑
        app.MapHub<NotificationHub>("/notificationhub");

        app.Run();
    }
}
