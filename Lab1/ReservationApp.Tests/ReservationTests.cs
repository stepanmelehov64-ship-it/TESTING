using System;
using Lab1;

namespace ReservationApp.Tests;

[TestClass]
public class ReservationTests
{
    [TestMethod]
    public void Constructor_SetsCustomerName()
    {
        var r = new Reservation("Степан", DateTime.Now, DateTime.Now.AddHours(2));
        Assert.AreEqual("Степан", r.CustomerName);
    }

    [TestMethod]
    public void Constructor_SetsStartTime()
    {
        var start = new DateTime(2026, 1, 1, 10, 0, 0);
        var r = new Reservation("Степан", start, start.AddHours(2));
        Assert.AreEqual(start, r.StartTime);
    }

    [TestMethod]
    public void Constructor_SetsEndTime()
    {
        var end = new DateTime(2026, 1, 1, 12, 0, 0);
        var r = new Reservation("Степан", DateTime.Now, end);
        Assert.AreEqual(end, r.EndTime);
    }

    [TestMethod]
    public void Constructor_DefaultStatus_IsАктивно()
    {
        var r = new Reservation("Степан", DateTime.Now, DateTime.Now.AddHours(2));
        Assert.AreEqual(ReservationStatus.Активно, r.Status);
    }

    [TestMethod]
    public void UpdateStatus_ChangesStatus()
    {
        var r = new Reservation("Степан", DateTime.Now, DateTime.Now.AddHours(2));
        r.UpdateStatus(ReservationStatus.Завершено);
        Assert.AreEqual(ReservationStatus.Завершено, r.Status);
    }
}