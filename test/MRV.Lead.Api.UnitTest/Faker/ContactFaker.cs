using MRV.Lead.Application.Contact.Command;
using Bogus;
using MRV.Lead.Domain.Models;
using System;

namespace MRV.Lead.Api.UnitTest.Faker;

public static class ContactFaker
{
    public static Faker<ContactCreateCommand> CreateCommandFaker() =>
        new Faker<ContactCreateCommand>()
        .Rules((f, o) =>
        {
            o.FullName = f.Person.FullName;
            o.PhoneNumber = f.Random.Number(9999999);
            o.Email = f.Person.Email;
        });

    public static Faker<ContactModel> ModelFaker() =>
        new Faker<ContactModel>()
        .Rules((f, o) =>
        {
            o.Id = Guid.NewGuid();
            o.FullName = f.Person.FullName;
            o.PhoneNumber = f.Random.Number(9999999);
            o.Email = f.Person.Email;
            o.DataInclusao = DateTime.Now.AddMinutes(-5);
        });
}