using Unik.Onboarding.Domain.DomainServices;
using Unik.Onboarding.Domain.Model;
using Moq;

namespace Unik.Onboarding.Domain.Test.BookingEntityTests;

public class BookingEntityCreateTests
{
    /// <summary>
    /// If a date has not been booked, then the new booking can be created 
    /// </summary>
    [Fact]
    public void Given_Date_Is_Valid__Then_BookingEntity_Is_Created()
    {
        // Arrange
        var mock = new Mock<IBookingDomainService>();
        mock.Setup(m => m.BookingDateIsTaken(It.IsAny<DateTime>())).Returns(false);

        // Act
        var sut = new BookingEntity(mock.Object, DateTime.Parse("2 December 2023"), "");

        // Assert

    }
    /// <summary>
    /// If a date has been booked, then an error should occur
    /// </summary>
    [Fact]
    public void Given_Date_Is_InValid__Then_ArgumentException_Is_Thrown()
    {
        // Arrange
        var mock = new Mock<IBookingDomainService>();
        mock.Setup(m => m.BookingDateIsTaken(It.IsAny<DateTime>())).Returns(true);

        // Act


        // Assert
        Assert.Throws<ArgumentException>(() => new BookingEntity(mock.Object, DateTime.Parse("2 December 2023"), ""));
    }
}