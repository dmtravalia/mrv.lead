using Bogus;
using MRV.Lead.Application.Lead.Command;
using MRV.Lead.Domain.Enums;
using MRV.Lead.Domain.Models;
using System;

namespace MRV.Lead.Api.UnitTest.Faker;

public static class LeadFaker
{
    public static Faker<LeadCreateCommand> CreateCommandFaker() =>
        new Faker<LeadCreateCommand>()
        .Rules((f, o) =>
        {
            o.Description = f.Random.Words(3);
            o.Price = f.Random.Number(1, 99999);
            o.Suburb = f.Random.Words();
            o.Category = f.Random.Words(2);
            o.ContactID = Guid.NewGuid();
        });

    public static Faker<LeadModel> ModelFaker(Status status = Status.Default) =>
        new Faker<LeadModel>()
        .Rules((f, o) =>
        {
            o.Id = Guid.NewGuid();
            o.Description = f.Random.Words(3);
            o.Price = f.Random.Number(500, 99999);
            o.Suburb = f.Random.Words();
            o.Category = f.Random.Words(2);
            o.ContactID = Guid.NewGuid();
            o.Status = status;
            o.DataInclusao = DateTime.Now.AddMinutes(-5);
        });
}