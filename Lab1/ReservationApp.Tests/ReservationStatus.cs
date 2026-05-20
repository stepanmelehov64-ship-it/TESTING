using Lab1;

namespace ReservationApp.Tests;

[TestClass]
public class ReservationStatusTests
{
    [TestMethod]
    public void ReservationStatus_HasExactlyThreeValues()
    {
        var values = Enum.GetValues(typeof(ReservationStatus));
        Assert.AreEqual(3, values.Length);
    }

    [TestMethod]
    public void ReservationStatus_ContainsАктивно()
    {
        Assert.IsTrue(Enum.IsDefined(typeof(ReservationStatus), ReservationStatus.Активно));
    }

    [TestMethod]
    public void ReservationStatus_ContainsОтменено()
    {
        Assert.IsTrue(Enum.IsDefined(typeof(ReservationStatus), ReservationStatus.Отменено));
    }

    [TestMethod]
    public void ReservationStatus_ContainsЗавершено()
    {
        Assert.IsTrue(Enum.IsDefined(typeof(ReservationStatus), ReservationStatus.Завершено));
    }
}