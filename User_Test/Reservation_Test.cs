namespace SportFacilityBooking_Test;

using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Core.Domain.Services;
using Infrastructure.Data.Interfaces;
using Moq;
using SportFacilityBooking_Test.Helper;
//using SportFacilityBooking_Test.Helper;
using Xunit;


public class Reservation_Test
{
    [Fact]

    public void MakeReservation_TimeSlotAvailable_returnSuccess()
    {
        //Arrange
        
        var fakerepo=new FakeReservationRepo(false);
        var reservationmanagement=new ReservationManagement(fakerepo);
        var user = new User(1);
        var sportfacility = new SportFacility(2);
        var timeslot = new TimeSlot(5);
        var date = DateTime.Today;
        var reservation=new SportReservation(user, sportfacility, timeslot,date);
      
        //Act
        var result= reservationmanagement.MakeReservation(reservation);
        //Assert
        Assert.True(result.Success);
        Assert.Equal("De reservering is voltooid!",result.Message);
    }

    [Fact]
  public void MakeReservation_TimeSlotNotAvailable_returnException()
    {
        //Arrange
        var fakerepo = new FakeReservationRepo(true);
        var reservation = new ReservationManagement(fakerepo);
        var reservationt = new ReservationManagement(fakerepo);
        
        var user = new User(1);
        var sportfacility = new SportFacility(2);
        var timeslot = new TimeSlot(5);
        var date = DateTime.Today;
        var newreservation = new SportReservation(user, sportfacility, timeslot, date);

        var result = reservation.MakeReservation(newreservation);
        Assert.False(result.Success);
        Assert.Equal("De gekozen tijdslot is al bezet!",result.Message);
        

    }

  

   
}
