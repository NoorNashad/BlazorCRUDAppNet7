using Blazor.Server.Data;
using Blazor.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);



#region CORS setting for API

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                              .AllowAnyHeader()
                                              .AllowAnyMethod();

                          //policy.WithOrigins("https://noorecommerceshop.netlify.app" , "http://noornashad-001-site3.etempurl.com")
                          //             .AllowAnyHeader()
                          //             .AllowAnyMethod();
                      });
});
#endregion




// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<IStudentServices, StudentServices>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("_myAllowSpecificOrigins");

app.MapDefaultControllerRoute(); 
app.MapBlazorHub();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
