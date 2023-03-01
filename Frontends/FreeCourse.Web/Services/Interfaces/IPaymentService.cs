using FreeCourse.Web.Models.FakePayments;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Interfaces
{
    public class IPaymentService
    {
        Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput);
    }
}
