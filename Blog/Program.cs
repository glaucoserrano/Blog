using Blog.Data;
using Blog.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddTransient<TokenService>();

builder.Services.AddDbContext<BlogDataContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
