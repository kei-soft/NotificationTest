using NotificationTest.Common;
using NotificationTest.Components;
using NotificationTest.Services;

namespace NotificationTest;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // SignalR ���� �߰�
        builder.Services.AddSignalR();

        // �˸� ���� �߰�
        builder.Services.AddScoped<NotificationService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        // SignalR Hub ����
        app.MapHub<NotificationHub>("/notificationhub");

        app.Run();
    }
}
