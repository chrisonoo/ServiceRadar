using ServiceRadar.Domain.Entities;
using ServiceRadar.Infrastructure.Data;

namespace ServiceRadar.Infrastructure.Seeders;
public static class ServiceRadarSeederWorkshops
{
    private static readonly List<Workshop> _workshopList = new()
    {
        new Workshop
        {
            Name = "Mazda Service Senter",
                    Description = "Authorized Mazda service center",
                    About = "Warranty and post-warranty service. Full service.",
                    ContactDetails = new()
                    {
                        City = "Sandefjord",
                        Street = "Gjekstadveien 2",
                        PostalCode = "3218",
                        PhoneNumber = "+47 33 45 43 00"
                    }
        },
        new Workshop
        {
            Name = "Ford Transit Senter",
                    Description = "Authorized Ford center",
                    About = "",
                    ContactDetails = new()
                    {
                        City = "Sandefjord",
                        Street = "Nygårdsveien 79",
                        PostalCode = "3221",
                        PhoneNumber = "+47 815 20 500"
                    }
        },
        new Workshop
        {
            Name = "Tesla Senter",
                    Description = "Authorized Tesla center",
                    About = "Specializing in commercial and heavy-duty vehicles. Ongoing repairs for passenger cars.",
                    ContactDetails = new()
                    {
                        City = "Sandefjord",
                        Street = "Fokserødveien 23",
                        PostalCode = "3241",
                        PhoneNumber = "+47 23 96 02 85"
                    }
        },
    };

    public static void Initialize(ServiceRadarDbContext dbContext)
    {
        foreach(var workshop in _workshopList)
        {
            workshop.EncodeName();
            dbContext.Workshops.Add(workshop);
        }
    }
}
