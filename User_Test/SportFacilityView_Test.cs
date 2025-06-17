using Core.Domain.Entities;
using Core.Domain.Services;
using Infrastructure.Data.Dto_s;
using Infrastructure.Data.Interfaces;
using Moq;
using MySqlX.XDevAPI.Common;
using System.ComponentModel.DataAnnotations;

namespace SportFacilityBooking_Test;


public class SportFacilityView_Test
{
    [Fact]
    public void SearchSportFacility_returnSportfacilities()
    {
        var mockrepo = new Mock<ISportFacilityRepository>();
        var sportfacilityservice=new SportFacilityService(mockrepo.Object);
        var searhcedkeyword = new SportFacility(0, "Tennisbaan","","",0);
        var expectedresult = new List<SportFacilityDto>
        {
             new SportFacilityDto
             {
                 SportFacilityId=1,
                 Name="Tennisbaan 1",
                 Type="Buiten",
                 Description="Tennis",
                 Capacity=5

             }, 
             
        };
        mockrepo.Setup(repo => repo.SearchSportFacility(searhcedkeyword.Name))
            .Returns(expectedresult); // dus als de methode SearchSportfacility wordt aangeroepen met het argument searchedkeyword==>geef dan de expected result terug 

        var result = sportfacilityservice.SearchFacility(searhcedkeyword); // deze roept weer de mock aan voor het resultaat

        Assert.Equal(1, result.Count);
        Assert.Contains(result, r => r.Name == "Tennisbaan 1");
    }

    [Fact]
    public void Getfacilitieslist_returnlist()
    {
        var mockrepo=new Mock<ISportFacilityRepository>();
        var facilityservice=new SportFacilityService(mockrepo.Object);

        var expectedresult = new List<SportFacilityDto>
        {
             new SportFacilityDto
             {
                 SportFacilityId=1,
                 Name="Tennisbaan 1",
                 Type="Buiten",
                 Description="Tennis",
                 Capacity=5

             },
             new SportFacilityDto
             {
                    SportFacilityId=1,
                 Name="Tennisbaan 1",
                 Type="Buiten",
                 Description="Tennis",
                 Capacity=3
             },
        };
        mockrepo.Setup(repo=>repo.GetAllFacilities())
            .Returns(expectedresult);
        var result = facilityservice.GetAllFacilities();
        Assert.Equal(2, result.Count);
    }
}
