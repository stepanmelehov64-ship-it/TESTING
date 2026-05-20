using System;
using Lab1;

namespace ReservationApp.Tests;

[TestClass]
public class ReservationManagerTests
{
    private ReservationManager _manager;

    [TestInitialize]
    public void SetUp()
    {
        _manager = new ReservationManager();
        _manager.Reservations.Clear();
    }

    [TestMethod]
    public void AddReservation_ValidReservation_AddsToList()
    {
        var r = new Reservation("Степан", DateTime.Now, DateTime.Now.AddHours(2));
        _manager.AddReservation(r);
        Assert.AreEqual(1, _manager.Reservations.Count);
    }

    [TestMethod]
    public void AddReservation_Null_ThrowsArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(
            () => _manager.AddReservation(null!));
    }

    [TestMethod]
    public void RemoveReservation_ExistingReservation_RemovesFromList()
    {
        var r = new Reservation("Степан", DateTime.Now, DateTime.Now.AddHours(2));
        _manager.AddReservation(r);
        _manager.RemoveReservation(r);
        Assert.AreEqual(0, _manager.Reservations.Count);
    }

    [TestMethod]
    public void RemoveReservation_Null_ThrowsArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(
            () => _manager.RemoveReservation(null!));
    }

    [TestMethod]
    public void UpdateReservationStatus_ChangesStatus()
    {
        var r = new Reservation("Степан", DateTime.Now, DateTime.Now.AddHours(2));
        _manager.AddReservation(r);
        _manager.UpdateReservationStatus(r, ReservationStatus.Завершено);
        Assert.AreEqual(ReservationStatus.Завершено, r.Status);
    }

    [TestMethod]
    public void UpdateReservationStatus_Null_ThrowsArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(
            () => _manager.UpdateReservationStatus(null!, ReservationStatus.Завершено));
    }

    [TestMethod]
    public void SaveAndLoad_ReservationsAreRestored()
    {
        var r = new Reservation("Степан", DateTime.Now, DateTime.Now.AddHours(2));
        _manager.AddReservation(r);
        var manager2 = new ReservationManager();
        Assert.AreEqual(1, manager2.Reservations.Count);
        Assert.AreEqual("Степан", manager2.Reservations[0].CustomerName);
    }
}