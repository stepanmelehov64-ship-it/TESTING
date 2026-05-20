using System;
using Lab1;

namespace ReservationApp.Tests;

[TestClass]
public class BoundaryConditionTests
{
    private ReservationManager _manager;

    [TestInitialize]
    public void SetUp()
    {
        _manager = new ReservationManager();
        _manager.Reservations.Clear();
    }

    [TestMethod]
    public void Reservation_EmptyCustomerName_IsAllowed()
    {
        var r = new Reservation("", DateTime.Now, DateTime.Now.AddHours(1));
        Assert.AreEqual("", r.CustomerName);
    }

    [TestMethod]
    public void Reservation_VeryLongCustomerName_IsAllowed()
    {
        var longName = new string('А', 10000);
        var r = new Reservation(longName, DateTime.Now, DateTime.Now.AddHours(1));
        Assert.AreEqual(10000, r.CustomerName.Length);
    }

    [TestMethod]
    public void Reservation_StartTimeInPast_IsAllowed()
    {
        var past = new DateTime(2000, 1, 1);
        var r = new Reservation("Степан", past, past.AddHours(1));
        Assert.AreEqual(past, r.StartTime);
    }

    [TestMethod]
    public void Reservation_StartAndEndSameTime_IsAllowed()
    {
        var time = DateTime.Now;
        var r = new Reservation("Степан", time, time);
        Assert.AreEqual(r.StartTime, r.EndTime);
    }

    [TestMethod]
    public void RemoveReservation_NonExisting_DoesNotThrow()
    {
        var r = new Reservation("Степан", DateTime.Now, DateTime.Now.AddHours(1));
        _manager.RemoveReservation(r);
        Assert.AreEqual(0, _manager.Reservations.Count);
    }
}