using System;
using Lab1;

namespace ReservationApp.Tests;

[TestClass]
public class FormTests
{
    private Form1 _form;

    [TestInitialize]
    public void SetUp()
    {
        _form = new Form1();
        _form.reservationManager.Reservations.Clear();
        _form.Show();
    }

    [TestCleanup]
    public void TearDown()
    {
        _form.Dispose();
    }

    [TestMethod]
    public void CustomerNameTextBox_IsVisibleAndEnabled()
    {
        Assert.IsTrue(_form.customerNameTextBox.Visible);
        Assert.IsTrue(_form.customerNameTextBox.Enabled);
    }

    [TestMethod]
    public void AddReservationButton_IsVisibleAndEnabled()
    {
        Assert.IsTrue(_form.addReservationButton.Visible);
        Assert.IsTrue(_form.addReservationButton.Enabled);
    }

    [TestMethod]
    public void ReservationsListBox_IsVisibleAndEnabled()
    {
        Assert.IsTrue(_form.reservationsListBox.Visible);
        Assert.IsTrue(_form.reservationsListBox.Enabled);
    }

    [TestMethod]
    public void AddReservationButton_ValidData_AddsReservation()
    {
        _form.customerNameTextBox.Text = "Степан";
        _form.startTimePicker.Value = DateTime.Now;
        _form.endTimePicker.Value = DateTime.Now.AddHours(2);
        _form.addReservationButton.PerformClick();
        Assert.AreEqual(1, _form.reservationManager.Reservations.Count);
    }

    [TestMethod]
    public void RemoveReservationButton_SelectedItem_RemovesReservation()
    {
        var r = new Reservation("Степан", DateTime.Now, DateTime.Now.AddHours(2));
        _form.reservationManager.AddReservation(r);
        _form.UpdateReservationsList();
        _form.reservationsListBox.SelectedIndex = 0;
        _form.removeReservationButton.PerformClick();
        Assert.AreEqual(0, _form.reservationManager.Reservations.Count);
    }
}