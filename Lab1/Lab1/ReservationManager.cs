using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab1
{
    public class ReservationManager
    {
        public List<Reservation> Reservations { get; private set; }
        private const string FilePath = "reservations.txt";

        public ReservationManager()
        {
            Reservations = new List<Reservation>();
            LoadReservations();
        }

        public void AddReservation(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));
            Reservations.Add(reservation);
            SaveReservations();
        }

        public void RemoveReservation(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));
            Reservations.Remove(reservation);
            SaveReservations();
        }

        public void UpdateReservationStatus(Reservation reservation, ReservationStatus status)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));
            reservation.UpdateStatus(status);
            SaveReservations();
        }

        public void SaveReservations()
        {
            File.WriteAllLines(FilePath,
                Reservations.Select(r =>
                    $"{r.CustomerName}|{r.StartTime}|{r.EndTime}|{r.Status}"));
        }

        public void LoadReservations()
        {
            if (!File.Exists(FilePath)) return;
            foreach (var line in File.ReadAllLines(FilePath))
            {
                var parts = line.Split('|');
                if (parts.Length != 4) continue;
                if (!DateTime.TryParse(parts[1], out DateTime start)) continue;
                if (!DateTime.TryParse(parts[2], out DateTime end)) continue;
                if (!Enum.TryParse(parts[3], out ReservationStatus status)) continue;
                var reservation = new Reservation(parts[0], start, end);
                reservation.Status = status;
                Reservations.Add(reservation);
            }
        }
    }
}