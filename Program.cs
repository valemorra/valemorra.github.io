using BlazorStatic;
using BlazorStaticMinimalBlog.Components;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseStaticWebAssets();

builder.Services.AddBlazorStaticService(opt => {
    opt.IgnoredPathsOnContentCopy.Add("app.css");//pre-build version for tailwind
}
).AddBlazorStaticContentService<BlogFrontMatter>();

builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.UseBlazorStaticGenerator(shutdownApp: !app.Environment.IsDevelopment());

app.Run();

public static class WebsiteKeys
{
    public const string GitHubRepo = "https://github.com/valemorra/valemorra.github.io";
    public const string X = "https://www.linkedin.com/in/valeria-morra-02684b16b/";
    public const string Title = "Cognitive Biases and Their Impact on UX/UI Design Part 01";
    public const string BlogPostStorageAddress = $"{GitHubRepo}/tree/main/Content/Blog";
    public const string BlogLead = "Cognitive Biases and Their Impact on UX/UI Design Part 01";

}
