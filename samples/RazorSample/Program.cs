using AutoMapper;
using RazorSample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddConfidentialServices()
    .AddAutoMapper();

builder.Services.AddScoped<AutoMapper.IConfigurationProvider>(serviceProvider =>
{
    var profiles = serviceProvider.GetRequiredService<IEnumerable<Profile>>();
    var mappingConfig = new MapperConfiguration(mc =>
    {
        foreach (var profile in profiles)
        {
            mc.AddProfile(profile);
        }
    });
    return mappingConfig;
});
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddSingleton<Profile, MappingProfile>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
