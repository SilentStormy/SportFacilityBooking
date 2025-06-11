namespace SportFacilityBooking_Test;

using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Core.Domain.Services;
using Infrastructure.Data.Interfaces;
using Moq;
using SportFacilityBooking_Test.Helper;
using Xunit;


public class Reservation_Test
{
    [Fact]

    public void MakeReservation_TimeSlotAvailable_returnSuccess()
    {
        //Arrange
        var mockrepo = new Mock<IReservationRepository>();
        
        var reservationmanagement=new ReservationManagement(mockrepo.Object);


        var user = new User(1);
        var sportfacility = new SportFacility(2);
        var timeslot = new TimeSlot(5);
        var date = DateTime.Today;
        var reservation=new SportReservation(user, sportfacility, timeslot,date);
      
        var result= reservationmanagement.MakeReservation(reservation);
        Assert.True(result.Success);
        Assert.Equal("De reservering is voltooid!",result.Message);
    }

    [Fact]
  public void MakeReservation_TimeSlotNotAvailable_returnException()
    {
        //Arrange
        var mockrepo = new Mock<IReservationRepository>();

        var reservationmanagement = new ReservationManagement(mockrepo.Object);


        var user = new User(1);
        var sportfacility = new SportFacility(2);
        var timeslot = new TimeSlot(5);
        var date = DateTime.Today;
        var reservation = new SportReservation(user, sportfacility, timeslot, date);

        var result = reservationmanagement.MakeReservation(reservation);
        Assert.False(result.Success);
        Assert.Equal("De gekozen tijdslot is al bezet!",result.Message);
        

    }
}
