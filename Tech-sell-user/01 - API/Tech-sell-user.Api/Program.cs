using Microsoft.EntityFrameworkCore;
using Tech_sell_user.Database.Context;
using Tech_sell_user.Domain.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appSettingsSection = builder.Configuration.GetSection("TechSellUserSettings");
builder.Services.Configure<TechSellUserSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<TechSellUserSettings>();

builder.Services.AddDbContext<TechSellUserContext>(options => options.UseMySql(appSettings?.ConnectionString, ServerVersion.AutoDetect(appSettings?.ConnectionString)));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();