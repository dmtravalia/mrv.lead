using MRV.Lead.Api.UnitTest.Faker;
using MRV.Lead.Domain.Models;
using MRV.Lead.Application.Contact.Command;

namespace MRV.Lead.Api.UnitTest.Fixture;

public class ContactFixture : TestServerFixture
{
    public ContactUpdateCommand ArrangeAtualizarContact()
    {
        var email = "eu@eu.com.br";
        var contactModel = ContactFaker.ModelFaker().Generate();
        DbContext.Set<ContactModel>().Add(contactModel);
        DbContext.SaveChanges();
        var contactUpdateCommand = Mapper.Map<ContactUpdateCommand>(contactModel);
        contactUpdateCommand.Email = email;

        return contactUpdateCommand;
    }
}