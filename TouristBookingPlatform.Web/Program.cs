using TouristBookingPlatform.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<EventService>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/Account/Login";
    });

builder.Services.AddAuthorization();

// Add HttpClient specifically for backend pinging to wake up free db instance
builder.Services.AddHttpClient("HealthClient");

var app = builder.Build();


// Middleware to ping the backend and set a cookie
app.Use(async (context, next) =>
{
    var cookieName = "LastHealthCheck";
    var cookieValue = context.Request.Cookies[cookieName];

    if (string.IsNullOrEmpty(cookieValue))
    {
        // Cookie is missing or expired
        var httpClientFactory = context.RequestServices.GetRequiredService<IHttpClientFactory>();
        var client = httpClientFactory.CreateClient("HealthClient");

        try
        {
            await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, "https://tourist-booking-service.azurewebsites.net/health"));
        }
        catch
        {
            // Silently fail to avoid interrupting user experience
        }

        // Set cookie for 10 minutes
        context.Response.Cookies.Append(cookieName, DateTime.UtcNow.ToString(), new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddMinutes(10),
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict
        });
    }

    await next();
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
