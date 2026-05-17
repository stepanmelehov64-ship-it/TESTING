using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        internal ReservationManager reservationManager;

        public Form1()
        {
            InitializeComponent();
            reservationManager = new ReservationManager();
            statusComboBox.Items.Add("Активно");
            statusComboBox.Items.Add("Отменено");
            statusComboBox.Items.Add("Завершено");
            statusComboBox.SelectedIndex = 0;
            UpdateReservationsList();
        }

        internal void UpdateReservationsList()
        {
            reservationsListBox.Items.Clear();
            foreach (var reservation in reservationManager.Reservations)
                reservationsListBox.Items.Add(reservation);
        }

        private void addReservationButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customerNameTextBox.Text))
            {
                MessageBox.Show("Введите имя клиента!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime startTime = startTimePicker.Value;
            DateTime endTime = endTimePicker.Value;

            if (startTime >= endTime)
            {
                MessageBox.Show("Время начала должно быть раньше времени окончания!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var reservation = new Reservation(customerNameTextBox.Text, startTime, endTime);
            reservationManager.AddReservation(reservation);
            customerNameTextBox.Clear();
            UpdateReservationsList();
        }

        private void removeReservationButton_Click(object sender, EventArgs e)
        {
            if (reservationsListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите резервирование!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var reservation = (Reservation)reservationsListBox.SelectedItem;
            reservationManager.RemoveReservation(reservation);
            UpdateReservationsList();
        }

        private void updateStatusButton_Click(object sender, EventArgs e)
        {
            if (reservationsListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите резервирование!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var reservation = (Reservation)reservationsListBox.SelectedItem;
            var status = (ReservationStatus)Enum.Parse(typeof(ReservationStatus),
                statusComboBox.SelectedItem.ToString());
            reservationManager.UpdateReservationStatus(reservation, status);
            UpdateReservationsList();
        }
    }
}