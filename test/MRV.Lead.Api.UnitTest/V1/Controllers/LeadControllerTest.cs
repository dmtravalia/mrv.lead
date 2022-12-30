using FluentAssertions;
using MRV.Lead.Api.UnitTest.Core;
using MRV.Lead.Api.UnitTest.Faker;
using MRV.Lead.Api.UnitTest.Fixture;
using MRV.Lead.Application.Lead.Command;
using MRV.Lead.Application.QueryServices.Dtos;
using MRV.Lead.Domain.Enums;
using MRV.Lead.Domain.Models;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace MRV.Lead.Api.UnitTest.V1.Controllers;

public class LeadControllerTest : LeadFixture
{
    private const string path_version = "api/v1.0/Lead";

    [Fact]
    public async Task Deve_Cadastrar_Lead()
    {
        // Arrange
        var contactModel = ContactFaker.ModelFaker().Generate();
        DbContext.Set<ContactModel>().Add(contactModel);
        DbContext.SaveChanges();

        var leadCreateCommand = LeadFaker.CreateCommandFaker().Generate();
        leadCreateCommand.ContactID = contactModel.Id;

        // Act
        var response = await HttpClient.PostAsJsonAsync(path_version, leadCreateCommand);

        // Assert
        response.Should().NotBeNull();
        response.IsSuccessStatusCode.Should().BeTrue();
    }

    [Fact]
    public async Task Deve_Accept_Lead_Aplicando_Desconto()
    {
        // Arrange
        var leadModel = ArrangeLeadModel();
        var leadAcceptCommand = new LeadAcceptCommand() { Id = leadModel.Id };

        // Act
        var response = await HttpClient.PostAsJsonAsync(path_version + "/accept", leadAcceptCommand);

        // Assert
        response.Should().NotBeNull();
        response.IsSuccessStatusCode.Should().BeTrue();
    }

    [Fact]
    public async Task Deve_Decline_Lead()
    {
        // Arrange
        var leadModel = ArrangeLeadModel();
        var leadAcceptCommand = new LeadDeclineCommand() { Id = leadModel.Id };

        // Act
        var response = await HttpClient.PostAsJsonAsync(path_version + "/decline", leadAcceptCommand);

        // Assert
        response.Should().NotBeNull();
        response.IsSuccessStatusCode.Should().BeTrue();
    }

    [Fact]
    public async Task Deve_Listar_Lead()
    {
        // Arrange
        ArrangeList();

        // Act
        var response = await HttpClient.GetAsync(path_version + "/list");

        // Assert
        response.Should().NotBeNull();
        response.IsSuccessStatusCode.Should().BeTrue();

        var listLeadModel = await response.GetListDeserializeObjectAsync<LeadDto>();
        listLeadModel.Should().HaveCount(1);
        listLeadModel.FirstOrDefault().Status.Should().Be(Status.Default);
    }

    [Fact]
    public async Task Deve_Listar_Accept_Lead()
    {
        // Arrange
        ArrangeList();

        // Act
        var response = await HttpClient.GetAsync(path_version + "/list-accept");

        // Assert
        response.Should().NotBeNull();
        response.IsSuccessStatusCode.Should().BeTrue();

        var listLeadModel = await response.GetListDeserializeObjectAsync<LeadDto>();
        listLeadModel.Should().HaveCount(1);
        listLeadModel.FirstOrDefault().Status.Should().Be(Status.Accept);
    }

    [Fact]
    public async Task Deve_Listar_Decline_Lead()
    {
        // Arrange
        ArrangeList();

        // Act
        var response = await HttpClient.GetAsync(path_version + "/list-decline");

        // Assert
        response.Should().NotBeNull();
        response.IsSuccessStatusCode.Should().BeTrue();

        var listLeadModel = await response.GetListDeserializeObjectAsync<LeadDto>();
        listLeadModel.Should().HaveCount(1);
        listLeadModel.FirstOrDefault().Status.Should().Be(Status.Decline);
    }
}