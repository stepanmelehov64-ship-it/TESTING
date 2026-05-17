namespace Lab1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        internal System.Windows.Forms.TextBox customerNameTextBox;
        internal System.Windows.Forms.DateTimePicker startTimePicker;
        internal System.Windows.Forms.DateTimePicker endTimePicker;
        internal System.Windows.Forms.ComboBox statusComboBox;
        internal System.Windows.Forms.Button addReservationButton;
        internal System.Windows.Forms.Button removeReservationButton;
        internal System.Windows.Forms.Button updateStatusButton;
        internal System.Windows.Forms.ListBox reservationsListBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.addReservationButton = new System.Windows.Forms.Button();
            this.removeReservationButton = new System.Windows.Forms.Button();
            this.updateStatusButton = new System.Windows.Forms.Button();
            this.reservationsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            this.customerNameTextBox.Location = new System.Drawing.Point(10, 10);
            this.customerNameTextBox.Size = new System.Drawing.Size(150, 22);

            this.startTimePicker.Location = new System.Drawing.Point(170, 10);
            this.startTimePicker.Size = new System.Drawing.Size(150, 22);

            this.endTimePicker.Location = new System.Drawing.Point(330, 10);
            this.endTimePicker.Size = new System.Drawing.Size(150, 22);

            this.statusComboBox.Location = new System.Drawing.Point(10, 40);
            this.statusComboBox.Size = new System.Drawing.Size(120, 24);
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.addReservationButton.Location = new System.Drawing.Point(10, 70);
            this.addReservationButton.Size = new System.Drawing.Size(100, 30);
            this.addReservationButton.Text = "Добавить";
            this.addReservationButton.Click += new System.EventHandler(this.addReservationButton_Click);

            this.removeReservationButton.Location = new System.Drawing.Point(120, 70);
            this.removeReservationButton.Size = new System.Drawing.Size(100, 30);
            this.removeReservationButton.Text = "Удалить";
            this.removeReservationButton.Click += new System.EventHandler(this.removeReservationButton_Click);

            this.updateStatusButton.Location = new System.Drawing.Point(230, 70);
            this.updateStatusButton.Size = new System.Drawing.Size(140, 30);
            this.updateStatusButton.Text = "Обновить статус";
            this.updateStatusButton.Click += new System.EventHandler(this.updateStatusButton_Click);

            this.reservationsListBox.Location = new System.Drawing.Point(10, 110);
            this.reservationsListBox.Size = new System.Drawing.Size(560, 260);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.customerNameTextBox);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.addReservationButton);
            this.Controls.Add(this.removeReservationButton);
            this.Controls.Add(this.updateStatusButton);
            this.Controls.Add(this.reservationsListBox);
            this.Text = "Reservation Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}