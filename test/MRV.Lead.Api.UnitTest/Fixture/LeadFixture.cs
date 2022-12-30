using MRV.Lead.Api.UnitTest.Faker;
using MRV.Lead.Domain.Enums;
using MRV.Lead.Domain.Models;

namespace MRV.Lead.Api.UnitTest.Fixture;

public class LeadFixture : TestServerFixture
{
    public LeadModel ArrangeLeadModel()
    {
        var contactModel = ContactFaker.ModelFaker().Generate();
        var leadModel = LeadFaker.ModelFaker().Generate();
        leadModel.ContactID = contactModel.Id;
        leadModel.Contact = contactModel;
        DbContext.Set<ContactModel>().Add(contactModel);
        DbContext.Set<LeadModel>().Add(leadModel);
        DbContext.SaveChanges();
        return leadModel;
    }

    public void ArrangeList()
    {
        var contactModel = ContactFaker.ModelFaker().Generate();
        var leadModel = LeadFaker.ModelFaker().Generate();
        var leadModelAccept = LeadFaker.ModelFaker(Status.Accept).Generate();
        var leadModelDecline = LeadFaker.ModelFaker(Status.Decline).Generate();
        DbContext.Set<ContactModel>().Add(contactModel);
        DbContext.Set<LeadModel>().Add(leadModel);
        DbContext.Set<LeadModel>().Add(leadModelAccept);
        DbContext.Set<LeadModel>().Add(leadModelDecline);
        DbContext.SaveChanges();
    }
}