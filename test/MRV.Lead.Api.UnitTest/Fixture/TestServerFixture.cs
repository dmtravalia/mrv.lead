using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MRV.Lead.Infra.Context;
using Microsoft.EntityFrameworkCore.Storage;
using AutoMapper;

namespace MRV.Lead.Api.UnitTest.Fixture;

public class TestServerFixture
{
    public readonly HttpClient HttpClient;
    public readonly AppDbContext DbContext;
    public readonly IMapper Mapper;

    public TestServerFixture()
    {
        var application = new LeadApiApplication();
        HttpClient = application.CreateClient();
        DbContext = application.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
        Mapper = application.Services.GetService<IMapper>();
    }
}

public class LeadApiApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var root = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<AppDbContext>));
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("Testing", root));
        });

        return base.CreateHost(builder);
    }
}