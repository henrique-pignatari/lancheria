namespace Lancheria.Domain.Enums
{
    public enum OrderStatus
    {
        Received,
        Processing,
        WaitingPayment,
        PaymentConfirmed,
        Preparing,
        Delivering,
        Completed,
        Canceled
    }
}
