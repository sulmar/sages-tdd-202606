using Reservations;
using System.Net.NetworkInformation;
using System.Security.AccessControl;

namespace PathBasedTesting.Tests;

/*
1. Administrator może anulować każdą rezerwację.
2. Właściciel rezerwacji może anulować własną rezerwację.
3. Pozostali użytkownicy nie mogą anulować rezerwacji.
4. Próba sprawdzenia uprawnień dla niezdefiniowanego użytkownika jest błędem.
*/


public class ReservationTests
{
    private readonly User owner = new User();
    
    private readonly User admin = new User { IsAdmin = true };
    
    private readonly Reservation reservation;

    public ReservationTests()
    {
        reservation = new Reservation { Owner = owner };
    }

    [Fact]
    public void CanCancel_UserIsAdmin_ReturnsTrue()
    {
        // Act
        var result = reservation.CanCancel(admin);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CanCancel_UserIsOwner_ReturnsTrue()
    {        
        // Act
        var result = reservation.CanCancel(owner);

        // Assert
        Assert.True(result);
    }


    [Fact]
    public void CanCancel_UserIsNotOwnerOrAdmin_ReturnsFalse()
    {
        // Act
        var result = reservation.CanCancel(new User());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CanCancel_UserIsEmpty_ThrowsArgumentNullException()
    {        
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => reservation.CanCancel(null));
    }

}
