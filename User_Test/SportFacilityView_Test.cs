using Core.Domain.Entities;
using Core.Domain.Services;
using Infrastructure.Data.Interfaces;
using Moq;

namespace SportFacilityBooking_Test;


public class SportFacilityView_Test
{
    [Fact]
    public void SearchSportFacility_returnSportfacilities()
    {
        var mockrepo = new Mock<ISportFacilityRepository>();
        var sportfacilityservice=new SportFacilityService(mockrepo.Object);
        var searhcedkeyword = new SportFacility(0, "Tennisbaan","","",0);
        var expectedresults = new List<SportFacility>
        {
             new SportFacility(1, "Tennisbaan 1", "Buiten", "Tennisveld", 4),
             new SportFacility(2, "Tennisbaan 2", "Binnen", "Indoor tennis", 2)
        };

        var result=sportfacilityservice.SearchFacility(searhcedkeyword);

        Assert.Equal(2, result.Count);
    }
}
