//using infrastructure;

using infrastructure;
using service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNpgsqlDataSource(Utilities.ProperlyFormattedConnectionString,
   dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());
builder.Services.AddSingleton<Repository>();
builder.Services.AddSingleton<Service>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var frontEndRelativePath = "./../frontend/www";
builder.Services.AddSpaStaticFiles(conf => conf.RootPath = frontEndRelativePath);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.UseSpaStaticFiles();
app.UseSpa(conf =>
{
    conf.Options.SourcePath = frontEndRelativePath;
});

app.MapControllers();
app.Run();