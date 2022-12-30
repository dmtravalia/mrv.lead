using System.Net.Http.Json;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using MRV.Lead.Api.UnitTest.Faker;
using MRV.Lead.Api.UnitTest.Fixture;

namespace MRV.Lead.Api.UnitTest.V1.Controllers;

public class ContactControllerTest : ContactFixture
{
    private const string path_version = "api/v1.0/Contact";

    [Fact]
    public async Task Deve_Cadastrar_Contact_Com_Sucesso()
    {
        // Arrange
        var contactCreateCommand = ContactFaker.CreateCommandFaker().Generate();

        // Act
        var response = await HttpClient.PostAsJsonAsync(path_version, contactCreateCommand);

        // Assert
        response.Should().NotBeNull();
        response.IsSuccessStatusCode.Should().BeTrue();
    }

    [Fact]
    public async Task Deve_Retornar_Falha_No_Campo_FullName_Ao_Cadastrar_Contact()
    {
        // Arrange
        var contactCreateCommand = ContactFaker.CreateCommandFaker().Generate();
        contactCreateCommand.FullName = default;

        // Act
        var response = await HttpClient.PostAsJsonAsync(path_version, contactCreateCommand);

        // Assert
        response.Should().NotBeNull();
        response.IsSuccessStatusCode.Should().BeFalse();
        var httpValidationProblemDetails = (HttpValidationProblemDetails)(await response.Content.ReadFromJsonAsync(typeof(HttpValidationProblemDetails)));
        var errors = httpValidationProblemDetails.Errors["Mensagens"];
        errors.Should().HaveCount(2);
    }

    [Fact]
    public async Task Deve_Retornar_Falha_No_Campo_Email_Ao_Cadastrar_Contact()
    {
        // Arrange
        var contactCreateCommand = ContactFaker.CreateCommandFaker().Generate();
        contactCreateCommand.Email = default;

        // Act
        var response = await HttpClient.PostAsJsonAsync(path_version, contactCreateCommand);

        // Assert
        response.Should().NotBeNull();
        response.IsSuccessStatusCode.Should().BeFalse();
        var httpValidationProblemDetails = (HttpValidationProblemDetails)(await response.Content.ReadFromJsonAsync(typeof(HttpValidationProblemDetails)));
        var errors = httpValidationProblemDetails.Errors["Mensagens"];
        errors.Should().HaveCount(2);
    }

    [Fact]
    public async Task Deve_Atualizar_Contact_Com_Sucesso()
    {
        // Arrange
        var contactUpdateCommand = ArrangeAtualizarContact();

        // Act
        var response = await HttpClient.PutAsJsonAsync(path_version, contactUpdateCommand);

        // Assert
        response.Should().NotBeNull();
        response.IsSuccessStatusCode.Should().BeTrue();
    }
}