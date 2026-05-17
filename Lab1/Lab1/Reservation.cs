using System;

namespace Lab1
{
    public enum ReservationStatus
    {
        Активно,
        Отменено,
        Завершено
    }

    public class Reservation
    {
        public string CustomerName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus Status { get; set; }

        public Reservation(string customerName, DateTime startTime, DateTime endTime)
        {
            CustomerName = customerName;
            StartTime = startTime;
            EndTime = endTime;
            Status = ReservationStatus.Активно;
        }

        public void UpdateStatus(ReservationStatus newStatus)
        {
            Status = newStatus;
        }

        public override string ToString()
        {
            return $"{CustomerName} | {StartTime:dd.MM.yyyy HH:mm} | {EndTime:dd.MM.yyyy HH:mm} | {Status}";
        }
    }
}