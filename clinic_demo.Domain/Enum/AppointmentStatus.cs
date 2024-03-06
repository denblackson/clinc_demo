namespace clinic_demo.Domain.Enum
{
    public enum AppointmentStatus
    {
        Confirmed, // Запис на прийом підтверджений і прийом планується.
        Pending,   // Запис на прийом в очікуванні, не підтверджений або не виконаний.
        Cancelled, // Запис на прийом скасовано, прийом не відбудеться.
        Completed  // Прийом вже відбувся та завершено.
    }
}
