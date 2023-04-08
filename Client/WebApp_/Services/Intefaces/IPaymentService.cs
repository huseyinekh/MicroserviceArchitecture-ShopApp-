using WebApp_.Models.Payment;

namespace WebApp_.Services.Intefaces
{

    public interface IPaymentService
    {
        Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput);
    }
}
