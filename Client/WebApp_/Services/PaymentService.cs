using WebApp_.Models.Payment;
using WebApp_.Services.Intefaces;

namespace WebApp_.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput)
        {
            var response = await _httpClient.PostAsJsonAsync<PaymentInfoInput>("fakepayment", paymentInfoInput);

            return response.IsSuccessStatusCode;
        }
    }
}
